using System.ComponentModel.DataAnnotations;

namespace CustomisableForms.Models
{
    public class Form
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image_url { get; set; }

        [Required]
        public string User_id { get; set; }

        [Required]
        public Guid Topic_id { get; set; }

        public bool Custom_string1_state { get; set; }

        [Display(Name = "Question 1")]
        public string Custom_string1_question { get; set; }

        public string Custom_string1_answer { get; set; }

        public bool Custom_string2_state { get; set; }

        [Display(Name = "Question 2")]
        public string Custom_string2_question { get; set; }

        public string Custom_string2_answer { get; set; }

        public bool Custom_string3_state { get; set; }

        [Display(Name = "Question 3")]
        public string Custom_string3_question { get; set; }

        public string Custom_string3_answer { get; set; }

        public bool Custom_string4_state { get; set; }

        [Display(Name = "Question 4")]
        public string Custom_string4_question { get; set; }

        public string Custom_string4_answer { get; set; }

        public bool Custom_int1_state { get; set; }

        [Display(Name = "Question 1 with a number answer")]
        public string Custom_int1_question { get; set; }

        public int Custom_int1_answer { get; set; }

        public bool Custom_int2_state { get; set; }

        [Display(Name = "Question 2 with a number answer")]
        public string Custom_int2_question { get; set; }

        public int Custom_int2_answer { get; set; }

        public bool Custom_int3_state { get; set; }

        [Display(Name = "Question 3 with a number answer")]
        public string Custom_int3_question { get; set; }

        public int Custom_int3_answer { get; set; }

        public bool Custom_int4_state { get; set; }

        [Display(Name = "Question 4 with a number answer")]
        public string Custom_int4_question { get; set; }

        public int Custom_int4_answer { get; set; }

        public Form(Guid id, string title, string description, string image_url, string user_id, Guid topic_id, bool custom_string1_state, string custom_string1_question, string custom_string1_answer, bool custom_string2_state, string custom_string2_question, string custom_string2_answer, bool custom_string3_state, string custom_string3_question, string custom_string3_answer, bool custom_string4_state, string custom_string4_question, string custom_string4_answer, bool custom_int1_state, string custom_int1_question, int custom_int1_answer, bool custom_int2_state, string custom_int2_question, int custom_int2_answer, bool custom_int3_state, string custom_int3_question, int custom_int3_answer, bool custom_int4_state, string custom_int4_question, int custom_int4_answer)
        {
            Id = id;
            Title = title;
            Description = description;
            Image_url = image_url;
            User_id = user_id;
            Topic_id = topic_id;
            Custom_string1_state = custom_string1_state;
            Custom_string1_question = custom_string1_question;
            Custom_string1_answer = custom_string1_answer;
            Custom_string2_state = custom_string2_state;
            Custom_string2_question = custom_string2_question;
            Custom_string2_answer = custom_string2_answer;
            Custom_string3_state = custom_string3_state;
            Custom_string3_question = custom_string3_question;
            Custom_string3_answer = custom_string3_answer;
            Custom_string4_state = custom_string4_state;
            Custom_string4_question = custom_string4_question;
            Custom_string4_answer = custom_string4_answer;
            Custom_int1_state = custom_int1_state;
            Custom_int1_question = custom_int1_question;
            Custom_int1_answer = custom_int1_answer;
            Custom_int2_state = custom_int2_state;
            Custom_int2_question = custom_int2_question;
            Custom_int2_answer = custom_int2_answer;
            Custom_int3_state = custom_int3_state;
            Custom_int3_question = custom_int3_question;
            Custom_int3_answer = custom_int3_answer;
            Custom_int4_state = custom_int4_state;
            Custom_int4_question = custom_int4_question;
            Custom_int4_answer = custom_int4_answer;
        }
    }
}
