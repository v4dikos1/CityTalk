using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;

namespace Domain;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<EventCreator> EventCreators { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<BaseUser> BaseUsers { get; set; } = null!;
    public DbSet<Attachment> Attachments { get; set; } = null!;
    public DbSet<EventCreatorEmployee> Employees { get; set; } = null!;
    public DbSet<EventParticipant> EventParticipants { get; set; } = null!;
    public DbSet<EventPeriod> EventPeriods { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<MessageAttachment> MessageAttachments { get; set; } = null!;

    public override int SaveChanges()
    {
        UpdateTrackDate();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        UpdateTrackDate();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        UpdateTrackDate();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        UpdateTrackDate();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void UpdateTrackDate()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: IHasTrackDateAttribute, State: EntityState.Added or EntityState.Modified });

        foreach (var entityEntry in entries)
        {
            ((IHasTrackDateAttribute)entityEntry.Entity).DateModified = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((IHasTrackDateAttribute)entityEntry.Entity).DateCreated = DateTime.UtcNow;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly);
    }
}