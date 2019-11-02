using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ExamenEnrique.Classes
{
    public class UserDS
    {
        private readonly SQLClient _client;
        private static UserDS _instance;

        private UserDS(string cStr)
        {
            _client = new SQLClient(cStr);
        }

        public static UserDS getInstance(string cStr)
        {
            if (_instance == null) _instance= new UserDS(cStr);
            return _instance;
        }

        

        public bool getUser(string email)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.connection,
                        CommandText = "getuser",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@user", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = email
                    };
                    

                    command.Parameters.Add(par1);

                    command.ExecuteNonQuery();

                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var user = new User
                        {
                            _mail = dataReader["email"].ToString(),
                            _password = (dataReader["pwd"].ToString()),

                        };
                        return true;
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                _client.Close();
            }

            return false;


        }
            
        public bool AddUser(User user)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.connection,
                        CommandText = "addUser",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@email", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.getMail()
                    };

                    var par2 = new SqlParameter("@pwd", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.getPWD()
                    };
                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };


                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public User loginUser(string email, string pwd)
        {
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.connection,
                        CommandText = "logUser",
                        CommandType = CommandType.StoredProcedure
                    };
                    var par1 = new SqlParameter("@email", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = email
                    };

                    var par2 = new SqlParameter("@pwd", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = pwd
                    };
                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };


                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var user = new User
                        {
                            _mail = dataReader["email"].ToString(),
                            _password = (dataReader["pwd"].ToString()),
                            
                        };
                        return user;
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                _client.Close();
            }

            return null;
        }

        public List<string> getCities(string user)
        {
            var result = new List<string>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.connection,
                        CommandText = "getcity",
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result.Add(dataReader["city"].ToString());
                            
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                _client.Close();
            }

            return result;
        }
    }
}
