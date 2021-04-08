using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class House
    {
        public House(int bedrooms, int bathrooms, int levels, float price, string description, int year, string imgUrl)
        {
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Levels = levels;
            Price = price;
            Description = description;
            Year = year;
            ImgUrl = imgUrl;
        }

        public House()
        {

        }

        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        [Required]
        public int Levels { get; set; }

        [Required]
        public float? Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int? Year { get; set; }

        public string ImgUrl { get; set; }

        public int Id { get; set; }
    }
}