namespace CustomisableForms.Models
{
    public class Form
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image_url { get; set; }

        public Guid User_id { get; set; }

        public Guid Topic_id { get; set; }

        public bool Custom_string1_state { get; set; }

        public string Custom_string1_question { get; set; }

        public string Custom_string1_answer { get; set; }

        public bool Custom_string2_state { get; set; }

        public string Custom_string2_question { get; set; }

        public string Custom_string2_answer { get; set; }

        public bool Custom_string3_state { get; set; }

        public string Custom_string3_question { get; set; }

        public string Custom_string3_answer { get; set; }

        public bool Custom_string4_state { get; set; }

        public string Custom_string4_question { get; set; }

        public string Custom_string4_answer { get; set; }

        public bool Custom_int1_state { get; set; }

        public string Custom_int1_question { get; set; }

        public int Custom_int1_answer { get; set; }

        public bool Custom_int2_state { get; set; }

        public string Custom_int2_question { get; set; }

        public int Custom_int2_answer { get; set; }

        public bool Custom_int3_state { get; set; }

        public string Custom_int3_question { get; set; }

        public int Custom_int3_answer { get; set; }

        public bool Custom_int4_state { get; set; }

        public string Custom_int4_question { get; set; }

        public int Custom_int4_answer { get; set; }
    }
}
