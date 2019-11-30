using Microsoft.EntityFrameworkCore.Migrations;

namespace apexapp.Migrations
{
    public partial class ramo_atividade_master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_RamoAtividade_RamoAtividadeId",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamoAtividade",
                table: "RamoAtividade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "RamoAtividade",
                newName: "RamoAtividades");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "Fornecedores");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedor_RamoAtividadeId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_RamoAtividadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamoAtividades",
                table: "RamoAtividades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_RamoAtividades_RamoAtividadeId",
                table: "Fornecedores",
                column: "RamoAtividadeId",
                principalTable: "RamoAtividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_RamoAtividades_RamoAtividadeId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamoAtividades",
                table: "RamoAtividades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "RamoAtividades",
                newName: "RamoAtividade");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_RamoAtividadeId",
                table: "Fornecedor",
                newName: "IX_Fornecedor_RamoAtividadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamoAtividade",
                table: "RamoAtividade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_RamoAtividade_RamoAtividadeId",
                table: "Fornecedor",
                column: "RamoAtividadeId",
                principalTable: "RamoAtividade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
