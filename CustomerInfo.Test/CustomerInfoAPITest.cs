using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerInfo.Test
{
    public class CustomerInfoAPITest
    {
        [Fact]
        public async Task Test_GetAll()
        {
            using(var client = new TestClientProvider().client)
            {
                var response = await client.GetAsync("/api/Customer");
                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        [Fact]
        public async Task Test_Search_By_Name()
        {
            using (var client = new TestClientProvider().client)
            {
                var response = await client.GetAsync("/api/Customer/{James}");
                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
