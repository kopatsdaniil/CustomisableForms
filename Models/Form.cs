using System.ComponentModel.DataAnnotations;

namespace CustomisableForms.Models
{
    public class Form
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Image_url { get; set; } = "/images/default.png";

        [Required]
        public Guid User_id { get; set; }

        [Required]
        public Guid Topic_id { get; set; }

        public bool Custom_string1_state { get; set; }

        [Display(Name = "Question 1")]
        public string Custom_string1_question { get; set; } = string.Empty;

        public bool Custom_string2_state { get; set; }

        [Display(Name = "Question 2")]
        public string Custom_string2_question { get; set; } = string.Empty;

        public bool Custom_string3_state { get; set; }

        [Display(Name = "Question 3")]
        public string Custom_string3_question { get; set; } = string.Empty;

        public bool Custom_string4_state { get; set; }

        [Display(Name = "Question 4")]
        public string Custom_string4_question { get; set; } = string.Empty;

        public bool Custom_int1_state { get; set; }

        [Display(Name = "Question 1 with a number answer")]
        public string Custom_int1_question { get; set; } = string.Empty;

        public bool Custom_int2_state { get; set; }

        [Display(Name = "Question 2 with a number answer")]
        public string Custom_int2_question { get; set; } = string.Empty;

        public bool Custom_int3_state { get; set; }

        [Display(Name = "Question 3 with a number answer")]
        public string Custom_int3_question { get; set; } = string.Empty;

        public bool Custom_int4_state { get; set; }

        [Display(Name = "Question 4 with a number answer")]
        public string Custom_int4_question { get; set; } = string.Empty;

        public static void SetStringState(Form form)
        {
            form.Custom_string1_state = !string.IsNullOrEmpty(form.Custom_string1_question);
            form.Custom_string2_state = !string.IsNullOrEmpty(form.Custom_string2_question);
            form.Custom_string3_state = !string.IsNullOrEmpty(form.Custom_string3_question);
            form.Custom_string4_state = !string.IsNullOrEmpty(form.Custom_string4_question);
            form.Custom_int1_state = !string.IsNullOrEmpty(form.Custom_int1_question);
            form.Custom_int2_state = !string.IsNullOrEmpty(form.Custom_int2_question);
            form.Custom_int3_state = !string.IsNullOrEmpty(form.Custom_int3_question);
            form.Custom_int4_state = !string.IsNullOrEmpty(form.Custom_int4_question);
        }
    }
}
