using System;
using Xunit;
using ipam;

namespace ipam_tests
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyNetworkToString()
        {
            var net = new Ipv4Network();
            Assert.Equal("0.0.0.0/0", net.ToString());
        }

        [Fact]
        public void NonEmptyNetworkToString()
        {
            var net = new Ipv4Network("255.192.0.0/10");
            Assert.Equal("255.192.0.0/10", net.ToString());
        }

        [Fact]
        public void PrefixMaskingNetworkToString()
        {
            var net = new Ipv4Network("255.192.67.17/9");
            Assert.Equal("255.128.0.0/9", net.ToString());
        }
    }
}
