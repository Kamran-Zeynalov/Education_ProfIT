using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfItTask.Core.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(0,99)]
        public byte Class { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public List<Exam>? Exams { get; set; }
    }
}
