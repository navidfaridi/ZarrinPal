using System;
namespace Pargoon.ZarinPal
{
    public class VerificationResponse
    {

        public bool IsSuccess { get { return Status == 100 || Status == 101; } set { this.IsSuccess = value; } }
        public String RefID { get; set; }
        public int Status { get; set; }
        public ExtraDetail ExtraDetail { get; set; }


    }

    public class ExtraDetail
    {
        public Transaction Transaction;
    }


    public class Transaction
    {
        public String CardPanHash;
        public String CardPanMask;
    }
}
