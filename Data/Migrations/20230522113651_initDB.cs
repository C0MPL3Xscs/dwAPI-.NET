using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW3.Data.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event_Tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    host_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_private = table.Column<bool>(type: "bit", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "EventsUsers",
                columns: table => new
                {
                    ListEventsId = table.Column<int>(type: "int", nullable: false),
                    ListUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsUsers", x => new { x.ListEventsId, x.ListUsersId });
                    table.ForeignKey(
                        name: "FK_EventsUsers_Events_ListEventsId",
                        column: x => x.ListEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsUsers_Users_ListUsersId",
                        column: x => x.ListUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsInvitations",
                columns: table => new
                {
                    ListEventsId = table.Column<int>(type: "int", nullable: false),
                    ListInvitationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsInvitations", x => new { x.ListEventsId, x.ListInvitationsId });
                    table.ForeignKey(
                        name: "FK_EventsInvitations_Events_ListEventsId",
                        column: x => x.ListEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsInvitations_Invitations_ListInvitationsId",
                        column: x => x.ListInvitationsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "EventsReviews",
                columns: table => new
                {
                    ListEventsId = table.Column<int>(type: "int", nullable: false),
                    ListReviewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsReviews", x => new { x.ListEventsId, x.ListReviewsId });
                    table.ForeignKey(
                        name: "FK_EventsReviews_Events_ListEventsId",
                        column: x => x.ListEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsReviews_Reviews_ListReviewsId",
                        column: x => x.ListReviewsId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "EventsTags",
                columns: table => new
                {
                    ListEventsId = table.Column<int>(type: "int", nullable: false),
                    ListTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsTags", x => new { x.ListEventsId, x.ListTagsId });
                    table.ForeignKey(
                        name: "FK_EventsTags_Events_ListEventsId",
                        column: x => x.ListEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsTags_Tags_ListTagsId",
                        column: x => x.ListTagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersReviews",
                columns: table => new
                {
                    ListUsersId = table.Column<int>(type: "int", nullable: false),
                    ListReviewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersReviews", x => new { x.ListUsersId, x.ListReviewsId });
                    table.ForeignKey(
                        name: "FK_UsersReviews_Users_ListUsersId",
                        column: x => x.ListUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersReviews_Reviews_ListReviewsId",
                        column: x => x.ListReviewsId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "UsersInvitations",
                columns: table => new
                {
                    ListUsersId = table.Column<int>(type: "int", nullable: false),
                    ListInvitationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInvitations", x => new { x.ListUsersId, x.ListInvitationsId });
                    table.ForeignKey(
                        name: "FK_UsersInvitations_Users_ListUsersId",
                        column: x => x.ListUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInvitations_Invitations_ListInvitationsId",
                        column: x => x.ListInvitationsId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "UsersParticipants",
                columns: table => new
                {
                    ListUsersId = table.Column<int>(type: "int", nullable: false),
                    ListParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersParticipants", x => new { x.ListUsersId, x.ListParticipantsId });
                    table.ForeignKey(
                        name: "FK_UsersParticipants_Users_ListUsersId",
                        column: x => x.ListUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersParticipants_Participants_ListParticipantsId",
                        column: x => x.ListParticipantsId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Tagging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventFK = table.Column<int>(type: "int", nullable: false),
                    tagFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Tagging", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Tagging_Event_Tags_tagFK",
                        column: x => x.tagFK,
                        principalTable: "Event_Tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Tagging_Events_EventFK",
                        column: x => x.EventFK,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "TaggingTags",
                columns: table => new
                {
                    ListTaggingId = table.Column<int>(type: "int", nullable: false),
                    ListTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagginTags", x => new { x.ListTaggingId, x.ListTagsId });
                    table.ForeignKey(
                        name: "FK_TaggingTags_Tagging_ListTaggingId",
                        column: x => x.ListTaggingId,
                        principalTable: "Event_Tagging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaggingsTags_Tags_ListTagsId",
                        column: x => x.ListTagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_valid = table.Column<bool>(type: "bit", nullable: false),
                    code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    UserFK = table.Column<int>(type: "int", nullable: false),
                    EventFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitations_Events_EventFK",
                        column: x => x.EventFK,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitations_Users_UserFK",
                        column: x => x.UserFK,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFK = table.Column<int>(type: "int", nullable: false),
                    EventFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Events_EventFK",
                        column: x => x.EventFK,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Users_UserFK",
                        column: x => x.UserFK,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFK = table.Column<int>(type: "int", nullable: false),
                    EventFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Events_EventFK",
                        column: x => x.EventFK,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserFK",
                        column: x => x.UserFK,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_Tagging_EventFK",
                table: "Event_Tagging",
                column: "EventFK");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Tagging_tagFK",
                table: "Event_Tagging",
                column: "tagFK");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_EventFK",
                table: "Invitations",
                column: "EventFK");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserFK",
                table: "Invitations",
                column: "UserFK");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_EventFK",
                table: "Participants",
                column: "EventFK");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserFK",
                table: "Participants",
                column: "UserFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EventFK",
                table: "Reviews",
                column: "EventFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserFK",
                table: "Reviews",
                column: "UserFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event_Tagging");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Event_Tags");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
