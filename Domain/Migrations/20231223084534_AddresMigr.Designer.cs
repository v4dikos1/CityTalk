﻿// <auto-generated />
using System;
using Domain;
using Domain.Entities.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231223084534_AddresMigr")]
    partial class AddresMigr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("attachment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.BaseUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("VerificationToken")
                        .IsUnique();

                    b.ToTable("base_user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Address>("Address")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPeriodic")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EventAttachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttachmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("EventId");

                    b.ToTable("event_attachment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EventCreator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("event_creator", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EventCreatorEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BaseUseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BaseUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EventCreatorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("BaseUserId");

                    b.HasIndex("EventCreatorId");

                    b.ToTable("event_creator_employee", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EventParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BaseUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Evaluation")
                        .HasColumnType("integer");

                    b.Property<int>("EventCreatorEvaluation")
                        .HasColumnType("integer");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("BaseUserId");

                    b.HasIndex("EventId");

                    b.ToTable("event_participant", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EventPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("event_period", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MessageAttachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttachmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("MessageId");

                    b.ToTable("message_attachment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.BaseUser", b =>
                {
                    b.HasOne("Domain.Entities.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Attachment");
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.HasOne("Domain.Entities.EventCreator", "Creator")
                        .WithMany("Events")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Domain.Entities.EventAttachment", b =>
                {
                    b.HasOne("Domain.Entities.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("Attachments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Entities.EventCreator", b =>
                {
                    b.HasOne("Domain.Entities.BaseUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.EventCreatorEmployee", b =>
                {
                    b.HasOne("Domain.Entities.BaseUser", "BaseUser")
                        .WithMany()
                        .HasForeignKey("BaseUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.EventCreator", "EventCreator")
                        .WithMany("Employees")
                        .HasForeignKey("EventCreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseUser");

                    b.Navigation("EventCreator");
                });

            modelBuilder.Entity("Domain.Entities.EventParticipant", b =>
                {
                    b.HasOne("Domain.Entities.BaseUser", "BaseUser")
                        .WithMany()
                        .HasForeignKey("BaseUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseUser");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Entities.EventPeriod", b =>
                {
                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("Periods")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.HasOne("Domain.Entities.BaseUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.BaseUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Domain.Entities.MessageAttachment", b =>
                {
                    b.HasOne("Domain.Entities.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Message", "Message")
                        .WithMany("Attachments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Participants");

                    b.Navigation("Periods");
                });

            modelBuilder.Entity("Domain.Entities.EventCreator", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
