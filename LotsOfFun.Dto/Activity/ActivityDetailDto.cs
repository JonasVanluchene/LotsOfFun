﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Dto.Activity
{
    public class ActivityDetailDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }
        public string FullAddress { get; set; }

        public string ImageUrl { get; set; }
    }
}
