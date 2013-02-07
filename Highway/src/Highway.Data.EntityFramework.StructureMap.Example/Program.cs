﻿using System;
using Highway.Data.Interfaces;
using StructureMap;

namespace Highway.Data.EntityFramework.StructureMap.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string SqlExpressConnectionString =
                @"Data Source=(local)\SQLExpress;Initial Catalog=HighwayDemo;Integrated Security=True";

            ObjectFactory.Initialize(x => x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AssembliesFromApplicationBaseDirectory();

                    x.For<IMappingConfiguration>().Use<HighwayDataMappings>();
                    x.For<IRepository>().Use<Repository>();
                    x.For<IDataContext>().Use<DataContext>()
                        .Ctor<string>("connectionString").Is(SqlExpressConnectionString)
                        .Ctor<IMappingConfiguration[]>("mapping").Is(new[] {new HighwayDataMappings()});
                }));

            // Use for Demos
            // DropCreateDatabaseIfModelChanges, Migrations not supported yet.  (IDatabaseInitializers)
            //Database.SetInitializer(new DropCreateDatabaseAlways<EntityFrameworkContext>());

            var application = ObjectFactory.GetInstance<DemoApplication>();
            application.Run();

            Console.Read();
        }
    }
}