using apiSimples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSimples.Model
{
    public class InfraStructure
    {
        public ClassRoom room { get; set; }

    }

    public partial class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int professorId { get; set; }
        public List<Student> students { get; set; }
    }

    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}