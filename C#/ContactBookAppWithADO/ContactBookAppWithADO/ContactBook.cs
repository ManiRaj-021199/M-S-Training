using System;

namespace ContactBookAppWithADO
{
	class ContactBook
	{
		ContactBookDB contactBookDb;

		public ContactBook()
		{
			contactBookDb = new ContactBookDB();
		}

		public void ViewMenu()
		{
			int nUserOption;

			Console.WriteLine("\nWhat you like to do?\n");

			Console.WriteLine("1. Add New Contact");
			Console.WriteLine("2. Edit Contact");
			Console.WriteLine("3. Delete Contact");
			Console.WriteLine("4. Search Contact");
			Console.WriteLine("5. View All Contacts");
			Console.WriteLine("6. Quit");

			Console.Write("\nChoose your Option: ");

			int.TryParse(Console.ReadLine(), out nUserOption);

			if(nUserOption > 0)
			{
				switch(nUserOption)
				{
					case 1:
						AddNewContact(new Contact());
						ViewAllContacts();
						break;
					case 2:
						EditContact();
						ViewAllContacts();
						break;
					case 3:
						DeleteContact();
						ViewAllContacts();
						break;
					case 4:
						SearchContact();
						break;
					case 5:
						ViewAllContacts();
						break;
					case 6:
						return;
					default:
						Console.WriteLine("\nYour Choice was Invalid.Try again...");
						break;
				}
			}
			else
			{
				Console.WriteLine("Give a Correct Input...");
			}

			ViewMenu();
		}

		public void AddNewContact(Contact contact)
		{
			Console.WriteLine("\nEnter Details to Add New Contact:");
			long lTempPhoneNumber;

			Console.Write("Name\t\t: ");
			contact.Name = Console.ReadLine();
			Console.Write("First Name\t: ");
			contact.FirstName = Console.ReadLine();
			Console.Write("Last Name\t: ");
			contact.LastName = Console.ReadLine();
			Console.Write("Phone Number\t: ");
			Int64.TryParse(Console.ReadLine(), out lTempPhoneNumber);

			if(lTempPhoneNumber != 0)
			{
				contact.PhoneNumber = lTempPhoneNumber;
			}
			else
			{
				Console.WriteLine("\nInvalid Phone Number...");
				AddNewContact(new Contact());

				return;
			}

			Console.Write("Email\t\t: ");
			contact.Email = Console.ReadLine();

			contactBookDb.AddContactToDB(contact);
		}

		public void EditContact()
		{
			long lPhoneNumber;

			Console.Write("\nEnter Mobile Number to Edit Contact: ");
			Int64.TryParse(Console.ReadLine(), out lPhoneNumber);

			contactBookDb.EditContactFromDB(lPhoneNumber);
		}

		public void DeleteContact()
		{
			long lPhoneNumber;

			Console.Write("\nEnter Mobile Number to Delete Contact: ");
			Int64.TryParse(Console.ReadLine(), out lPhoneNumber);

			contactBookDb.DeleteContactFromDB(lPhoneNumber);
		}

		public void SearchContact()
		{
			long lPhoneNumber;
			Console.Write("\nEnter Mobile Number to Search Contact: ");

			Int64.TryParse(Console.ReadLine(), out lPhoneNumber);

			contactBookDb.SearchContactFromDB(lPhoneNumber);
		}

		public void ViewAllContacts()
		{
			contactBookDb.ViewAllContactsFromDB();
		}
	}
}
