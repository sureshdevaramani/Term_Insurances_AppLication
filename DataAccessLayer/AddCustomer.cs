using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AddCustomer
    {
       
            public static string maincon = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);


            public DataSet GetStates()
            {

                string sqlquery = "select * from STATE";
                SqlCommand com = new SqlCommand(sqlquery, con);
                SqlDataAdapter da = new SqlDataAdapter(com);

                con.Open();

                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            public DataSet GetGender()
            {
                string sqlGenderQuery = "select * from GENDER";
                SqlCommand command = new SqlCommand(sqlGenderQuery, con);
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);

                DataSet ds1 = new DataSet();
                dataadapter.Fill(ds1);
                return ds1;
            }

            public void SaveCustomer(string first_name, string last_name, int gender_id, DateTime DateOfBirth, string NRI_DATA, string Tobacco, string Email_id, string AddressLine_1, string AddressLine_2, int state_id, long phone_number,string Nominee_name)
            {

                SqlCommand command = new SqlCommand("spADDCUSTOMER", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@gender_id", gender_id);
                command.Parameters.AddWithValue("@date_of_birth", DateOfBirth);
                command.Parameters.AddWithValue("@nri_flag", NRI_DATA);
                command.Parameters.AddWithValue("@tobacco_user_flag", Tobacco);
                command.Parameters.AddWithValue("@email_id", Email_id);
                command.Parameters.AddWithValue("@address_1", AddressLine_1);
                command.Parameters.AddWithValue("@address_2", AddressLine_2);
                command.Parameters.AddWithValue("@state_id", state_id);
                command.Parameters.AddWithValue("@phone_number", phone_number);
                 command.Parameters.AddWithValue("@nominee_name", Nominee_name);

            con.Open();
                command.ExecuteNonQuery();


                con.Close();
            }
        }
    }


