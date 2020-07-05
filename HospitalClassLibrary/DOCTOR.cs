using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLibrary
{
    [DataContract]
    public class DOCTOR:Person
    {
        [DataMember]
        public string Speciality { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} / Speciality = {Speciality}";
        }
    }
}
