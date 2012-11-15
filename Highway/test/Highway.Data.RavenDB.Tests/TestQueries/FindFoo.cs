using Highway.Data.QueryObjects;
using Highway.Data.Tests.TestDomain;

namespace Highway.Data.RavenDB.Tests.TestQueries
{
    public class FindFoo : Query<Foo>
    {
        public FindFoo()
        {
            ContextQuery = c => c.AsQueryable<Foo>();
        }
    }
}