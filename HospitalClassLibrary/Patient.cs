using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLibrary
{
    [DataContract]
    public class Patient : Person
    {
        [DataMember]
        public int age { get; set; }

        public override string ToString()
        {
            return base.ToString() + "/" + $"{age} years";
        }
    }
}
