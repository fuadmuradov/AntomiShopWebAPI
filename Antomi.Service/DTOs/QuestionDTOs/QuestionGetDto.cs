using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.QuestionDTOs
{
    public class QuestionGetDto
    {
        public int Id { get; set; }
        public string Issue { get; set; }
        public string Answer { get; set; }
    }
}
