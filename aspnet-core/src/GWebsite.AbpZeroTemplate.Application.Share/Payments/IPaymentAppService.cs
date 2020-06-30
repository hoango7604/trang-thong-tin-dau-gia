using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Payments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Payments
{
    public interface IPaymentAppService
    {
        void CreateOrEditPayment(PaymentDto input);
        PaymentDto GetPaymentForEdit(int id);
        void DeletePayment(int id);
        PagedResultDto<PaymentDto> GetPayments(PaymentFilter filter);
        PaymentDto GetPaymentForView(int id);
    }
}
