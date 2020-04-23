using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParkingBooking.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string connectionString;
        public Service1()
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            connectionString = connStr;
        }
        public IEnumerable<BookingsTable> GetBookings(bool get)
        {
            if(get==false)
            {
                return null;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT [BookingID]
                                              ,[FullName]
                                              ,[Email]
                                              ,[Phone]
                                              ,[CarPlate#]
                                              ,[BookedDates]
                                              ,[NumberofDaysBooked]
                                              ,[BookedOn]
                                          FROM [dbo].[BookingsTable]";
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    BookingsTable[] pocos = new BookingsTable[100];
                    int index = 0;
                    while(reader.Read())
                    {
                        BookingsTable poco = new BookingsTable();

                        poco.BookingId = reader.GetGuid(0);
                        poco.FullName = reader.GetString(1);
                        poco.Email = reader.GetString(2);
                        poco.Phone = reader.GetString(3);
                        poco.CarPlate = reader.GetString(4);
                        poco.BookedDates = reader.GetString(5);
                        poco.NumberofDaysBooked = reader.GetInt32(6);
                        poco.BookedOn = reader.GetDateTime(7);

                        pocos[index] = poco;
                        index++;

                    }

                    conn.Close();

                    return pocos.Where(a => a != null).ToList();
                }
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue = $"Hello {composite.StringValue}";
            }
            return composite;
        }

    }
}
