using System;
using Domain.Entities.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "base_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_base_user_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_creator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_creator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_creator_base_user_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "base_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_message_base_user_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "base_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_message_base_user_SenderId",
                        column: x => x.SenderId,
                        principalTable: "base_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<Address>(type: "jsonb", nullable: false),
                    Coordinates = table.Column<string>(type: "text", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsPeriodic = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_event_creator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "event_creator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "event_creator_employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseUseId = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventCreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_creator_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_creator_employee_base_user_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "base_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_creator_employee_event_creator_EventCreatorId",
                        column: x => x.EventCreatorId,
                        principalTable: "event_creator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "message_attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_message_attachment_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_message_attachment_message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_attachment_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_attachment_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "event_participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    Evaluation = table.Column<int>(type: "integer", nullable: false),
                    EventCreatorEvaluation = table.Column<int>(type: "integer", nullable: false),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_participant_base_user_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "base_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_participant_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_period",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_period", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_period_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachment_Path",
                table: "attachment",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_base_user_AttachmentId",
                table: "base_user",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_base_user_Email",
                table: "base_user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_base_user_Nickname",
                table: "base_user",
                column: "Nickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_base_user_PhoneNumber",
                table: "base_user",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_CreatorId",
                table: "event",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_event_attachment_AttachmentId",
                table: "event_attachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_event_attachment_EventId",
                table: "event_attachment",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_event_creator_OwnerId",
                table: "event_creator",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_event_creator_employee_BaseUserId",
                table: "event_creator_employee",
                column: "BaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_event_creator_employee_EventCreatorId",
                table: "event_creator_employee",
                column: "EventCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_event_participant_BaseUserId",
                table: "event_participant",
                column: "BaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_event_participant_EventId",
                table: "event_participant",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_event_period_EventId",
                table: "event_period",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_message_ReceiverId",
                table: "message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_message_SenderId",
                table: "message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachment_AttachmentId",
                table: "message_attachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachment_MessageId",
                table: "message_attachment",
                column: "MessageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_attachment");

            migrationBuilder.DropTable(
                name: "event_creator_employee");

            migrationBuilder.DropTable(
                name: "event_participant");

            migrationBuilder.DropTable(
                name: "event_period");

            migrationBuilder.DropTable(
                name: "message_attachment");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "event_creator");

            migrationBuilder.DropTable(
                name: "base_user");

            migrationBuilder.DropTable(
                name: "attachment");
        }
    }
}
