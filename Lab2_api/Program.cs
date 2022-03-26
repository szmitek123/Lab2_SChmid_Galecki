using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace Lab2_api
{
    class Program
    {
        static void Main(string[] args)
        {
            load();
            Console.Read();
        }

        public static async void load()
        {
            string call = "http://radoslaw.idzikowski.staff.iiar.pwr.wroc.pl/instruction/students.json";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(call);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);

            //List<student> students = JsonConvert.DeserializeObject<List<student>>(json);
            foreach (var s in students)
            {
                Console.WriteLine(s.StudentId + " " + s.StudentName);
            }

        }
    }
}
