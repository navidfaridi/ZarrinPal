using System;

namespace Pargoon.ZarinPal
{
    public class PaymentRequestWithExtra : PaymentRequest
    {
        public Object AdditionalData {get;set;}

        public PaymentRequestWithExtra(String MerchantID, long Amount, String CallbackURL, String Description,Object AdditionalData):
            base(MerchantID , Amount , CallbackURL , Description){
                this.AdditionalData = AdditionalData;
        }
    }
}
