using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ContactBookAppWithASP
{
	public partial class ContactBook : System.Web.UI.Page
	{
		ContactBookDB contactBookDB;

		protected void Page_Load(object sender, EventArgs e)
		{
			contactBookDB = new ContactBookDB();

			if(!IsPostBack)
			{
				ShowRecords();
			}
		}

		protected void ShowRecords()
		{
			SqlDataAdapter contactSet = contactBookDB.ViewAllContactsFromDB();

			DataSet ds = new DataSet();
			contactSet.Fill(ds);

			GridView1.DataSource = ds;
			GridView1.DataBind();
		}

		protected void AddContact_Click(object sender, EventArgs e)
		{
			Contact contact = new Contact();

			contact.Name = userName.Value.ToString();
			contact.FirstName = firstName.Value.ToString();
			contact.LastName = lastName.Value.ToString();
			contact.Email = eMail.Value.ToString();

			long lPhoneNumber;

			if(long.TryParse(phoneNumber.Value.ToString(), out lPhoneNumber))
			{
				contact.PhoneNumber = lPhoneNumber;

				if(contactBookDB.AddContactToDB(contact))
				{
					ShowRecords();

					userName.Value = "";
					firstName.Value = "";
					lastName.Value = "";
					eMail.Value = "";
					phoneNumber.Value = "";
				}
				else
				{
					Response.Write("Something Wrong Happened...");
				}
			}
			else
			{
				Response.Write("Please enter a correct mobile number...");
			}
		}

		protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if(e.CommandName == "EditContact")
			{
				string[] commandArguments = e.CommandArgument.ToString().Split(new char[] { ',' });
				userName.Value = commandArguments[0];
				firstName.Value = commandArguments[1];
				lastName.Value = commandArguments[2];
				phoneNumber.Value = commandArguments[3];
				eMail.Value = commandArguments[4];

				ViewState["PhoneNumber"] = Convert.ToInt64(commandArguments[3]);

				AddContact.Visible = false;
				btnEditContact.Visible = true;
			}

			if(e.CommandName == "DeleteContact")
			{
				long lPhoneNumber = Convert.ToInt64(e.CommandArgument);

				if(contactBookDB.DeleteContactFromDB(lPhoneNumber))
				{
					ShowRecords();
				}
				else
				{
					Response.Write("Cannot delete the Phone Number");
				}
			}
		}

		protected void btnEditContact_Click(object sender, EventArgs e)
		{
			Contact contact = new Contact();

			contact.Name = userName.Value.ToString();
			contact.FirstName = firstName.Value.ToString();
			contact.LastName = lastName.Value.ToString();
			contact.Email = eMail.Value.ToString();

			long lPhoneNumber;

			if(long.TryParse(phoneNumber.Value.ToString(), out lPhoneNumber))
			{
				contact.PhoneNumber = lPhoneNumber;

				if(contactBookDB.EditContactFromDB(contact, Convert.ToInt64(ViewState["PhoneNumber"])))
				{
					ShowRecords();

					userName.Value = "";
					firstName.Value = "";
					lastName.Value = "";
					eMail.Value = "";
					phoneNumber.Value = "";

					AddContact.Visible = true;
					btnEditContact.Visible = false;
				}
				else
				{
					Response.Write("Something Wrong Happened...");
				}
			}
			else
			{
				Response.Write("Please enter a correct mobile number...");
			}
		}
	}
}