using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        public Car(string make, string model, string description, string year, decimal price, string imgUrl)
        {
            Make = make;
            Model = model;
            Description = description;
            Year = year;
            Price = price;
            ImgUrl = imgUrl;
        }

        public Car()
        {

        }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImgUrl { get; set; }
        public int Id { get; set; }

    }
}