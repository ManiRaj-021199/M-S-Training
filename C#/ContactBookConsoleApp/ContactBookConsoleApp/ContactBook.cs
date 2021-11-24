using System;
using System.Collections.Generic;

namespace ContactBookConsoleApp
{
	class ContactBook
	{
		List<Contact> Contacts;

		public ContactBook()
		{
			if(Contacts == null)
			{
				Contacts = new List<Contact>();
			}
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
						break;
					case 2:
						EditContact();
						break;
					case 3:
						DeleteContact();
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
						ViewMenu();
						break;
				}
			}
			else
			{
				Console.WriteLine("Give a Number Input...");
				ViewMenu();
			}
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

			Contacts.Add(contact);

			Console.WriteLine("\nContact Added Successfully...\n\n");
			ViewMenu();
		}

		public int GetContactIndex()
		{
			long lPhoneNumber;
			int nIndex = -1;

			Int64.TryParse(Console.ReadLine(), out lPhoneNumber);

			if(lPhoneNumber != 0)
			{
				for(int i = 0; i < Contacts.Count; i++)
				{
					if(Contacts[i].PhoneNumber == lPhoneNumber)
					{
						nIndex = i;
						break;
					}
				}
			}
			else
			{
				Console.WriteLine("Give a Correct Phone Number.");
			}

			return nIndex;
		}

		public void EditContact()
		{
			Console.Write("\nEnter Mobile Number to Edit Contact: ");

			int nIndex = GetContactIndex();

			if(nIndex != -1)
			{
				int nUserOption;

				Console.WriteLine($"\nContactDetails: ");
				Console.WriteLine($"Name\t: {Contacts[nIndex].Name}");
				Console.WriteLine($"First Name\t: {Contacts[nIndex].FirstName}");
				Console.WriteLine($"Last Name\t: {Contacts[nIndex].LastName}");
				Console.WriteLine($"Phone Number\t: {Contacts[nIndex].PhoneNumber}");
				Console.WriteLine($"EMail\t: {Contacts[nIndex].Email}");

				Console.WriteLine("\nWhich field you want to Edit: ");
				Console.WriteLine("1. Name");
				Console.WriteLine("2. First Name");
				Console.WriteLine("3. Last Name");
				Console.WriteLine("4. Phone Number");
				Console.WriteLine("5. Email");

				Console.Write("\nChoose your Option: ");
				int.TryParse(Console.ReadLine(), out nUserOption);

				if(nUserOption > 0)
				{
					switch(nUserOption)
					{
						case 1:
							Console.Write("Name\t\t: ");
							string sName = Console.ReadLine();
							Contacts[nIndex].Name = sName;
							Console.WriteLine("Data Modified...");
							break;
						case 2:
							Console.Write("First Name\t: ");
							string sFirstName = Console.ReadLine();
							Contacts[nIndex].FirstName = sFirstName;
							Console.WriteLine("Data Modified...");
							break;
						case 3:
							Console.Write("Last Name\t: ");
							string sLastName = Console.ReadLine();
							Contacts[nIndex].LastName = sLastName;
							Console.WriteLine("Data Modified...");
							break;
						case 4:
							Console.Write("Phone Number\t: ");
							long newPhoneNumber = Convert.ToInt64(Console.ReadLine());
						    Contacts[nIndex].PhoneNumber = newPhoneNumber;
							Console.WriteLine("Data Modified...");
							break;
						case 5:
							Console.Write("Email\t\t: ");
							string  sEmail = Console.ReadLine();
							Contacts[nIndex].Email = sEmail;
							Console.WriteLine("Data Modified...");
							break;
						default:
							Console.WriteLine("\nInvalid Option.Try again...");
							EditContact();
							break;
					}
				}
				else
				{
					Console.WriteLine("\nInvalid Option.Try again...");
					EditContact();
				}
			}
			else
			{
				Console.WriteLine("\nNo Records Found...\n");
			}
			ViewMenu();
		}

		public void DeleteContact()
		{
			Console.Write("\nEnter Mobile Number to Delete Contact: ");

			int nIndex = GetContactIndex();
				
			if(!(nIndex < 0))
			{
				Contacts.RemoveAt(nIndex);
				Console.WriteLine("\nData Deleted Successfully.\n");
			}
			else
			{
				Console.WriteLine("\nNo Records Found...\n");
			}

			ViewMenu();
		}

		public void SearchContact()
		{
			Console.Write("\nEnter Mobile Number to Search Contact: ");

			int nIndex = GetContactIndex();
			if(nIndex != -1)
			{
				Console.WriteLine($"\nContactDetails: ");
				Console.WriteLine($"Name\t\t: {Contacts[nIndex].Name}");
				Console.WriteLine($"First Name\t: {Contacts[nIndex].FirstName}");
				Console.WriteLine($"Last Name\t: {Contacts[nIndex].LastName}");
				Console.WriteLine($"Phone Number\t: {Contacts[nIndex].PhoneNumber}");
				Console.WriteLine($"EMail\t\t: {Contacts[nIndex].Email}");
			}
			else
			{
				Console.WriteLine("\nNo Records Found...\n");
			}
			ViewMenu();
		}

		public void ViewAllContacts()
		{
			if(Contacts.Count < 1)
			{
				Console.WriteLine("\nNo Records Found.\n");
			}
			else
			{
				int count = 1;

				for(int i = 0; i < Contacts.Count; i++)
				{
					Console.WriteLine($"\nContact: {count}");
					Console.WriteLine($"Name\t: {Contacts[i].Name}");
					Console.WriteLine($"First Name\t: {Contacts[i].FirstName}");
					Console.WriteLine($"Last Name\t: {Contacts[i].LastName}");
					Console.WriteLine($"Phone Number\t: {Contacts[i].PhoneNumber}");
					Console.WriteLine($"EMail\t: {Contacts[i].Email}");

					count += 1;
				}
			}

			ViewMenu();
		}
	}
}
