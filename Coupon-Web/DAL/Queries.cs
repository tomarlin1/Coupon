using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Coupon_Web.DAL;


namespace Coupon_Web.DAL
{
    public class Queries
    {
        private SqlConnection _dbCon;

        public Queries(SqlConnection dbCon)
        {
            _dbCon = dbCon;
        }

        //
        public void Insert(String tableName, String[] values)
        {
            String query = "INSERT INTO [" + tableName + "] values ";
            int size = values.Length;

            //creating place holders in format: @0,@1,@2 etc...
            String sqlParam = "(";
            for (int i = 0; i < size; i++)
            {
                sqlParam += "@" + i;
                if (i < size - 1)
                    sqlParam += ",";
                else
                    sqlParam += ")";
            }
            query += sqlParam; //append parameters into query.

            //create sqlcommand.
            SqlCommand cmdSql = new SqlCommand(query, _dbCon);

            //replace the given values into placeholders.
            for (int i = 0; i < size; i++)
            {
                cmdSql.Parameters.AddWithValue("@" + i, values[i]);
            }
            //execute.
            cmdSql.ExecuteNonQuery();
        }

        //
        public void EditField(String tableName, String[] pKeyNames, String[] pKeyValues, String fieldName, String newValue)
        {
            int pkSize = pKeyNames.Length;
            String query = "UPDATE [" + tableName + "] " +
                           "SET " + fieldName + "=" + "@newVal " +
                           "WHERE ";
            String pkCond = "";

            //creating place holders in format: @0,@1,@2 etc...
            for (int i = 0; i < pkSize; i++)
            {
                pkCond += pKeyNames[i] + "=@" + i;
                if (i < pkSize - 1)
                    pkCond += " AND ";
            }
            query += pkCond;

            //create sqlcommand.
            SqlCommand cmdSql = new SqlCommand(query, _dbCon);

            //replace the given values into placeholders.
            for (int i = 0; i < pkSize; i++)
            {
                cmdSql.Parameters.AddWithValue("@" + i, pKeyValues[i]);
            }
            cmdSql.Parameters.AddWithValue("@newVal", newValue);

            //execute.
            cmdSql.ExecuteNonQuery();
        }

        //
        public void Delete(String tableName, String[] pKeyNames, String[] pKeyValues)
        {
            int pkSize = pKeyNames.Length;
            String query = "DELETE FROM [" + tableName + "] " +
                           "WHERE ";
            String pkCond = "";

            //creating place holders in format: @0,@1,@2 etc...
            for (int i = 0; i < pkSize; i++)
            {
                pkCond += pKeyNames[i] + "=@" + i;
                if (i < pkSize - 1)
                    pkCond += " AND ";
            }
            query += pkCond;

            //create sqlcommand.
            SqlCommand cmdSql = new SqlCommand(query, _dbCon);

            //replace the given values into placeholders.
            for (int i = 0; i < pkSize; i++)
            {
                cmdSql.Parameters.AddWithValue("@" + i, pKeyValues[i]);
            }

            //execute.
            cmdSql.ExecuteNonQuery();
        }

        //find row with PK pKeyName in tableName
        //in success return the line, else return NULL.
        public bool isExist(String tableName, String[] pKeyNames, String[] pKeyValues)
        {
            int pkSize = pKeyNames.Length;
            String query = "SELECT * FROM [" + tableName + "] " +
                           "WHERE ";
            String pkCond = "";

            //creating place holders in format: @0,@1,@2 etc...
            for (int i = 0; i < pkSize; i++)
            {
                pkCond += pKeyNames[i] + "=@" + i;
                if (i < pkSize - 1)
                    pkCond += " AND ";
            }
            query += pkCond;

            //create sqlcommand.
            SqlCommand cmdSql = new SqlCommand(query, _dbCon);

            //replace the given values into placeholders.
            for (int i = 0; i < pkSize; i++)
            {
                cmdSql.Parameters.AddWithValue("@" + i, pKeyValues[i]);
            }
            //execute.
            SqlDataReader reader = cmdSql.ExecuteReader();

            bool tmp = reader.HasRows;
            reader.Close();
            return tmp;
        }

    }
}