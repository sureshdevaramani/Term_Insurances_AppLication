using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccessLayer
{
    public class AddDocumentDetails
    {
        public int Policy_id;
        public void AddDocuments(string addressSelected, string FileName, string addressSelected1, string FileName1)
        {
            string con = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);

            sqlCon.Open();


            SqlCommand sqlCmd = new SqlCommand("select policy_id from POLICY_DETAILS where policy_id=(Select max (policy_id) From POLICY_DETAILS)", sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
                       sdr.Read();
            {

                this.Policy_id = Convert.ToInt32(sdr["policy_id"]);

            }

            sqlCon.Close();

            SqlCommand sqlCmd1 = new SqlCommand("INSERT into DOCUMENTS (policy_id,document_type,document_proof,document_type2,document_proof2) values (@policy_id,@document_type,@document_proof,@document_type2,@document_proof2)", sqlCon);
            
            sqlCmd1.Parameters.AddWithValue("@policy_id", Policy_id);
            sqlCmd1.Parameters.AddWithValue("@document_type", addressSelected);
            sqlCmd1.Parameters.AddWithValue("@document_proof", FileName);
            sqlCmd1.Parameters.AddWithValue("@document_type2", addressSelected1);
            sqlCmd1.Parameters.AddWithValue("@document_proof2", FileName1);
            sqlCon.Open();
            sqlCmd1.ExecuteNonQuery();
            sqlCon.Close();
        }
    }
}
