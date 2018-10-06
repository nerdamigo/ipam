using System;
using System.Collections;

namespace ipam
{
    public class Ipv4Network
    {
        public Ipv4Network() : this("0.0.0.0/0") {}
        public Ipv4Network(string network)
        {
            uint prefixVal = 0;
            string[] netSegments = network.Split('.');
            string netSize = netSegments[3].Split('/')[1];
            netSegments[3] = netSegments[3].Split('/')[0];

            for(var segIdx = 0; segIdx < 4; segIdx++) 
            { 
                prefixVal += UInt32.Parse(netSegments[segIdx]) << ((3 - segIdx) * 8);
            }

            PrefixSize = UInt32.Parse(netSize);
            uint prefixMask = 0;
            for(var prefixIdx = 31; prefixIdx >= (32-PrefixSize); prefixIdx--) { prefixMask = prefixMask | (1u << prefixIdx ); }
            prefixVal = prefixVal & prefixMask;
            Prefix = prefixVal;
        }

        public uint Prefix { get; private set; }
        public uint PrefixSize { get; private set; }

        public override string ToString()
        {
            uint[] segments = new uint[4];
            for(var segIdx = 0; segIdx < 4; segIdx++)
            {
                segments[segIdx] = (Prefix >> ((3-segIdx) * 8)) & 255u;
            }

            return $"{String.Join(".", segments)}/{PrefixSize}";
        }
    }
}
