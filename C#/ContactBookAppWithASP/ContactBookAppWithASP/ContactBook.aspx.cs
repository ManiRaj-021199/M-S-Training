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

			gvContactBookTable.DataSource = ds;
			gvContactBookTable.DataBind();
		}

		protected void BtnAddContact_Click(object sender, EventArgs e)
		{
			Contact contact = new Contact();

			contact.Name = txtUserName.Value.ToString();
			contact.FirstName = txtFirstName.Value.ToString();
			contact.LastName = txtLastName.Value.ToString();
			contact.Email = txtEMail.Value.ToString();

			long lPhoneNumber;

			if(long.TryParse(txtPhoneNumber.Value.ToString(), out lPhoneNumber))
			{
				contact.PhoneNumber = lPhoneNumber;

				if(contactBookDB.AddContactToDB(contact))
				{
					ShowRecords();

					txtUserName.Value = "";
					txtFirstName.Value = "";
					txtLastName.Value = "";
					txtEMail.Value = "";
					txtPhoneNumber.Value = "";
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

		protected void gvContactBookTable_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if(e.CommandName == "EditContact")
			{
				string[] commandArguments = e.CommandArgument.ToString().Split(new char[] { ',' });
				txtUserName.Value = commandArguments[0];
				txtFirstName.Value = commandArguments[1];
				txtLastName.Value = commandArguments[2];
				txtPhoneNumber.Value = commandArguments[3];
				txtEMail.Value = commandArguments[4];

				ViewState["PhoneNumber"] = Convert.ToInt64(commandArguments[3]);

				btnAddContact.Visible = false;
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

		protected void BtnEditContact_Click(object sender, EventArgs e)
		{
			Contact contact = new Contact();

			contact.Name = txtUserName.Value.ToString();
			contact.FirstName = txtFirstName.Value.ToString();
			contact.LastName = txtLastName.Value.ToString();
			contact.Email = txtEMail.Value.ToString();

			long lPhoneNumber;

			if(long.TryParse(txtPhoneNumber.Value.ToString(), out lPhoneNumber))
			{
				contact.PhoneNumber = lPhoneNumber;

				if(contactBookDB.EditContactFromDB(contact, Convert.ToInt64(ViewState["PhoneNumber"])))
				{
					ShowRecords();

					txtUserName.Value = "";
					txtFirstName.Value = "";
					txtLastName.Value = "";
					txtEMail.Value = "";
					txtPhoneNumber.Value = "";

					btnAddContact.Visible = true;
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