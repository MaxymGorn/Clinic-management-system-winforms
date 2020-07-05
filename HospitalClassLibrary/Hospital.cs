using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLibrary
{
    [DataContract]
    public class Hospital
    {
        [DataMember]
        public List<DOCTOR> ds { get; set; } = new List<DOCTOR>();
        [DataMember]
        public List<Visit> visits { get; set; } = new List<Visit>();
        [DataMember]
        public List<Patient> patients { get; set; } = new List<Patient>();

        public void DislpayD()
        {
            Console.Write("Doctors: ");
            foreach(var el in ds)
            {
                Console.WriteLine($"{el,5}");
            }
        }
        public void DislpayV()
        {
            Console.Write("Visits: ");
            foreach (var el in visits)
            {
                Console.WriteLine($"{el,5}");
            }
        }
        public void DislpayP()
        {
            Console.Write("Patients: ");
            foreach (var el in patients)
            {
                Console.WriteLine($"{el,5}");
            }
        }

    }
}
 