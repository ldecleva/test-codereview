using System.Data;
using Microsoft.Data.Sqlite;

namespace test_codereview.Infrastructure
{
    public class DatabaseContext
    {
        private readonly IDbConnection _dbConnection;

        public DatabaseContext()
        {
            _dbConnection = new SqliteConnection("Data Source=cotizaciones.db");
            _dbConnection.Open();
        }

        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }
    }
}


/*

    string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Cotizaciones (
                Moneda TEXT NOT NULL,
                Compra TEXT NOT NULL,
                Venta TEXT NOT NULL
            )"
            ;


            _dbConnection.Execute(createTableQuery);


  var nuevaCotizacion = new
                {
                    Compra = "73,19",
                    Venta = "73,22",
                    Moneda = "Real"
                };

                dbContext.GetConnection().Execute("INSERT INTO Cotizaciones (Moneda, Compra, Venta) VALUES (@Moneda, @Compra, @Venta)", nuevaCotizacion);

 */