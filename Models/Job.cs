using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        public Job(string title, string company, float rate, int hours, string description)
        {
            Title = title;
            Company = company;
            Rate = rate;
            Hours = hours;
            Description = description;
        }

        public Job()
        {

        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public float? Rate { get; set; }

        [Required]
        public int? Hours { get; set; }

        [Required]
        public string Description { get; set; }

        public int Id { get; set; }
    }
}