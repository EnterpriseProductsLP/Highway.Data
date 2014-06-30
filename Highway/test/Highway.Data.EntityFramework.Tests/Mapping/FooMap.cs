﻿#region

using System.Data.Entity.ModelConfiguration;
using Highway.Data.Tests.TestDomain;

#endregion

namespace Highway.Data.EntityFramework.Tests.Mapping
{
    public class FooMap : EntityTypeConfiguration<Foo>
    {
        public FooMap()
        {
            ToTable("Foos");
            HasKey(x => x.Id);
            Property(x => x.FullName).HasColumnName("Name").IsOptional();
        }
    }
}