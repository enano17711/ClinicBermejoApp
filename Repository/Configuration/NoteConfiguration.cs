using Entities.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasData(
            new Note
            {
                Id = Guid.NewGuid(), Name = "Order", Description = "Order Note", Type = AdjustmentType.Positive
            },
            new Note
            {
                Id = Guid.NewGuid(), Name = "Sale", Description = "Sale Note", Type = AdjustmentType.Negative
            },
            new Note
            {
                Id = Guid.NewGuid(), Name = "Order Return", Description = "Order Return Note",
                Type = AdjustmentType.Negative
            },
            new Note
            {
                Id = Guid.NewGuid(), Name = "Sale Return", Description = "Sale Return Note",
                Type = AdjustmentType.Positive
            }
        );
    }
}