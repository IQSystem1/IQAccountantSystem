using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class SearchProduct : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string storedProcedureCode =
            @"CREATE or ALTER proc [dbo].[SEARCH_PRODUCT] " +
            @"@productCode varchar(20) = null, " +
            @"@productName varchar(100) = null ," +
            @"@productIqCode varchar(100) = null " +
            @"as " +
            @"select* from PRODUCT where " +
            @"(@productCode is null or PRODUCT_CODE like '%' + @productCode + '%')  and " +
             @"(@productName is null or PRODUCT_NAME like '%' + @productName + '%') and " +
             @"(@productIqCode is null or PRODUCT_IQ_CODE like '%' + @productIqCode + '%')";


            migrationBuilder.Sql(storedProcedureCode.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC dbo.SEARCH_PRODUCT");
        }
    }
}
