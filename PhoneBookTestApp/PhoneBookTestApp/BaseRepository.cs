using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
   public class BaseRepository
    {
        protected SQLiteConnection sqlConn;
        public BaseRepository()
        {
            sqlConn = DatabaseUtil.GetConnection();
        }
        protected async Task<DataTable>  GetRecordAsync(string commandText, SQLiteParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (var command = sqlConn.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    var dataReader = await command.ExecuteReaderAsync();
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected async Task<int> ExecuteDataFromQuery(string commandText, SQLiteParameter[] parameters = null)
        {
            int dataReader = 0;
            try
            {
                using (var command = sqlConn.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    dataReader = await command.ExecuteNonQueryAsync();
                }
                return dataReader;
            }
            catch (Exception ex)
            
            {
                throw ex;
            }
        }
    }
}
