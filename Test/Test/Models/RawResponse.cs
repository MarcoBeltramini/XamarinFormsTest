using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace Test.Models
{
    public class RawResponse
    {
        public object[] Slaves { get; set; }       
        public object[] Cronos_Groups { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public float TAmb { get; set; }
        public float T1 { get; set; }
        public float T2 { get; set; }
        public float T3 { get; set; }
        public object TJ { get; set; }
        public float TMan { get; set; }
        public float Tafrost { get; set; }
        public object TSet { get; set; }
        public float STMin { get; set; }
        public float STMax { get; set; }
        public string Mode { get; set; }
        public object JollyTime_H { get; set; }
        public object JollyTime_M { get; set; }
        public object UmiditySensor { get; set; }
        public float UmidityValue { get; set; }
        public string WS { get; set; }
        public object Model_Release { get; set; }
        public string Last_Connected { get; set; }
        public object DHCP { get; set; }
        public bool Relay { get; set; }
        public object Image { get; set; }
        public object Assigned_IP { get; set; }
        public object Assigned_Subnet { get; set; }
        public object Assigned_Gateway { get; set; }
        public string ZIP { get; set; }
        public object Location { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P6 { get; set; }
        public string P7 { get; set; }
        public string P8 { get; set; }
    }
}
