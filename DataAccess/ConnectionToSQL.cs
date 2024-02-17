using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DataAccess
{
    public class ConnectionToSQL
    {
        private readonly String conecctionString;
        private String server = "BD-QUITO";
        private String dataBase = "QuitoTaller";
        private String user = "sa";
        private String password = "P@ssw0rd";

        public String GetDataBase()
        {
            return dataBase;
        }

        public String GetUser()
        {
            return user;
        }

        public String GetPassword()
        {
            return password;
        }

        public ConnectionToSQL(){
            conecctionString = $"Data Source={server};user id={user};password={password};initial catalog={dataBase};Persist Security info = true";
        }
        protected SqlConnection GetConnection()
        {
           return new SqlConnection(conecctionString);
           
        }
    }
}
