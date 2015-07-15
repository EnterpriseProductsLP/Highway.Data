
using System.Linq;
using FluentAssertions;
using Highway.Data.Contexts;
using Highway.Data.Tests.InMemory.Domain;
using Highway.Data.Tests.InMemory.ScenarioTests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Highway.Data.Tests.InMemory.ScenarioTests
{
    [TestClass]
    public class BlogLifeTime
    {
        private IRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new Repository(new InMemoryDataContext());
        }

        [TestMethod]
        public void ShouldCreateStoreAndRetrieve()
        {
            //Arrange
            var author = new Author
            {
                FirstName = "Devlin",
                LastName = "Liles",
                Email = "devlin@devlinliles.com",
                TwitterHandle = "@DevlinLiles"
            };


            //Act - Scenario
            var blogService = new TestBlogService(repo);
            blogService.StartBlog("Testing", author);

            blogService.Post("Testing", new Post
            {
                Title = "Test One",
                Body = "This is a body paragraph"
            });

            //Assert
            blogService.Posts("Testing").Count().Should().Be(1);
            (repo.Context as IDataContext).AsQueryable<Post>().Count().Should().Be(1);
        }

        public class LocalAuthor : Person
        {
            public override string Sex
            {
                get { return "Male"; }
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }
            public string Email { get; set; }
            public string TwitterHandle { get; set; }
        }

        public class Person
        {
            public virtual string Sex
            {
                get { return ""; }
            }
        }

        [TestMethod]
        public void ShouldCreateStoreAndRetrieve_WithClassHierarchy()
        {
            //Arrange
            var author = new LocalAuthor
            {
                FirstName = "Devlin",
                LastName = "Liles",
                Email = "devlin@devlinliles.com",
                TwitterHandle = "@DevlinLiles"
            };

            //Act - Scenario
            repo.Context.Add(author);
            repo.Context.Commit();

            //Assert
            //repo.Posts("Testing").Count().Should().Be(1);
            (repo.Context as IDataContext).AsQueryable<LocalAuthor>().Count().Should().Be(1);
            (repo.Context as IDataContext).AsQueryable<Person>().Count().Should().Be(1);
        }
    }
}