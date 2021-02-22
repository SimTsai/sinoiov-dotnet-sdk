using Sinoiov.OpenApi.Extensions;
using System.Collections.Generic;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class GenericExtensionsTests
    {
        [Fact]
        public void ClassToStringDictionaryTest()
        {
            var obj = new Class
            {
                GetInitProperty = 9876,
                GetSetProperty = 5432,
                SetProperty = true
            };
            var dict = obj.ToStringDictionary();
        }

        [Fact]
        public void AnonymousClassToStringDictionaryTest()
        {
            var obj = new
            {
                p0 = 0,
                p1 = 1,
                p2 = (int?)2,
                p3 = (int?)null
            };
            var dict = obj.ToStringDictionary();
        }

        [Fact]
        public void ListToStringDictionaryTest()
        {
            var lst = new List<Class>();
            lst.Add(new Class());
            var dict = lst.ToStringDictionary();
        }
    }
}
