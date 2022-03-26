using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using Lab2_api;


namespace Forms_Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var json = GetDataAsync();
           
        }
        private async Task<string> GetDataAsync()
        {
            string call = "http://radoslaw.idzikowski.staff.iiar.pwr.wroc.pl/instruction/students.json";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(call);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
            foreach (Student student in students)
            {
                listBox1.Items.Add(student.StudentId + " " + student.StudentName);
            }
            
            return json;
        }
    }
}
