using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Payments;
using GWebsite.AbpZeroTemplate.Application.Share.Payments.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PaymentController : GWebsiteControllerBase
    {
        private readonly IPaymentAppService paymentAppService;

        public PaymentController(IPaymentAppService paymentAppService)
        {
            this.paymentAppService = paymentAppService;
        }

        [HttpGet]
        public PagedResultDto<PaymentDto> GetPaymentsByFilter(PaymentFilter filter)
        {
            return paymentAppService.GetPayments(filter);
        }

        [HttpGet]
        public PaymentDto GetPaymentForEdit(int id)
        {
            return paymentAppService.GetPaymentForEdit(id);
        }

        [HttpGet]
        public PaymentDto GetPaymentForView(int id)
        {
            return paymentAppService.GetPaymentForView(id);
        }

        [HttpPost]
        public void CreateOrEditPayment([FromBody] PaymentDto input)
        {
            paymentAppService.CreateOrEditPayment(input);
        }

        [HttpDelete("{id}")]
        public void DeletePayment(int id)
        {
            paymentAppService.DeletePayment(id);
        }
    }
}
