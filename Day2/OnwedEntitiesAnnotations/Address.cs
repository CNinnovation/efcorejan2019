﻿using Microsoft.EntityFrameworkCore;

namespace OwnedEntities
{
    [Owned]
    public class Address
    {
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public Location Location { get; set; }
    }
}
