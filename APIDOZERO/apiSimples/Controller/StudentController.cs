using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiSimples.Filters;
using apiSimples.Model;

namespace apiSimples.Controller
{
    public class StudentController : ApiController
    {
        [Route("api/student/names")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Dario", "Monalisa" };
        }

        [Route("api/student/grades/{name}")]
        public string Post(string name)
        {
            var p = new string[] { "Dario", "Monalisa" };
            return "O estudante é: " + p.Where(x => x.Equals(name));
        }

        [Route("api/student/GetStudent")]
        [HttpPost]
        public Student GetStudent([FromUri] string name, int age)
        {
            return new Student() { Name = name, Age = age };
        }


        [Route("api/student/GetStudentByModel")]
        [HttpPost]
        public Student GetStudentByModel(Student student)
        {
            return new Student() { Id = student.Id, Name = student.Name, Age = student.Age };
        }


        [Route("api/student/GetStudentByModelMX")]
        [HttpPost]
        public Student GetStudentByModelMX(int id, Student student)
        {
            return new Student() { Id = id, Name = student.Name, Age = student.Age };
        }

        [Route("api/student/ValidateStatus")]
        [HttpPost]
        [Log]
        public HttpResponseMessage ValidateStatus(int stClass, Student studentRes)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            InfraStructure infra = new InfraStructure();
            List<Student> students = new List<Student>();
            students.Add(new Student() { Age = 12,Id=1,Name="Soraya Amaral" }) ;
            students.Add(new Student() { Age = 12, Id = 2, Name = "Bianca Guedes" });
            students.Add(new Student() { Age = 13, Id = 3, Name = "Raul Silva" });
            students.Add(new Student() { Age = 11, Id = 4, Name = "Arthur Gomes Figueira" });

            infra.room = new ClassRoom() { Id = 4, students = students, professorId = 10 };

            if (infra.room.Id == stClass)
            {
                var student = infra.room.students.Where(x => x.Id == studentRes.Id).FirstOrDefault();
                if(student != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,student);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Não foram encontrados dados do aluno:{studentRes.Id} na sala informada: {stClass}");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"A classe informada não existe:{stClass}");
            }
        }

        [Route("api/student/ValidateStatusI")]
        [HttpPost]
        [Log]
        public IHttpActionResult ValidateStatusI(int stClass, Student studentRes)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            InfraStructure infra = new InfraStructure();
            List<Student> students = new List<Student>();
            students.Add(new Student() { Age = 12, Id = 1, Name = "Soraya Amaral" });
            students.Add(new Student() { Age = 12, Id = 2, Name = "Bianca Guedes" });
            students.Add(new Student() { Age = 13, Id = 3, Name = "Raul Silva" });
            students.Add(new Student() { Age = 11, Id = 4, Name = "Arthur Gomes Figueira" });

            infra.room = new ClassRoom() { Id=4,students = students, professorId = 10 };

            if (infra.room.Id == stClass)
            {
                var student = infra.room.students.Where(x => x.Id == studentRes.Id).FirstOrDefault();
                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"Não foram encontrados dados do aluno:{studentRes.Id} na sala informada: {stClass}");
                }
            }
            else
            {
                return Content(HttpStatusCode.NotFound,$"A classe informada não existe:{stClass}");
            }

        }
    }
}
