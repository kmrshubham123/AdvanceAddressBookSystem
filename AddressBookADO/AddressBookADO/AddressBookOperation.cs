using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO
{
    /// <summary>
    /// setup the connection from Address Book database
    /// </summary>
    class AddressBookOperation 
    {
        public static string connectionString = @"Data Source=DESKTOP-9FUO12F;Initial Catalog=AddressBook_Service;Integrated Security=True";

        /// <summary>
        /// Method to ShowTable
        /// </summary>
        public void GetAllData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try //When an exception occurs, the control will move to the catch block
            {

                AddressBook book = new AddressBook();
                using (sqlConnection)
                {
                    string query = @"select * from AddressBook";
                    //SqlCommand is interact with reational database or stored procedure to execute against SQL Server datdabase.
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    //SqlDataReader Provides a way of reading a forward-only stream of rows from a SQL Server database.
                    SqlDataReader dr = cmd.ExecuteReader(); //Returns the sqlDataReader Object.
                    if (dr.HasRows) //Gets the value that indicates whether the SQLDataReader contains one or more rows.
                    {               //Returns:true if the data SQLDataReader contains one or more rows; otherwise false
                        while (dr.Read())
                        {
                            book.FirstName = dr.GetString(0);
                            book.LastName = dr.GetString(1);
                            book.address = dr.GetString(2);
                            book.City = dr.GetString(3);
                            book.State = dr.GetString(4);
                            book.Zip = dr.GetInt32(5);
                            book.PhoneNumber = dr.GetString(6);
                            book.Email = dr.GetString(7);
                           
                            Console.WriteLine(book.FirstName + " " + book.LastName + " " + book.address + " " + book.City + " " + book.State + " " + book.Zip + " " + book.PhoneNumber + " " + book.Email);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    //close data reader
                    dr.Close();
                    //this.sqlConnection.Close();
                }
            }
            catch (Exception e) //Catch/Handle the exception  
            {
                Console.WriteLine(e.Message);
            }
            finally //this block of code will always get executed whether an exception occurs or not.
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// Create a add method 
        /// using Store Procedure
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool AddContact(AddressBook book)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                using (sqlConnection)
                {
                    SqlCommand command = new SqlCommand("SpAddressBook", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", book.FirstName);
                    command.Parameters.AddWithValue("@LastName", book.LastName);
                    command.Parameters.AddWithValue("@address", book.address);
                    command.Parameters.AddWithValue("@City", book.City);
                    command.Parameters.AddWithValue("@State", book.State);
                    command.Parameters.AddWithValue("@Zip", book.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", book.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", book.Email);
                    command.Parameters.AddWithValue("@Type", book.Type);
                    sqlConnection.Open();
                    var result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Data add successful");
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();

            }
        }

    }

}