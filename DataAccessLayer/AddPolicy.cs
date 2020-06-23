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
   public class AddPolicy
    {
        public static string maincon = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(maincon);
        private DataSet myds;
        private int rc;
        public int customer_id;
        public int Cover_Amount;
        public string Payout_option;
        public int Policy_term;
        public int Payment_term;
        public string Plan_type;
        public string Add_on;
        public int Policy_id;
       


        public int GetCustomerPK(long phone)
        {
            SqlCommand command = new SqlCommand("spGETPKCUSTOMER", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@phone_number", phone);

            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myds = new DataSet();
            myadapter.Fill(myds, "CUSTOMER");
            rc = myds.Tables["CUSTOMER"].Rows.Count;
            if (rc > 0)
            {
                this.customer_id = Convert.ToInt32(myds.Tables["CUSTOMER"].Rows[0][0]);

            }

            return customer_id;
        }

        public void AddPolicyDetails(int customer_id,
            int cover_amount,
            string payout_option,
            int policy_term,
           int payment_term,
            string plan_type,
          string add_on)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT into POLICY_DETAILS (customer_id,cover_amount,payout_option,policy_term,payment_term,plan_type,add_on,policy_start_date,policy_active_flag,policy_applied) values (@customer_id,@cover_amount,@payout_option,@policy_term,@payment_term,@plan_type,@add_on,@policy_start_date,@policy_active_flag,@policy_applied)", con);
            con.Open();

            sqlCmd.Parameters.AddWithValue("@customer_id", customer_id);

            sqlCmd.Parameters.AddWithValue("@cover_amount", cover_amount);
            sqlCmd.Parameters.AddWithValue("@payout_option", payout_option);
            sqlCmd.Parameters.AddWithValue("@policy_term", policy_term);
            sqlCmd.Parameters.AddWithValue("@payment_term", payment_term);
            sqlCmd.Parameters.AddWithValue("@plan_type", plan_type);
            sqlCmd.Parameters.AddWithValue("@add_on", add_on);
            sqlCmd.Parameters.AddWithValue("@policy_start_date", DateTime.Now);
            //sqlCmd.Parameters.AddWithValue("@policy_end_date", );
            sqlCmd.Parameters.AddWithValue("@policy_active_flag", 0);
            sqlCmd.Parameters.AddWithValue("@policy_applied", DateTime.Now);


            SqlDataReader sdr = sqlCmd.ExecuteReader();
            con.Close();
        }

        public void GetPolicyDetails()
        {
            string con = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("select policy_id,cover_amount,payout_option,policy_term,payment_term,plan_type,add_on from POLICY_DETAILS where policy_id=(Select max (policy_id) From POLICY_DETAILS)", sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.Read())
            {
                this.Policy_id = Convert.ToInt32(sdr["policy_id"]);
               this.Cover_Amount = Convert.ToInt32(sdr["cover_amount"]);
                this.Payout_option = sdr["payout_option"].ToString();
                this.Policy_term = Convert.ToInt32(sdr["policy_term"]);
                this.Payment_term = Convert.ToInt32(sdr["payment_term"]);
               this.Plan_type = sdr["plan_type"].ToString();
                this.Add_on = sdr["add_on"].ToString();


            }
            

            sqlCon.Close();

        }

    }
}
