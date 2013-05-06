﻿using Highway.Data;
using Highway.Data.Tests.TestDomain;

namespace Highway.Data.Tests.TestQueries
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