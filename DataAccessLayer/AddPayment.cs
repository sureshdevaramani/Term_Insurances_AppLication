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
   public class AddPayment
    {
        public static string con = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        SqlConnection sqlCon = new SqlConnection(con);

        public int Cover_Amount;
        public string Plan_Type;
        public string Add_on;
        public int policy_id;


        public void GetCobverAmount()
        {




            sqlCon.Open();



            SqlCommand sqlCmd = new SqlCommand("select policy_id,cover_amount,payout_option,policy_term,payment_term,plan_type,add_on from POLICY_DETAILS where policy_id=(Select max (policy_id) From POLICY_DETAILS)", sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();

            sdr.Read();
            {
                this.Cover_Amount = Convert.ToInt32(sdr["cover_amount"]);

                this.Plan_Type = sdr["plan_type"].ToString();
                this.Add_on = sdr["add_on"].ToString();
                this.policy_id = Convert.ToInt32(sdr["policy_id"]);

            }


            sqlCon.Close();
        }
        public void AddPaymentDetails(int policy_id, string payment_mode, double premium)
        {
            sqlCon.Open();
            SqlCommand sqlCmd1 = new SqlCommand("INSERT into POLICY_PAYMENT (policy_id,payment_mode,payment_date,policy_premium) values (@policy_id,@payment_mode,@payment_date,@policy_premium)", sqlCon);
            //sqlCmd1.CommandType = CommandType.StoredProcedure;

            sqlCmd1.Parameters.AddWithValue("@policy_id", policy_id);
            sqlCmd1.Parameters.AddWithValue("@payment_mode", payment_mode);
            sqlCmd1.Parameters.AddWithValue("@payment_date", DateTime.Now);
            sqlCmd1.Parameters.AddWithValue("@policy_premium", premium);

            SqlCommand sqlCmd2 = new SqlCommand("UPDATE POLICY_DETAILS SET policy_start_date=@policy_start_date,policy_active_flag=@policy_active_flag where policy_id=@policy_id", sqlCon);

            sqlCmd2.Parameters.AddWithValue("@policy_id", policy_id);
            sqlCmd2.Parameters.AddWithValue("@policy_start_date", DateTime.Now);
            sqlCmd2.Parameters.AddWithValue("@policy_active_flag", 1);

            sqlCmd1.ExecuteNonQuery();

            sqlCmd2.ExecuteNonQuery();
        }
    }
}
