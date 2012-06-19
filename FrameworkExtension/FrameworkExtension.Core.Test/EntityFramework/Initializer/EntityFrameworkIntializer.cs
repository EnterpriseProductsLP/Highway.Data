﻿using System.Data.Entity;
using FrameworkExtension.Core.Test.EntityFramework.UnitTests;
using FrameworkExtension.Core.Test.TestDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkExtension.Core.Test.EntityFramework.Initializer
{
    public class EntityFrameworkIntializer : DropCreateDatabaseAlways<EntityFrameworkTestContext>
    {
        protected override void Seed(EntityFrameworkTestContext context)
        {
            for (int i = 0; i < 5;i++ )
            {
                context.Add(new Foo());
            }
            context.SaveChanges();
        }
    }

    public class ForceDeleteInitializer : IDatabaseInitializer<EntityFrameworkTestContext>
    {
        private readonly IDatabaseInitializer<EntityFrameworkTestContext> _initializer;

        public ForceDeleteInitializer(IDatabaseInitializer<EntityFrameworkTestContext> innerInitializer)
        {
            _initializer = innerInitializer;
        }

        public void InitializeDatabase(EntityFrameworkTestContext context)
        {
            if(context.Database.Exists()) context.Database.ExecuteSqlCommand("ALTER DATABASE FEEFTest SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            _initializer.InitializeDatabase(context);
        }
    }
}