using System.Collections.Generic;

namespace DBAndAPIProject
{
    public class DBUtils
    {
        private static string connStr = GetTestData.Get("ConnectionString", "DataBaseQA");
        private System.Data.SqlClient.SqlConnection sqlConnection =
            new System.Data.SqlClient.SqlConnection(connStr);
        public void InsertNbrbTB(СurrencyModel сurrencyModel)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = $"INSERT INTO NbrbTable (Cur_ID, Cur_ParentID, Cur_Code, Cur_Abbreviation, Cur_Name, Cur_Name_Bel, " +
                "Cur_Name_Eng, Cur_QuotName, Cur_QuotName_Bel, Cur_QuotName_Eng, Cur_NameMulti, Cur_Name_BelMulti, " +
                "Cur_Name_EngMulti, Cur_Scale, Cur_Periodicity, Cur_OfficialRate, Cur_DateStart, Cur_DateEnd, Cur_Date) VALUES (@Cur_ID, @Cur_ParentID, @Cur_Code, @Cur_Abbreviation, @Cur_Name, @Cur_Name_Bel, " +
                "@Cur_Name_Eng, @Cur_QuotName, @Cur_QuotName_Bel, @Cur_QuotName_Eng, @Cur_NameMulti, @Cur_Name_BelMulti, " +
                "@Cur_Name_EngMulti, @Cur_Scale, @Cur_Periodicity, @Cur_OfficialRate, @Cur_DateStart, @Cur_DateEnd, @Cur_Date);";
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@Cur_ID", сurrencyModel.Cur_ID);
            cmd.Parameters.Add("@Cur_ParentID", сurrencyModel.Cur_ParentID);
            cmd.Parameters.Add("@Cur_Code", сurrencyModel.Cur_Code!=null?сurrencyModel.Cur_Code:"");
            cmd.Parameters.Add("@Cur_Abbreviation", сurrencyModel.Cur_Abbreviation != null ? сurrencyModel.Cur_Abbreviation : "");
            cmd.Parameters.Add("@Cur_Name", сurrencyModel.Cur_Name != null ? сurrencyModel.Cur_Name : ""); 
            cmd.Parameters.Add("@Cur_Name_Bel", сurrencyModel.Cur_Name_Bel != null ? сurrencyModel.Cur_Name_Bel : "");
            cmd.Parameters.Add("@Cur_Name_Eng", сurrencyModel.Cur_Name_Eng != null ? сurrencyModel.Cur_Name_Eng : "");
            cmd.Parameters.Add("@Cur_QuotName", сurrencyModel.Cur_QuotName != null ? сurrencyModel.Cur_QuotName : "");
            cmd.Parameters.Add("@Cur_QuotName_Bel", сurrencyModel.Cur_QuotName_Bel != null ? сurrencyModel.Cur_QuotName_Bel : "");
            cmd.Parameters.Add("@Cur_QuotName_Eng", сurrencyModel.Cur_QuotName_Eng != null ? сurrencyModel.Cur_QuotName_Eng : "");
            cmd.Parameters.Add("@Cur_NameMulti", сurrencyModel.Cur_NameMulti != null ? сurrencyModel.Cur_NameMulti : "");
            cmd.Parameters.Add("@Cur_Name_BelMulti", сurrencyModel.Cur_Name_BelMulti != null ? сurrencyModel.Cur_Name_BelMulti : "");
            cmd.Parameters.Add("@Cur_Name_EngMulti", сurrencyModel.Cur_Name_EngMulti != null ? сurrencyModel.Cur_Name_EngMulti : "");
            cmd.Parameters.Add("@Cur_Scale", сurrencyModel.Cur_Scale != null ? сurrencyModel.Cur_Scale : "");
            cmd.Parameters.Add("@Cur_Periodicity", сurrencyModel.Cur_Periodicity != null ? сurrencyModel.Cur_Periodicity : "");
            cmd.Parameters.Add("@Cur_OfficialRate", сurrencyModel.Cur_OfficialRate != null ? сurrencyModel.Cur_OfficialRate : "");
            if (сurrencyModel.Cur_DateStart > System.DateTime.MinValue)
            cmd.Parameters.Add("@Cur_DateStart", сurrencyModel.Cur_DateStart);
            else
            cmd.Parameters.Add("@Cur_DateStart", "");
            if (сurrencyModel.Cur_DateStart > System.DateTime.MinValue)
            cmd.Parameters.Add("@Cur_DateEnd", сurrencyModel.Cur_DateEnd);
            else
            cmd.Parameters.Add("@Cur_DateEnd", "");
            if (сurrencyModel.Cur_DateStart > System.DateTime.MinValue)
                cmd.Parameters.Add("@Cur_Date", сurrencyModel.Cur_DateEnd);
            else
                cmd.Parameters.Add("@Cur_Date", "");

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public int InsertManyCurrenciesToNbrbTB(List<СurrencyModel> сurrencyModels)
        {
            int count = 0;
            foreach (СurrencyModel currencyModel in сurrencyModels)
            {
                InsertNbrbTB(currencyModel);
                count++;
            }
            return count;
        }

        public void TruncateTB(string table)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = $"TRUNCATE TABLE {table};";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
