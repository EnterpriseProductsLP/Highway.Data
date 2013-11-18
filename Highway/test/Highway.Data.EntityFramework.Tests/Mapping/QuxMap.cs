#region

using System.Data.Entity.ModelConfiguration;
using Highway.Data.Tests.TestDomain;

#endregion

namespace Highway.Data.EntityFramework.Tests.Mapping
{
    public class QuxMap : EntityTypeConfiguration<Qux>
    {
        public QuxMap()
        {
            ToTable("Quxs");
            HasKey(x => x.Id);
            Property(x => x.Name).IsOptional();
        }
    }
}