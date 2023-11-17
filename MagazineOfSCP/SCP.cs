using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagazineOfSCP
{
    public class SCP : Fond
    {
        string UnknowImage = @"Unknow.jpg";
        public string Name { get; set; }
        public string Class_ { get; set; }
        public string Description { get; set; }
        
        public string Image { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public SCP(string name, string class_, string description,  string image, int count, double price) 
        {
            Name = name;
            Class_ = class_;
            Description = description;
            Image = image==null? "pack ://application:,,,/Unknow.jpg" : image;
            Count = count==null? 1 : count;
            Price = price;
        }
        
    }
    public static class SelectSCP
    {
       
        public static SCP scp { get; set; }
        public static string Name { get; set; }
        public static string Class_ { get; set; }
        public static string Description { get; set; }
        public static string Image { get; set; }
        public static int Count { get; set; }
        public static double Price { get; set; }
    }
}
