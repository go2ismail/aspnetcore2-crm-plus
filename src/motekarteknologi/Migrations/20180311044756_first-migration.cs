using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace motekarteknologi.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    NumberofDays = table.Column<int>(nullable: false),
                    RecomendedNextActivityID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivityType_ActivityType_RecomendedNextActivityID",
                        column: x => x.RecomendedNextActivityID,
                        principalTable: "ActivityType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeadType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LostReason",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostReason", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PipelineStage",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineStage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    ContactName = table.Column<string>(maxLength: 200, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    CustomerTypeID = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    JobPosition = table.Column<string>(maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    Street2 = table.Column<string>(maxLength: 100, nullable: true),
                    Website = table.Column<string>(maxLength: 100, nullable: true),
                    ZIP = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerType_CustomerTypeID",
                        column: x => x.CustomerTypeID,
                        principalTable: "CustomerType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerActivity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActivityTypeID = table.Column<Guid>(nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerActivity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerActivity_ActivityType_ActivityTypeID",
                        column: x => x.ActivityTypeID,
                        principalTable: "ActivityType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerActivity_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAdditionalContact",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdditionalContact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerAdditionalContact_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerNote",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerNote_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadActivity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActivityTypeID = table.Column<Guid>(nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LeadID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadActivity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeadActivity_ActivityType_ActivityTypeID",
                        column: x => x.ActivityTypeID,
                        principalTable: "ActivityType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityActivity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActivityTypeID = table.Column<Guid>(nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OpportunityID = table.Column<Guid>(nullable: true),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityActivity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpportunityActivity_ActivityType_ActivityTypeID",
                        column: x => x.ActivityTypeID,
                        principalTable: "ActivityType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    ContactName = table.Column<string>(maxLength: 200, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsQualified = table.Column<bool>(nullable: false),
                    JobPosition = table.Column<string>(maxLength: 100, nullable: true),
                    LeadTypeID = table.Column<Guid>(nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    SalesChannelID = table.Column<Guid>(nullable: true),
                    SalesPersonId = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    Street2 = table.Column<string>(maxLength: 100, nullable: true),
                    Website = table.Column<string>(maxLength: 100, nullable: true),
                    ZIP = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lead_LeadType_LeadTypeID",
                        column: x => x.LeadTypeID,
                        principalTable: "LeadType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadAdditionalContact",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    JobPosition = table.Column<string>(maxLength: 100, nullable: true),
                    LeadID = table.Column<Guid>(nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAdditionalContact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeadAdditionalContact_Lead_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Lead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadNote",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LeadID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeadNote_Lead_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Lead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActualClosing = table.Column<DateTime>(nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ExpectedClosing = table.Column<DateTime>(nullable: false),
                    ExpectedRevenue = table.Column<decimal>(type: "money", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsLost = table.Column<bool>(nullable: false),
                    IsWon = table.Column<bool>(nullable: false),
                    LeadID = table.Column<Guid>(nullable: true),
                    LostReasonID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PipelineStageID = table.Column<Guid>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Opportunity_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunity_Lead_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Lead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunity_LostReason_LostReasonID",
                        column: x => x.LostReasonID,
                        principalTable: "LostReason",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunity_PipelineStage_PipelineStageID",
                        column: x => x.PipelineStageID,
                        principalTable: "PipelineStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesChannel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ChannelLeaderId = table.Column<string>(nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesChannel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SalesChannelID = table.Column<Guid>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_SalesChannel_SalesChannelID",
                        column: x => x.SalesChannelID,
                        principalTable: "SalesChannel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityType_RecomendedNextActivityID",
                table: "ActivityType",
                column: "RecomendedNextActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SalesChannelID",
                table: "AspNetUsers",
                column: "SalesChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerTypeID",
                table: "Customer",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivity_ActivityTypeID",
                table: "CustomerActivity",
                column: "ActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivity_CustomerID",
                table: "CustomerActivity",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdditionalContact_CustomerID",
                table: "CustomerAdditionalContact",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNote_CustomerID",
                table: "CustomerNote",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_LeadTypeID",
                table: "Lead",
                column: "LeadTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_SalesChannelID",
                table: "Lead",
                column: "SalesChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_SalesPersonId",
                table: "Lead",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadActivity_ActivityTypeID",
                table: "LeadActivity",
                column: "ActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadActivity_LeadID",
                table: "LeadActivity",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAdditionalContact_LeadID",
                table: "LeadAdditionalContact",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadNote_LeadID",
                table: "LeadNote",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_CustomerID",
                table: "Opportunity",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_LeadID",
                table: "Opportunity",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_LostReasonID",
                table: "Opportunity",
                column: "LostReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_PipelineStageID",
                table: "Opportunity",
                column: "PipelineStageID");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityActivity_ActivityTypeID",
                table: "OpportunityActivity",
                column: "ActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityActivity_OpportunityID",
                table: "OpportunityActivity",
                column: "OpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesChannel_ChannelLeaderId",
                table: "SalesChannel",
                column: "ChannelLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeadActivity_Lead_LeadID",
                table: "LeadActivity",
                column: "LeadID",
                principalTable: "Lead",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OpportunityActivity_Opportunity_OpportunityID",
                table: "OpportunityActivity",
                column: "OpportunityID",
                principalTable: "Opportunity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_AspNetUsers_SalesPersonId",
                table: "Lead",
                column: "SalesPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_SalesChannel_SalesChannelID",
                table: "Lead",
                column: "SalesChannelID",
                principalTable: "SalesChannel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesChannel_AspNetUsers_ChannelLeaderId",
                table: "SalesChannel",
                column: "ChannelLeaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesChannel_AspNetUsers_ChannelLeaderId",
                table: "SalesChannel");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerActivity");

            migrationBuilder.DropTable(
                name: "CustomerAdditionalContact");

            migrationBuilder.DropTable(
                name: "CustomerNote");

            migrationBuilder.DropTable(
                name: "LeadActivity");

            migrationBuilder.DropTable(
                name: "LeadAdditionalContact");

            migrationBuilder.DropTable(
                name: "LeadNote");

            migrationBuilder.DropTable(
                name: "OpportunityActivity");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "LostReason");

            migrationBuilder.DropTable(
                name: "PipelineStage");

            migrationBuilder.DropTable(
                name: "CustomerType");

            migrationBuilder.DropTable(
                name: "LeadType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SalesChannel");
        }
    }
}
