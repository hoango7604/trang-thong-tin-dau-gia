using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Payments;
using GWebsite.AbpZeroTemplate.Application.Share.Payments.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Payments
{
    public class PaymentAppService : GWebsiteAppServiceBase, IPaymentAppService
    {
        private readonly IRepository<Payment> paymentRepository;
        private readonly IProductAppService productAppService;

        public PaymentAppService(
            IRepository<Payment> paymentRepository,
            IProductAppService productAppService
        )
        {
            this.paymentRepository = paymentRepository;
            this.productAppService = productAppService;
        }

        #region public methods

        public void CreateOrEditPayment(PaymentDto input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Edit(input);
            }
        }

        public void DeletePayment(int id)
        {
            Delete(id);
        }

        public PaymentDto GetPaymentForEdit(int id)
        {
            return Get(id);
        }

        public PaymentDto GetPaymentForView(int id)
        {
            return Get(id);
        }

        public PagedResultDto<PaymentDto> GetPayments(PaymentFilter filter)
        {
            return GetList(filter);
        }

        #endregion public methods

        #region private methods

        private void Create(PaymentDto input)
        {
            var product = productAppService.GetProductForEdit(input.ProductId);
            product.IsPaid = true;
            productAppService.CreateOrEditProduct(product);

            var PaymentEntity = ObjectMapper.Map<Payment>(input);
            SetAuditInsert(PaymentEntity);
            paymentRepository.Insert(PaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private void Edit(PaymentDto input)
        {
            var PaymentEntity = paymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (PaymentEntity == null)
            {
            }
            ObjectMapper.Map(input, PaymentEntity);
            SetAuditEdit(PaymentEntity);
            paymentRepository.Update(PaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private PaymentDto Get(int id)
        {
            var PaymentEntity = paymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PaymentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PaymentDto>(PaymentEntity);
        }

        private PagedResultDto<PaymentDto> GetList(PaymentFilter filter)
        {
            var query = paymentRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (filter.ClientId > 0)
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }
            if (filter.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == filter.ProductId);
            }
            if (filter.Price > 0)
            {
                query = query.Where(x => x.Price == filter.Price);
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(filter.Sorting))
            {
                query = query.OrderBy(filter.Sorting);
            }

            // paging
            var items = query.PageBy(filter).ToList();

            // result
            return new PagedResultDto<PaymentDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PaymentDto>(item)).ToList()
            );
        }

        private void Delete(int id)
        {
            var PaymentEntity = paymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PaymentEntity != null)
            {
                PaymentEntity.IsDelete = true;
                paymentRepository.Update(PaymentEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion private methods
    }
}
