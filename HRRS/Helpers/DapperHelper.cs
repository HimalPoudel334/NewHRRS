
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HRRS.Helpers
{

    public static class DapperHelper
    {
        /// <summary>
        /// Fetch the 'ClientProfileConnection' named connection string
        /// </summary>
        public static string ClientProfileConnectionString => ConfigurationManager.ConnectionStrings["ClientProfileConnection"].ConnectionString;

        /// <summary>
        /// Execute Stored Procedure returning number of rows effected
        /// </summary>
        /// <param name="storeProcedureName">Name of stored procedure</param>
        /// <param name="parameters">Parameters</param>
        public static void ExecuteStoredProcedure(string storeProcedureName, object parameters)
        {
            using (var connection = new SqlConnection(ClientProfileConnectionString))
            {
                connection.Open();

                var affectedRows = connection.Execute(sql: storeProcedureName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static SqlConnection connection = new SqlConnection(ClientProfileConnectionString);

        public static void ExecuteStoredProcedureTran(string storeProcedureName, object parameters,
           SqlConnection connection = null,
           SqlTransaction transaction = null)
        {
            //using (var connection = new SqlConnection(ClientProfileConnectionString))
            // {
            //  connection.Open();

            var affectedRows = connection.Execute(sql: storeProcedureName,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: transaction

                    );
            //}
        }

        /// <summary>
        /// Query Stored Procedure returning result
        /// </summary>
        /// <typeparam name="T">Class Type of the retured result from store procedure</typeparam>
        /// <param name="storeProcedureName">Name of stored procedure</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public static IEnumerable<T> QueryStoredProcedure<T>(
     string storeProcedureName,
     object parameters = null,
     int? commandTimeout = null) // Add optional timeout parameter
        {
            using (var connection = new SqlConnection(ClientProfileConnectionString))
            {
                    connection.Open();

                    var result = connection.Query<T>(
                        sql: storeProcedureName,
                        param: parameters,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: commandTimeout // Pass the timeout to Dapper
                    );

                return result;
            }
        }


        public static IEnumerable<T> QuerySqlStatment<T>(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(ClientProfileConnectionString))
            {
                connection.Open();

                var result = connection.Query<T>(sql: sql,
                    param: parameters);

                return result;
            }
        }

        public static void ExecuteSqlStatement(string sql, object parameters = null, IDbTransaction transactionScope = null)
        {
            using (var connection = new SqlConnection(ClientProfileConnectionString))
            {
                connection.Open();

                var affectedRows = connection.Execute(sql: sql,
                    param: parameters,
                    transaction: transactionScope);
            }
        }

        internal static void ExecuteStoredProcedure(string v)
        {
            throw new NotImplementedException();
        }
    }
}