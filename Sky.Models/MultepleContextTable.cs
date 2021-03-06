﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sky.Models {
    public class MultepleContextTable {
        public int OrderId { get; set; }
        public OrderDetailDto OrderDetailDto { get; set; }

        public int PortfolioId { get; set; }
        public PortfolioDto PortfolioDto { get; set; }

        public int DetailsId { get; set; }
        public PortfolioDetailsDto PortfolioDetailsDto { get; set; }

        public int RequestId { get; set; }
        public RequestDto RequestDto { get; set; }
    }
}
