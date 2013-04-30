using Highway.Data;

namespace Highway.Data.Services
{
    /// <summary>
    /// Stub implementation of the User Name service to supply example names for Auditable interceptor.
    /// </summary>
    public class DefaultUserNameService : IUserNameService
    {
        #region IUserNameService Members

        /// <summary>
        /// Basic Method for returning the current user name
        /// </summary>
        /// <returns>The current user's name or login</returns>
        public string GetCurrentUserName()
        {
            return "Default User";
        }

        #endregion
    }
}