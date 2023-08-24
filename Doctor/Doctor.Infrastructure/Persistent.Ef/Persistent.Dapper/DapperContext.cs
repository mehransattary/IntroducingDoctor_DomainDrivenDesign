
using Microsoft.Data.SqlClient;
using System.Data;

namespace Doctor.Infrastructure.Persistent.Ef.Persistent.Dapper;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public IDbConnection CreateConnection()
      => new SqlConnection(_connectionString);

    public string MedicalService => "[doctor].MedicalServices";

}
