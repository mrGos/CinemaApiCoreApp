using CoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreApp.Utilities.Test.Dtos
{
    public class PagedResultTest
    {
        [Fact]
        public void Constructor_CreateObject_NotNullObject()
        {
            var pageResult = new PagedResult<object>();
            Assert.NotNull(pageResult);
        }

        [Fact]
        public void Constructor_CreateObject_WithResultNotNull()
        {
            var pageResult = new PagedResult<object>();
            Assert.NotNull(pageResult.Results);
        }
    }
}
