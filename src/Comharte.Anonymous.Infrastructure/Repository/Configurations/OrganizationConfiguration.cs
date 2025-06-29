namespace Comharte.Anonymous.Infrastructure.Repository.Configurations;

public class OrganizationConfiguration
    : IEntityTypeConfiguration<Organization>
    , IEntityTypeConfiguration<OrganizationMember>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organization");

        builder.HasKey(o => o.Id);

        builder.HasDefaultSelector(entity => entity.Include(f => f.Members));

        builder.HasSort(x => x.DisplayName);

        builder.HasMany(entity => entity.Members)
            .WithOne()
            .HasForeignKey(entity => entity.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        var navigation = builder.Metadata.FindNavigation(nameof(Organization.Members));

        if (navigation != null)
        {
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }

    public void Configure(EntityTypeBuilder<OrganizationMember> builder)
    {
        {
            builder.ToTable("OrganizationMember");

            builder.HasKey(o => new { o.OrganizationId, o.MemberRef });

            builder.Ignore(x => x.Member);
        }
    }
}
