using System.ComponentModel.DataAnnotations;

namespace CustomisableForms.Models
{
    public class Answer
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid User_Id { get; set; }

        [Required]
        public Guid Form_Id { get; set; }

        public string Custom_string1_answer { get; set; } = string.Empty;

        public string Custom_string2_answer { get; set; } = string.Empty;

        public string Custom_string3_answer { get; set; } = string.Empty;

        public string Custom_string4_answer { get; set; } = string.Empty;

        public int Custom_int1_answer { get; set; }

        public int Custom_int2_answer { get; set; }

        public int Custom_int3_answer { get; set; }

        public int Custom_int4_answer { get; set; }
    }
}
