using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallWebApiClient().Wait();
            var student = new Student
            {
                StudentName = "Phaniraj",
                Phoneno = "9945204584",
                CurrentClass = "13th"
            };

            postCode(student).Wait(); 
        }
        static async Task postCode(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44339/api/Students/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync("AddStudent", student);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Student added to the database");
                }
                else
                {
                    var data = response.Content.ReadAsStringAsync();
                    Console.WriteLine(data.Result);
                }
            }
        }
        static async Task CallWebApiClient()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44339/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Students/AllStudent");
                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsAsync<List<Student>>();
                    foreach(var student in task.Result)
                        Console.WriteLine(student.StudentName);
                }
            }
        }
    }

    public class Student
    {
        
        public int StudentId { get; set; }
        
        public string StudentName { get; set; }
        
        public string Phoneno { get; set; }
        
        public string CurrentClass { get; set; }
    }
}
