﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class Dish
    {
        public int Dish_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] DishImage { get; set; }
        public string Category { get; set; }
        public double Callories { get; set; }
        public List<Ingridient> Ingridients { get; set; }
    }
}
