using System;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MentorBilling.Database.DatabaseController
{
    public class PostgreSqlConnection : IDisposable
    {
        /// <summary>
        /// the main NpgsqlConnection
        /// </summary>
        public NpgsqlConnection connection = new NpgsqlConnection();

        /// <summary>
        /// The main constructor will set the connectionString to the default value
        /// </summary>
        public PostgreSqlConnection()
        {
            connection.ConnectionString = DatabaseConnectionSettings.DefaultConnectionString;
        }

        /// <summary>
        /// Alternate constructor with a given connectionString
        /// </summary>
        /// <param name="connectionString"></param>
        public PostgreSqlConnection(String connectionString)
        {
            connection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Alternate constructor with a GlobalConnectionSettings instance
        /// </summary>
        /// <param name="connectionSettings"></param>
        public PostgreSqlConnection(DatabaseConnectionSettings connectionSettings)
        {
            //we rebuilt the connection string to make sure that the connection string is valid
            connectionSettings.RebuiltConnectionString();
            connection.ConnectionString = connectionSettings.ConnectionString;
        }

        /// <summary>
        /// Can be used to avoid instantiation of a new object. This will close and reopen the connection with the new connection string.
        /// </summary>
        /// <param name="connectionString"></param>
        public void SetConnectionString(String connectionString)
        {
            connection.ConnectionString = connectionString;
            OpenConnection();
        }

        /// <summary>
        /// Opens connection to be used.
        /// </summary>
        /// <returns>True if connection was succesful, false if not</returns>
        public bool OpenConnection()
        {
            //we will atempt to close the connection if it is open
            CloseConnection();
            try
            {
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// this function will close the current connection
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open || connection.State == ConnectionState.Broken)
            {
                connection.Close();
            }
        }

        #region Execute
        #region NonQuery
        /// <summary>
        /// Executes a standard command upon the database with no return
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteNonQuery(String sql)
        {
            return Create(sql).ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a standard command with a single parameter upon the database with no return
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameter">the command parameter</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteNonQuery(String sql, NpgsqlParameter npgsqlParameter)
        {
            return Create(sql, npgsqlParameter).ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a standard command with multiple parameters upon the database with no return
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">the command parameter array</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteNonQuery(String sql, NpgsqlParameter[] npgsqlParameters)
        {
            return Create(sql, npgsqlParameters).ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a standard command with multiple parameters upon the database with no return
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">the command parameter list</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteNonQuery(String sql, List<NpgsqlParameter> npgsqlParameters)
        {
            return Create(sql, npgsqlParameters).ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a standard command with a single parameter upon the database with no return as part of a transaction
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameter">the command parameter</param>
        /// <param name="npgsqlTransaction">the active transaction</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteNonQuery(String sql, NpgsqlParameter npgsqlParameter, NpgsqlTransaction npgsqlTransaction)
        {
            return Create(sql, npgsqlParameter, npgsqlTransaction).ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a standard command with a multiple parameter upon the database with no return as part of a transaction
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">the command parameter array</param>
        /// <param name="npgsqlTransaction">the active transaction</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteNonQuery(String sql, NpgsqlParameter[] npgsqlParameters, NpgsqlTransaction npgsqlTransaction)
        {
            return Create(sql, npgsqlParameters, npgsqlTransaction).ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a standard command with a multiple parameter upon the database with no return as part of a transaction
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">the command parameter list</param>
        /// <param name="npgsqlTransaction">the active transaction</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteNonQuery(String sql, List<NpgsqlParameter> npgsqlParameters, NpgsqlTransaction npgsqlTransaction)
        {
            return Create(sql, npgsqlParameters, npgsqlTransaction).ExecuteNonQuery();
        }
        #endregion

        #region Reader
        /// <summary>
        /// executes a simple database command that retrieves a data reader
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <returns>a data reader</returns>
        public DbDataReader ExecuteReader(String sql)
        {
            return Create(sql).ExecuteReader();
        }

        /// <summary>
        /// executes a simple database command that retrieves a data table
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <returns>a data table</returns>
        public DataTable ExecuteReaderToDataTable(String sql)
        {
            DataTable dt = new DataTable();
            dt.Load(ExecuteReader(sql));
            return dt;
        }

        /// <summary>
        /// executes a simple database command with one parameter that retrieves a data reader 
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <param name="npgsqlParameter">the single query parameter</param>
        /// <returns>a data reader</returns>
        public DbDataReader ExecuteReader(String sql, NpgsqlParameter npgsqlParameter)
        {
            return Create(sql, npgsqlParameter).ExecuteReader();
        }

        /// <summary>
        /// executes a simple database command with one parameter that retrieves a data table
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <param name="npgsqlParameter">the single query parameter</param>
        /// <returns>a data table</returns>
        public DataTable ExecuteReaderToDataTable(String sql, NpgsqlParameter npgsqlParameter)
        {
            DataTable dt = new DataTable();
            dt.Load(ExecuteReader(sql, npgsqlParameter));
            return dt;
        }

        /// <summary>
        /// executes a simple database command with multiple parameter that retrieves a data reader
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <param name="npgsqlParameters">the parameter array for the command</param>
        /// <returns>a data reader</returns>
        public DbDataReader ExecuteReader(String sql, NpgsqlParameter[] npgsqlParameters)
        {
            return Create(sql, npgsqlParameters).ExecuteReader();
        }

        /// <summary>
        /// executes a simple database command with multiple parameter that retrieves a data table
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <param name="npgsqlParameters">the parameter array for the command</param>
        /// <returns>a data table</returns>
        public DataTable ExecuteReaderToDataTable(String sql, NpgsqlParameter[] npgsqlParameters)
        {
            DataTable dt = new DataTable();
            dt.Load(ExecuteReader(sql, npgsqlParameters));
            return dt;
        }

        /// <summary>
        /// executes a simple database command with multiple parameter that retrieves a data reader
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <param name="npgsqlParameters">the parameter array for the command</param>
        /// <returns>a data reader</returns>
        public DbDataReader ExecuteReader(String sql, List<NpgsqlParameter> npgsqlParameters)
        {
            return Create(sql, npgsqlParameters).ExecuteReader();
        }

        /// <summary>
        /// executes a simple database command with multiple parameter that retrieves a data table
        /// </summary>
        /// <param name="sql">the string command</param>
        /// <param name="npgsqlParameters">the parameter array for the command</param>
        /// <returns>a data table</returns>
        public DataTable ExecuteReaderToDataTable(String sql, List<NpgsqlParameter> npgsqlParameters)
        {
            DataTable dt = new DataTable();
            dt.Load(ExecuteReader(sql, npgsqlParameters));
            return dt;
        }
        #endregion

        #region Scalar
        /// <summary>
        /// executes a simple database command that returns only one value
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <returns>the singleton value as an object</returns>
        public Object ExecuteScalar(String sql)
        {
            return Create(sql).ExecuteScalar();
        }

        /// <summary>
        /// executes a simple database command with a single parameter that returns only one value
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameter">the single command parameter</param>
        /// <returns>the singleton value as an object</returns>
        public Object ExecuteScalar(String sql, NpgsqlParameter npgsqlParameter)
        {
            return Create(sql, npgsqlParameter).ExecuteScalar();
        }

        /// <summary>
        /// executes a simple database command with a multiple parameters that returns only one value
        /// </summary>
        /// <param name="sql">the sqlCommand</param>
        /// <param name="npgsqlParameters">the parameter array</param>
        /// <returns>the singleton value as an object</returns>
        public Object ExecuteScalar(String sql, NpgsqlParameter[] npgsqlParameters)
        {
            return Create(sql, npgsqlParameters).ExecuteScalar();
        }

        /// <summary>
        /// executes a simple database command with a multiple parameters that returns only one value
        /// </summary>
        /// <param name="sql">the sqlCommand</param>
        /// <param name="npgsqlParameters">the parameter array</param>
        /// <returns>the singleton value as an object</returns>
        public Object ExecuteScalar(String sql, List<NpgsqlParameter> npgsqlParameters)
        {
            return Create(sql, npgsqlParameters).ExecuteScalar();
        }
        #endregion

        #region File
        /// <summary>
        /// executes a command script stored in the given file
        /// </summary>
        /// <param name="filename">the path to the given script file</param>
        /// <returns>the number of affected rows</returns>
        public int ExecuteFile(String filename)
        {
            String sqlCommand = System.IO.File.ReadAllText(filename, System.Text.Encoding.UTF8);
            return Create(sqlCommand).ExecuteNonQuery();
        }
        /// <summary>
        /// executes a command script stored in the given file
        /// </summary>
        /// <param name="filename">the given file</param>
        /// <param name="encoding">the given file encoding</param>
        /// <returns></returns>
        public int ExecuteFile(String filename, System.Text.Encoding encoding)
        {
            String sqlCommand = System.IO.File.ReadAllText(filename, encoding);
            return Create(sqlCommand).ExecuteNonQuery();
        }
        #endregion

        #endregion

        protected virtual void Dispose(Boolean status)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Create Commands

        /// <summary>
        /// the create command with only one parameter(simple sql commands)
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <returns>a NpgsqlCommand</returns>
        private NpgsqlCommand Create(String sql)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand
            {
                Connection = this.connection,
                CommandText = sql
            };
            return npgsqlCommand;
        }

        /// <summary>
        /// the create command with two parameters(command with single parameter queries)
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameter">a command parameter</param>
        /// <returns>a NpgsqlCommand</returns>
        private NpgsqlCommand Create(String sql, NpgsqlParameter npgsqlParameter)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand
            {
                Connection = this.connection,
                CommandText = sql
            };
            npgsqlCommand.Parameters.Add(npgsqlParameter);
            return npgsqlCommand;
        }

        /// <summary>
        /// the create command with three parameters(for use with transactions on single parameter queries)
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameter">a command parameter</param>
        /// <param name="npgsqlTransaction">an active transaction</param>
        /// <returns>a NpgsqlCommand</returns>
        private NpgsqlCommand Create(String sql, NpgsqlParameter npgsqlParameter, NpgsqlTransaction npgsqlTransaction)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand
            {
                Connection = this.connection,
                CommandText = sql,
                Transaction = npgsqlTransaction
            };
            npgsqlCommand.Parameters.Add(npgsqlParameter);
            return npgsqlCommand;
        }

        /// <summary>
        /// the create command with two parameters(for use with multi-parameter queries)
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">a parameter array containing all query parameters</param>
        /// <returns>a NpgsqlCommand</returns>
        private NpgsqlCommand Create(String sql, NpgsqlParameter[] npgsqlParameters)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand
            {
                Connection = this.connection,
                CommandText = sql
            };
            SetCommandParameters(npgsqlCommand, npgsqlParameters);
            return npgsqlCommand;
        }

        /// <summary>
        /// the create command with two parameters(for use with multi-parameter queries)
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">a parameter array containing all query parameters</param>
        /// <returns>a NpgsqlCommand</returns>
        private NpgsqlCommand Create(String sql, List<NpgsqlParameter> npgsqlParameters)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand
            {
                Connection = this.connection,
                CommandText = sql
            };
            SetCommandParameters(npgsqlCommand, npgsqlParameters);
            return npgsqlCommand;
        }

        /// <summary>
        /// the create command with three parameters(for use with transactions on multi-parameter queries)
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">a parameter array containing all query parameters</param>
        /// <param name="npgsqlTransaction">an active transaction</param>
        /// <returns>a NpgsqlCommand</returns>
        private NpgsqlCommand Create(String sql, NpgsqlParameter[] npgsqlParameters, NpgsqlTransaction npgsqlTransaction)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand
            {
                Connection = this.connection,
                CommandText = sql,
                Transaction = npgsqlTransaction
            };
            SetCommandParameters(npgsqlCommand, npgsqlParameters);
            return npgsqlCommand;
        }

        /// <summary>
        /// the create command with three parameters(for use with transactions on multi-parameter queries)
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="npgsqlParameters">a parameter list containing all query parameters</param>
        /// <param name="npgsqlTransaction">an active transaction</param>
        /// <returns>a NpgsqlCommand</returns>
        private NpgsqlCommand Create(String sql, List<NpgsqlParameter> npgsqlParameters, NpgsqlTransaction npgsqlTransaction)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand
            {
                Connection = this.connection,
                CommandText = sql,
                Transaction = npgsqlTransaction
            };
            SetCommandParameters(npgsqlCommand, npgsqlParameters);
            return npgsqlCommand;
        }
        #endregion

        /// <summary>
        /// this function will add the parameter array to the commands collection
        /// </summary>
        /// <param name="command">the query command</param>
        /// <param name="npgsqlParameters">the query parameters</param>
        private static void SetCommandParameters(NpgsqlCommand command, NpgsqlParameter[] npgsqlParameters)
        {
            command.Parameters.AddRange(npgsqlParameters);
        }

        /// <summary>
        /// this function will add the parameter array to the commands collection
        /// </summary>
        /// <param name="command">the query command</param>
        /// <param name="npgsqlParameters">the query parameters</param>
        private static void SetCommandParameters(NpgsqlCommand command, List<NpgsqlParameter> npgsqlParameters)
        {
            command.Parameters.AddRange(npgsqlParameters.ToArray());
        }
    }

    public static class Transactions
    {
        /// <summary>
        /// this function will create a transaction 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns>we return the transaction</returns>
        public static NpgsqlTransaction CreateTransaction(NpgsqlConnection connection)
        {
            if (connection.State == ConnectionState.Broken) connection.Close();
            if (connection.State == ConnectionState.Closed) connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            return transaction;
        }

        /// <summary>
        /// this function will try to Commit the transaction and on error will Rollback the transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>True if the Commit was succesful; false otherwise</returns>
        public static Boolean CommitTransaction(NpgsqlTransaction transaction)
        {
            try
            {
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        /// <summary>
        /// this will end the transaction and close an open connection
        /// </summary>
        /// <param name="connection"></param>
        public static void EndTransaction(NpgsqlConnection connection)
        {
            connection.Close();
        }
    }
}
