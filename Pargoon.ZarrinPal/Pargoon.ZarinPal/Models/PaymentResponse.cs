﻿using System;

namespace Pargoon.ZarinPal
{
    public class PaymentResponse
    {
        public String Authority { set; get; }
        public int Status { set; get; }
        public String PaymentURL { set; get; }

    }
}
