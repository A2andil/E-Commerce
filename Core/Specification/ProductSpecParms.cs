﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Core.Specification
{
    public class ProductSpecParms
    {
        private const int MaxSizeSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _PageSize = 6;

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MaxSizeSize ? MaxSizeSize : value);
        }

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public string Sort { get; set; }
    }
}
