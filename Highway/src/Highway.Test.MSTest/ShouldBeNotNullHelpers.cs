﻿#region

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Highway.Test.MSTest
{
    public static class ShouldBeNotNullHelpers
    {
        public static void ShouldNotBeNull(this object item)
        {
            Assert.IsNotNull(item, "The expected object is null");
        }
    }
}