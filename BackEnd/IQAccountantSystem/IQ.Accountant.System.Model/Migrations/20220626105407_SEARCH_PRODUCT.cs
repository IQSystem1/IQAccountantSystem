using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class SEARCH_PRODUCT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string storedProcedureCode =
            @"CREATE or ALTER proc [dbo].[SEARCH_PRODUCT] " +
            @"@productCode varchar(20) = null, " +
            @"@productName varchar(100) = null ," +
            @"@productUnit varchar(100) = null " +
            @"as " +
            @"select* from PRODUCT where " +
            @"(@productCode is null or PRODUCT_CODE like '%' + @productCode + '%')  and " +
             @"(@productName is null or PRODUCT_NAME like '%' + @productName + '%') and " +
             @"(@productUnit is null or PRODUCT_UNIT like '%' + @productUnit + '%')";


            migrationBuilder.Sql(storedProcedureCode.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC dbo.SEARCH_PRODUCT");
        }
    }
}
