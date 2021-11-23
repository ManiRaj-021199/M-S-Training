using System;
using System.Collections.Generic;

namespace ContactBookConsoleApp
{
	class ContactBook
	{
		List<Contact> lstAllContacts;

		public ContactBook()
		{
			lstAllContacts = new List<Contact>();
		}

		public void ViewMenu()
		{
			List<int> lstUserOptions = new List<int>{ 1, 2, 3, 4, 5, 6 };
			int iUserOption;

			Console.WriteLine("\nWhat you like to do?\n");

			Console.WriteLine("1. Add New Contact");
			Console.WriteLine("2. Edit Contact");
			Console.WriteLine("3. Delete Contact");
			Console.WriteLine("4. Search Contact");
			Console.WriteLine("5. View All Contacts");
			Console.WriteLine("6. Quit");

			Console.Write("\nChoose your Option: ");
			try
			{
				iUserOption = Convert.ToInt32(Console.ReadLine());

				if(lstUserOptions.Contains(iUserOption))
				{
					switch(iUserOption)
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
					}
				}
				else
				{
					Console.WriteLine("\nYour Choice was Invalid.Try again...");
					ViewMenu();
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("\nYour Choice was Invalid.Try again...");
				ViewMenu();
			}
		}

		public void AddNewContact(Contact contact)
		{
			Console.WriteLine("\nEnter Details to Add New Contact:");

			try
			{
				Console.Write("Name\t\t: ");
				contact.sName = Console.ReadLine();
				Console.Write("First Name\t: ");
				contact.sFirstName = Console.ReadLine();
				Console.Write("Last Name\t: ");
				contact.sLastName = Console.ReadLine();
				Console.Write("Phone Number\t: ");
				contact.lPhoneNumber = Convert.ToInt64(Console.ReadLine());
				Console.Write("Email\t\t: ");
				contact.sEmail = Console.ReadLine();

				lstAllContacts.Add(contact);

				Console.WriteLine("\nContact Added Successfully...\n\n");
			}
			catch(Exception e)
			{
				Console.WriteLine("\nSomething went Wrong.Try Again...");

				AddNewContact(new Contact());
			}
			finally
			{
				ViewMenu();
			}
		}

		public int GetContactIndex()
		{
			long lPhoneNumber;
			int nIndex = -1;

			try
			{
				lPhoneNumber = Convert.ToInt64(Console.ReadLine());

				for(int i = 0; i < lstAllContacts.Count; i++)
				{
					if(lstAllContacts[i].lPhoneNumber == lPhoneNumber)
					{
						nIndex = i;
						break;
					}
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("Something went Wrong. Try again...");
			}

			return nIndex;
		}

		public void EditContact()
		{

			Console.Write("\nEnter Mobile Number to Edit Contact: ");

			try
			{
				int iIdForEditableContact = GetContactIndex();

				if(iIdForEditableContact != -1)
				{
					List<int> lstUserOptions = new List<int> { 1, 2, 3, 4, 5 };

					Console.WriteLine($"\nContactDetails: ");
					Console.WriteLine($"Name\t: {lstAllContacts[iIdForEditableContact].sName}");
					Console.WriteLine($"First Name\t: {lstAllContacts[iIdForEditableContact].sFirstName}");
					Console.WriteLine($"Last Name\t: {lstAllContacts[iIdForEditableContact].sLastName}");
					Console.WriteLine($"Phone Number\t: {lstAllContacts[iIdForEditableContact].lPhoneNumber}");
					Console.WriteLine($"EMail\t: {lstAllContacts[iIdForEditableContact].sEmail}");

					Console.WriteLine("\nWhich field you want to Edit: ");
					Console.WriteLine("1. Name");
					Console.WriteLine("2. First Name");
					Console.WriteLine("3. Last Name");
					Console.WriteLine("4. Phone Number");
					Console.WriteLine("5. Email");

					try
					{
						Console.Write("\nChoose your Option: ");
						int iUserOption = Convert.ToInt32(Console.ReadLine());

						if(lstUserOptions.Contains(iUserOption))
						{
							switch(iUserOption)
							{
								case 1:
									Console.Write("Name\t\t: ");
									string sName = Console.ReadLine();
									lstAllContacts[iIdForEditableContact].sName = sName;
									break;
								case 2:
									Console.Write("First Name\t: ");
									string sFirstName = Console.ReadLine();
									lstAllContacts[iIdForEditableContact].sFirstName = sFirstName;
									break;
								case 3:
									Console.Write("Last Name\t: ");
									string sLastName = Console.ReadLine();
									lstAllContacts[iIdForEditableContact].sLastName = sLastName;
									break;
								case 4:
									Console.Write("Phone Number\t: ");
									long newPhoneNumber = Convert.ToInt64(Console.ReadLine());
								    lstAllContacts[iIdForEditableContact].lPhoneNumber = newPhoneNumber;
									break;
								case 5:
									Console.Write("Email\t\t: ");
									string  sEmail = Console.ReadLine();
									lstAllContacts[iIdForEditableContact].sEmail = sEmail;
									break;
							}
							Console.WriteLine("Data Modified...");
						}
						else
						{
							Console.WriteLine("\nInvalid Option.Try again...");
						}
					}
					catch(Exception e)
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
			catch(Exception e)
			{
				Console.WriteLine("\nSomething went Wrong.Try Again...");
				EditContact();
			}
		}

		public void DeleteContact()
		{
			try
			{
				Console.Write("\nEnter Mobile Number to Delete Contact: ");

				int nIndex = GetContactIndex();
				
				if(nIndex >= 0)
				{
					lstAllContacts.RemoveAt(nIndex);
					Console.WriteLine("\nData Deleted Successfully.\n");
				}
				else
				{
					Console.WriteLine("\nNo Records Found...\n");
				}

				ViewMenu();
			}
			catch(Exception e)
			{
				Console.WriteLine("Something went wrong.Try again...");
				DeleteContact();
			}
		}

		public void SearchContact()
		{
			try
			{
				Console.Write("\nEnter Mobile Number to Search Contact: ");

				int iIdForEditableContact = GetContactIndex();
				if(iIdForEditableContact != -1)
				{
					Console.WriteLine($"\nContactDetails: ");
					Console.WriteLine($"Name\t\t: {lstAllContacts[iIdForEditableContact].sName}");
					Console.WriteLine($"First Name\t: {lstAllContacts[iIdForEditableContact].sFirstName}");
					Console.WriteLine($"Last Name\t: {lstAllContacts[iIdForEditableContact].sLastName}");
					Console.WriteLine($"Phone Number\t: {lstAllContacts[iIdForEditableContact].lPhoneNumber}");
					Console.WriteLine($"EMail\t\t: {lstAllContacts[iIdForEditableContact].sEmail}");
				}
				else
				{
					Console.WriteLine("\nNo Records Found...\n");
				}

				ViewMenu();
			}
			catch(Exception e)
			{
				Console.WriteLine("\nInvalid Selection. Try again...");
				SearchContact();
			}
		}

		public void ViewAllContacts()
		{
			if(lstAllContacts.Count < 1)
			{
				Console.WriteLine("\nNo Records Found.\n");
			}
			int count = 1;

			for(int i = 0; i < lstAllContacts.Count; i++)
			{
				Console.WriteLine($"\nContact: {count}");
				Console.WriteLine($"Name\t: {lstAllContacts[i].sName}");
				Console.WriteLine($"First Name\t: {lstAllContacts[i].sFirstName}");
				Console.WriteLine($"Last Name\t: {lstAllContacts[i].sLastName}");
				Console.WriteLine($"Phone Number\t: {lstAllContacts[i].lPhoneNumber}");
				Console.WriteLine($"EMail\t: {lstAllContacts[i].sEmail}");

				count += 1;
			}

			ViewMenu();
		}
	}
}
