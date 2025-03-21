using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfItTask.Core.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }
        [Range(0, 99999)]
        public int Number { get; set; }
        public DateTime Date { get; set; }
        [Range(0,9)]
        public int Grade { get; set; }


        public Lesson? Lesson{ get; set; }
        public Student? Student{ get; set; }
    }
}
