using System;
using System.Data.SqlClient;

namespace ContactBookAppWithASP
{
	class ContactBookDB
	{
		SqlConnection con;

		public ContactBookDB()
		{
			con = new SqlConnection("data source=.; database=ContactBookDB; integrated security=SSPI");
		}

		public bool AddContactToDB(Contact contact)
		{
			SqlCommand insertQuery = new SqlCommand($"INSERT INTO Contacts(Name, FirstName, LastName, PhoneNumber, Email) VALUES ('{contact.Name}', '{contact.FirstName}', '{contact.LastName}', {contact.PhoneNumber}, '{contact.Email}')", con);

			try
			{
				con.Open();
				insertQuery.ExecuteNonQuery();
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				con.Close();
			}
		}

		public SqlDataAdapter ViewAllContactsFromDB()
		{
			SqlDataAdapter selectQuery = new SqlDataAdapter("SELECT * FROM Contacts", con);
			return selectQuery;
		}

		public bool EditContactFromDB(Contact contact, long phone)
		{
			SqlCommand contactUpdateQuery = new SqlCommand($"UPDATE Contacts SET Name='{contact.Name}', FirstName='{contact.FirstName}', LastName='{contact.LastName}', PhoneNumber={contact.PhoneNumber}, EMail='{contact.Email}' WHERE PhoneNumber={phone}", con);

			try
			{
				con.Open();
				contactUpdateQuery.ExecuteNonQuery();
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				con.Close();
			}
		}

		public bool DeleteContactFromDB(long phone)
		{
			SqlCommand deleteQuery = new SqlCommand($"DELETE FROM Contacts WHERE PhoneNumber={phone}", con);

			try
			{
				con.Open();
				deleteQuery.ExecuteNonQuery();
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				con.Close();
			}
		}

		/*
		public void SearchContactFromDB(long phone)
		{
			SqlCommand fetchDataQuery = new SqlCommand($"SELECT * FROM Contacts WHERE PhoneNumber={phone}", con);

			try
			{
				con.Open();
				SqlDataReader sdr = fetchDataQuery.ExecuteReader();

				if(sdr.HasRows)
				{
					while(sdr.Read())
					{
						Console.WriteLine($"Name\t: {sdr["Name"]}");
						Console.WriteLine($"First Name\t: {sdr["FirstName"]}");
						Console.WriteLine($"Last Name\t: {sdr["LastName"]}");
						Console.WriteLine($"Phone Number\t: {sdr["PhoneNumber"]}");
						Console.WriteLine($"EMail\t: {sdr["Email"]}");
					}
				}
				else
				{
					Console.WriteLine("\nNo Contact Found...");
				}
			}
			catch
			{
				Console.WriteLine("\nCannot Search Contact.Try again...\n\n");
			}
			finally
			{
				con.Close();
			}
		}
		*/
	}
}