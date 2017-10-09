using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace Lances.Pages {
    public class WorkerDB {
        public OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["kpbof"]);
        public OracleCommand cmd;
        private string durability;

        public string CountDurability(int lance_no, int first_blow)
        {
            using (conn) {
                conn.Open();
                cmd = conn.CreateCommand(); cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(:lance_no) from heats where heat_no>:first_blow and lance_no=:lance_no order by heat_no desc";
                cmd.Parameters.Add(new OracleParameter("lance_no",lance_no));
                cmd.Parameters.Add(new OracleParameter("first_blow",first_blow));
                using (OracleDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows)
                        while (reader.Read()) {
                            durability = reader.GetValue(0).ToString();
                        }
                }
            }
            return durability;
        }
    }
}