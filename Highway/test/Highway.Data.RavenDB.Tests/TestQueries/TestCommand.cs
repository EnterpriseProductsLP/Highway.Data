﻿#region

using Highway.Data.Tests.TestDomain;

#endregion

namespace Highway.Data.RavenDB.Tests.TestQueries
{
    public class TestCommand : Command
    {
        public TestCommand()
        {
            ContextQuery = db =>
            {
                db.AsQueryable<Foo>();
                Called = true;
            };
        }

        public bool Called { get; set; }
    }
}