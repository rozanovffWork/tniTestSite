using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tniTestSite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubsidiaryOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    HeadOrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsidiaryOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubsidiaryOrganizations_Organizations_HeadOrganizationId",
                        column: x => x.HeadOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionObjects_SubsidiaryOrganizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "SubsidiaryOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeasurementPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ElectricEnergyMeterId = table.Column<int>(nullable: true),
                    PowerTransformerId = table.Column<int>(nullable: true),
                    VoltageTransformerId = table.Column<int>(nullable: true),
                    ConsumptionObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeasurementPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasurementPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricitySupplyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MaximumPower = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    ConsumptionObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricitySupplyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricitySupplyPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricEnergyMeters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    VerificationDate = table.Column<DateTime>(nullable: false),
                    ElectricityMeasurementPointId = table.Column<int>(nullable: true),
                    CounterType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricEnergyMeters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricEnergyMeters_ElectricityMeasurementPoints_ElectricityMeasurementPointId",
                        column: x => x.ElectricityMeasurementPointId,
                        principalTable: "ElectricityMeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    VerificationDate = table.Column<DateTime>(nullable: false),
                    ElectricityMeasurementPointId = table.Column<int>(nullable: true),
                    PowerTransformerType = table.Column<string>(nullable: true),
                    PowerTransformationRatio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerTransformers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerTransformers_ElectricityMeasurementPoints_ElectricityMeasurementPointId",
                        column: x => x.ElectricityMeasurementPointId,
                        principalTable: "ElectricityMeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    VerificationDate = table.Column<DateTime>(nullable: false),
                    ElectricityMeasurementPointId = table.Column<int>(nullable: true),
                    VoltageTransformerType = table.Column<string>(nullable: true),
                    VoltageTransformationRatio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoltageTransformer_ElectricityMeasurementPoints_ElectricityMeasurementPointId",
                        column: x => x.ElectricityMeasurementPointId,
                        principalTable: "ElectricityMeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimatedMeteringDevices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElectricitySupplyPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatedMeteringDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimatedMeteringDevices_ElectricitySupplyPoints_ElectricitySupplyPointId",
                        column: x => x.ElectricitySupplyPointId,
                        principalTable: "ElectricitySupplyPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateStart = table.Column<DateTime>(nullable: true),
                    DateFinish = table.Column<DateTime>(nullable: true),
                    ElectricityMeasurementPointId = table.Column<int>(nullable: false),
                    EstimatedMeteringDeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSets", x => new { x.ElectricityMeasurementPointId, x.EstimatedMeteringDeviceId });
                    table.UniqueConstraint("AK_TimeSets_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSets_ElectricityMeasurementPoints_ElectricityMeasurementPointId",
                        column: x => x.ElectricityMeasurementPointId,
                        principalTable: "ElectricityMeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSets_EstimatedMeteringDevices_EstimatedMeteringDeviceId",
                        column: x => x.EstimatedMeteringDeviceId,
                        principalTable: "EstimatedMeteringDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionObjects_OrganizationId",
                table: "ConsumptionObjects",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricEnergyMeters_ElectricityMeasurementPointId",
                table: "ElectricEnergyMeters",
                column: "ElectricityMeasurementPointId",
                unique: true,
                filter: "[ElectricityMeasurementPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasurementPoints_ConsumptionObjectId",
                table: "ElectricityMeasurementPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricitySupplyPoints_ConsumptionObjectId",
                table: "ElectricitySupplyPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatedMeteringDevices_ElectricitySupplyPointId",
                table: "EstimatedMeteringDevices",
                column: "ElectricitySupplyPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerTransformers_ElectricityMeasurementPointId",
                table: "PowerTransformers",
                column: "ElectricityMeasurementPointId",
                unique: true,
                filter: "[ElectricityMeasurementPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubsidiaryOrganizations_HeadOrganizationId",
                table: "SubsidiaryOrganizations",
                column: "HeadOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSets_EstimatedMeteringDeviceId",
                table: "TimeSets",
                column: "EstimatedMeteringDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_VoltageTransformer_ElectricityMeasurementPointId",
                table: "VoltageTransformer",
                column: "ElectricityMeasurementPointId",
                unique: true,
                filter: "[ElectricityMeasurementPointId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricEnergyMeters");

            migrationBuilder.DropTable(
                name: "PowerTransformers");

            migrationBuilder.DropTable(
                name: "TimeSets");

            migrationBuilder.DropTable(
                name: "VoltageTransformer");

            migrationBuilder.DropTable(
                name: "EstimatedMeteringDevices");

            migrationBuilder.DropTable(
                name: "ElectricityMeasurementPoints");

            migrationBuilder.DropTable(
                name: "ElectricitySupplyPoints");

            migrationBuilder.DropTable(
                name: "ConsumptionObjects");

            migrationBuilder.DropTable(
                name: "SubsidiaryOrganizations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
