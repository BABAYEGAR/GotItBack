﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotItBack.Data.Objects.Entities
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Lga> Lgas { get; set; }
    }
}