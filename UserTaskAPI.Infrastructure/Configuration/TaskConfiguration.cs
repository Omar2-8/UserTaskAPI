using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserTask.Domain.Entities;

namespace UserTask.Infrastructure.Configuration;

public sealed class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Description)
               .IsRequired();

        builder.Property(x => x.Status)
               .IsRequired();

        builder.Property(x => x.Priority)
               .IsRequired();

        builder.Property(x => x.DueDate);
        builder.Property(x => x.CompletedAt);
    }
}