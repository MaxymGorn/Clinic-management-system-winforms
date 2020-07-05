using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class DatMan
    {
        string path = @"..\..\Data\data.json";
        public void Write<T>(T obj) where T : class
        {
           
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(fs, obj);
            }

        }
        public T  ReadToObject<T>() where T : class
        {

         
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    return (T)serializer.ReadObject(fs);
                }

            
        }
    }
}
