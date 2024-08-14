﻿namespace ASP.NET_Core_Web_API__1.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Code { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Population { get; set; }


        //Nevigation Property   

        public IEnumerable<Walk> Walks { get; set; }

    }
}
