using System;
using System.Web.UI.WebControls;

namespace ContactBookAppWithASP
{
	public partial class ContactBook : System.Web.UI.Page
	{
		ContactBookDB contactBookDB;

		protected void Page_Load(object sender, EventArgs e)
		{
			contactBookDB = new ContactBookDB();
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

				userName.Value = "";
				firstName.Value = "";
				lastName.Value = "";
				eMail.Value = "";
				phoneNumber.Value = "";

				if(contactBookDB.AddContactToDB(contact))
				{
					Response.Write("Data Added...");
				}
				else
				{
					Response.Write("Something Wrong Happend...");
				}
			}
			else
			{
				Response.Write("Please enter a correct mobile number...");
			}
		}
	}
}