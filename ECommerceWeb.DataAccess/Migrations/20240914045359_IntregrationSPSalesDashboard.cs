using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntregrationSPSalesDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE uspDashboard  
                AS
                BEGIN
                    SELECT 
                        ISNULL(SUM(V.TotalSale), 0) TotalSales
                        , COUNT(V.Id) QUantitySales
                        , (SELECT COUNT(*) FROM Customers) QuantityClients
                        , (SELECT COUNT(*) FROM Products ) QuantityProducts
                    FROM Sales V (NOLOCK) 
                    WHERE V.STATE = 1
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE uspDashboard");
        }
    }
}
