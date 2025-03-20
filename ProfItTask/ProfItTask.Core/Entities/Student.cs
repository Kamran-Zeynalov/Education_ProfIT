using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfItTask.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Range(0,99999)]
        public int Number { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        [Range(0, 99)]
        public byte Class { get; set; }


        public List<Exam>? Exams { get; set; }

    }
}
