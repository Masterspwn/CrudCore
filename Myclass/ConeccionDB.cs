using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;



namespace CrudCore.Myclass
{
    public class ConeccionDB
    {
        public MySqlConnection myconnection;
        public ConeccionDB()
        {
            string conString = "server=localhost;username= root;password= root;database=EmpreAdmin";
            myconnection = new MySqlConnection(conString);
            myconnection.Open();  

        }
        public DataTable GetData(string _sqlCommand )
        {
            MySqlCommand command = new MySqlCommand( _sqlCommand, myconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter( command ); 
            DataTable dt = new DataTable();
            adapter.Fill( dt ); 
            return dt;  

        }
        public void ExecuteQuery(string _sqlCommand) 
        { 
            MySqlCommand command = new MySqlCommand( "", myconnection);
            command.CommandText = _sqlCommand;
            command.CommandType = CommandType.Text; 
        
            command.ExecuteNonQuery();

        
        }


    }
}
