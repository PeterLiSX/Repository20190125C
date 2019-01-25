using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.PaymentService.Data
{
    public enum Action
    {
        SaveBathOrderPaymentRequest,
        TriggerBatchCaptureRequest,
        GetBatchOrderFPStatus,
        GetBatchOrderPaymentResultInfo,
        ChargeCustomer,
        UpdateSOCreditCard,
        SaveManualCharge,
        SaveAuthRequest
    }
}