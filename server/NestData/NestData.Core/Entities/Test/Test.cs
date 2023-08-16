using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NestData.Core.Common;

namespace NestData.Core.Entities.Test;

public class Test : IIdentifiable
{
    public int Id { get; set; }
    public string Message { get; set; }
}

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.ToTable("Test", "domain");
    }
}