using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary;
namespace ConsoleApp1
{
    class Program
    {
     

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            DOCTOR dOCTOR = new DOCTOR()
            {
                Id = 10, Name="Maxs", Speciality="Oftalmolog"
            };
            Patient patient = new Patient()
            {
                age=10,Id=121,Name="Andrey"
            };
            Visit visit = new Visit()
            {
                Id = 1, DoctorId = dOCTOR.Id, PatientId = patient.Id, time = DateTime.Now, Diagnostik = "eye", Reason = "terible"
            };
           
            Console.WriteLine(dOCTOR);
            Console.WriteLine(patient);
            Console.WriteLine(visit);
            Hospital hospital = new Hospital();
            hospital.ds.Add(dOCTOR);
            hospital.patients.Add(patient);
            hospital.visits.Add(visit);
            hospital.ds.Add(dOCTOR);
            hospital.patients.Add(patient);
            hospital.visits.Add(visit);
            hospital.ds.Add(dOCTOR);
            hospital.patients.Add(patient);
            hospital.visits.Add(visit);

            //DatMan datMan = new DatMan();
            //datMan.Write(hospital);

            //datMan.ReadToObject();

        }
    }
}
