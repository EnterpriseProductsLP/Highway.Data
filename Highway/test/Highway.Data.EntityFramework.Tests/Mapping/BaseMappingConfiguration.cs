#region

using System.Data.Entity;

#endregion

namespace Highway.Data.EntityFramework.Tests.Mapping
{
    public class BaseMappingConfiguration : IMappingConfiguration
    {
        public BaseMappingConfiguration()
        {
            Configured = false;
        }

        public bool Configured { get; set; }

        #region IMappingConfiguration Members

        public virtual void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            Configured = true;
        }

        #endregion
    }
}