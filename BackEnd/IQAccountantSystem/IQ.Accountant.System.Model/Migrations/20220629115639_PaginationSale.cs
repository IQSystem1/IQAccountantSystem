using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class PaginationSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string storedProcedureCode =
        "CREATE PROCEDURE dbo.GET_SALE  @PageNo INT," +
        "@PageSize INT" + Environment.NewLine +

        "AS" + Environment.NewLine +
        "BEGIN" + Environment.NewLine +
        "Select * From(Select ROW_NUMBER() Over(Order by[ID] desc) AS 'RowNum', *" + Environment.NewLine +
        "From[SALE]) t Where t.RowNum Between" + Environment.NewLine +
        "((@PageNo - 1)*@PageSize + 1) AND(@PageNo * @PageSize) " + Environment.NewLine +
        "END" + Environment.NewLine;

            migrationBuilder.Sql(storedProcedureCode.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC dbo.GET_SALE");
        }
    }
}
