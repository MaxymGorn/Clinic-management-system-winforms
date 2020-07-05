using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLibrary
{
    [DataContract]
    public class Visit
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime time { get; set; }
        [DataMember]
        public int PatientId{get;set;}
        [DataMember]
        public int DoctorId { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string Diagnostik { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, time = {time}, pathient id = {PatientId}\nDoctor = {DoctorId}, Reason = {Reason}, Diagnostik = {Diagnostik}\n";
        }
    }
}
