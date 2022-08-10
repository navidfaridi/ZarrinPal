using Newtonsoft.Json;
using System;

namespace Pargoon.ZarinPal
{
    //parseh merchantid
    //string MerchantID = "e6c955db-12a7-4b35-972b-4a22af779dc9";
    public class ZarinPalCleint
    {
        private static ZarinPalCleint _ZarinPal;
        private HttpCore _HttpCore;
        private bool IsSandBox;
        public PaymentRequest PaymentRequest { get; private set; }


        private ZarinPalCleint()
        {
            this._HttpCore = new HttpCore();
        }



        public static ZarinPalCleint Get()
        {
            if (_ZarinPal == null)
            {
                _ZarinPal = new ZarinPalCleint();
            }


            return _ZarinPal;
        }


        public void EnableSandboxMode()
        {
            this.IsSandBox = true;
        }

        public void DisableSandboxMode()
        {
            this.IsSandBox = false;
        }


        public PaymentResponse InvokePaymentRequest(PaymentRequest PaymentRequest)
        {
            URLs url = new URLs(this.IsSandBox);
            _HttpCore.URL = url.GetPaymentRequestURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = PaymentRequest;
            this.PaymentRequest = PaymentRequest;
            string response = _HttpCore.Get();
            
            var _Response = JsonConvert.DeserializeObject<PaymentResponse>(response);
            _Response.PaymentURL = url.GetPaymenGatewayURL(_Response.Authority);

            return _Response;
        }


        public VerificationResponse InvokePaymentVerification(PaymentVerification verificationRequest)
        {
            URLs url = new URLs(this.IsSandBox);
            _HttpCore.URL = url.GetVerificationURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = verificationRequest;


            string response =  _HttpCore.Get();
            
            var verification = JsonConvert.DeserializeObject<VerificationResponse>(response);
           
            return verification;

        }


        public PaymentResponse InvokePaymentRequestWithExtra(PaymentRequestWithExtra paymentRequestWithExtra){
            URLs url = new URLs(this.IsSandBox,true);
            _HttpCore.URL = url.GetPaymentRequestURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = PaymentRequest;
            this.PaymentRequest = PaymentRequest;
            string response = _HttpCore.Get();
            
            var _Response = JsonConvert.DeserializeObject<PaymentResponse>(response);
            _Response.PaymentURL = url.GetPaymenGatewayURL(_Response.Authority);

            return _Response;
        }




        public VerificationResponse InvokePaymentVerificationWithExtra(PaymentVerification verificationRequest)
        {
            URLs url = new URLs(this.IsSandBox,true);
            _HttpCore.URL = url.GetVerificationURL();
            _HttpCore.Method = Method.POST;
            _HttpCore.Raw = verificationRequest;


            string response = _HttpCore.Get();
            
            var verification = JsonConvert.DeserializeObject<VerificationResponse>(response);

            return verification;
        }
    }
}