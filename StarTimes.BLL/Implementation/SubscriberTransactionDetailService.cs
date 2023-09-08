using StarTimes.BLL.DTO;
using StarTimes.BLL.Interfaces;
using StarTimes.BLL.Utility;
using StarTimes.DAL.Entities;
using StarTimes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarTimes.BLL.Implementation
{
    public class SubscriberTransactionDetailService : ISubscriberTransactionDetailService
    {
        private IUnitOfWork _unitOfWork;

        public SubscriberTransactionDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SubscriberTransactionDetailDTO> Create(SubscriberTransactionDetailDTO subscriberTransactionDetailDTO)
        {
            if (subscriberTransactionDetailDTO == null)
            {
                return null;
            }

            SubscriberTransactionDetail notificationDetail = Utility<SubscriberTransactionDetailDTO, SubscriberTransactionDetail>.MapEntity(subscriberTransactionDetailDTO);
            notificationDetail.CreatedDate = DateTime.UtcNow;
            SubscriberTransactionDetail result = await _unitOfWork.Repository<SubscriberTransactionDetail>().Create(notificationDetail);
            if (result == null)
            {

                return null;

            }

            return Utility<SubscriberTransactionDetail, SubscriberTransactionDetailDTO>.MapEntity(result);
        }

        public async Task<List<SubscriberTransactionDetailDTO>> GetAll(Expression<Func<SubscriberTransactionDetail, bool>> expression)
        {
            List<SubscriberTransactionDetail> subscriberTransactionDetails = await _unitOfWork.Repository<SubscriberTransactionDetail>().GetAll(null, expression);

            if (!subscriberTransactionDetails.Any())
            {
                return new List<SubscriberTransactionDetailDTO>();
            }
            var subscriberTransactionDetailDTOs = new List<SubscriberTransactionDetailDTO>();
            int totalItems = subscriberTransactionDetails.Count;
            for (int i = 0; i < totalItems; i++)
            {

                subscriberTransactionDetailDTOs.Add(new SubscriberTransactionDetailDTO
                {
                    Id = subscriberTransactionDetails[i].Id,
                    ConfirmationCode = subscriberTransactionDetails[i].ConfirmationCode,
                    MerchantReference = subscriberTransactionDetails[i].MerchantReference,
                    PaymentMethod = subscriberTransactionDetails[i].PaymentMethod,
                    Status = subscriberTransactionDetails[i].Status,
                    SubscriberPaymentInfonId = subscriberTransactionDetails[i].SubscriberPaymentInfonId,
                    TrackingId = subscriberTransactionDetails[i].TrackingId,
                    CreatedDate = subscriberTransactionDetails[i].CreatedDate,
                    ModifiedDate = subscriberTransactionDetails[i].ModifiedDate,
                     Amount = subscriberTransactionDetailDTOs[i].Amount,
                    Currency = subscriberTransactionDetailDTOs[i].Currency,
                    Posted = subscriberTransactionDetailDTOs[i].Posted
                });
            }

            return subscriberTransactionDetailDTOs;
        }

        public async Task<List<SubscriberTransactionDetailDTO>> GetAll()
        {
            List<SubscriberTransactionDetail> subscriberTransactionDetails = await _unitOfWork.Repository<SubscriberTransactionDetail>().GetAll(null);

            if (!subscriberTransactionDetails.Any())
            {
                return new List<SubscriberTransactionDetailDTO>();
            }
            var subscriberTransactionDetailDTOs = new List<SubscriberTransactionDetailDTO>();
            int totalItems = subscriberTransactionDetails.Count;
            for (int i = 0; i < totalItems; i++)
            {

                subscriberTransactionDetailDTOs.Add(new SubscriberTransactionDetailDTO
                {
                    Id = subscriberTransactionDetails[i].Id,
                    ConfirmationCode = subscriberTransactionDetails[i].ConfirmationCode,
                    MerchantReference = subscriberTransactionDetails[i].MerchantReference,
                    PaymentMethod = subscriberTransactionDetails[i].PaymentMethod,
                    Status = subscriberTransactionDetails[i].Status,
                    SubscriberPaymentInfonId = subscriberTransactionDetails[i].SubscriberPaymentInfonId,
                    TrackingId = subscriberTransactionDetails[i].TrackingId,
                    CreatedDate = subscriberTransactionDetails[i].CreatedDate,
                    ModifiedDate = subscriberTransactionDetails[i].ModifiedDate,
                    Amount = subscriberTransactionDetailDTOs[i].Amount,
                    Currency = subscriberTransactionDetailDTOs[i].Currency,
                    Posted = subscriberTransactionDetailDTOs[i].Posted


                });
            }

            return subscriberTransactionDetailDTOs;
        }

        public async Task<List<SubscriberTransactionDetailDTO>> GetAllData(TransactionAdminSearchRequestDTO transactionAdminSearchRequest)
        {
            string query = string.Empty;

            if (string.IsNullOrEmpty(transactionAdminSearchRequest.ConfirmationCode))
            {
                query = $"select * from SubscriberTransactionDetails where CreatedDate >= '" + transactionAdminSearchRequest.DateFrom.ToString("yyyy-MM-dd HH:MM:ss") + "' AND CreatedDate <= '" + transactionAdminSearchRequest.DateTo.ToString("yyyy-MM-dd HH:MM:ss") + "'";

            }
            else
            {
                query = $"select * from SubscriberTransactionDetails where ConfirmationCode ='" +transactionAdminSearchRequest.ConfirmationCode+"'";

            }

            List<SubscriberTransactionDetail> subscriberTransactionDetails = await _unitOfWork.Repository<SubscriberTransactionDetail>().GetAllData(query);
            var subscriberTransactionDetailDTOs = new List<SubscriberTransactionDetailDTO>();
            foreach (SubscriberTransactionDetail subscriberTransaction in subscriberTransactionDetails)
            {

                subscriberTransactionDetailDTOs.Add(new SubscriberTransactionDetailDTO
                {
                    ConfirmationCode = subscriberTransaction.ConfirmationCode,
                    Status = subscriberTransaction.Status,
                    SubscriberPaymentInfonId = subscriberTransaction.SubscriberPaymentInfonId,
                    Id = subscriberTransaction.Id,
                    MerchantReference = subscriberTransaction.MerchantReference,
                    PaymentMethod = subscriberTransaction.PaymentMethod,
                    Posted = subscriberTransaction.Posted,
                    TrackingId = subscriberTransaction.TrackingId,
                    CreatedDate = subscriberTransaction.CreatedDate,
                    ModifiedDate = subscriberTransaction.ModifiedDate,
                    Amount = subscriberTransaction.Amount,
                    Currency = subscriberTransaction.Currency
                    
                });
            }

            return subscriberTransactionDetailDTOs;

        }

        public SubscriberTransactionDetailDTO GetById(int id)
        {
            SubscriberTransactionDetail result = _unitOfWork.Repository<SubscriberTransactionDetail>().GetById(id);

            if (result == null)
            {
                return null;
            }

            return Utility<SubscriberTransactionDetail, SubscriberTransactionDetailDTO>.MapEntity(result);
        }

        public async Task<SubscriberTransactionDetailDTO> SearchClientAsync(Expression<Func<SubscriberTransactionDetail, bool>> expression)
        {
            SubscriberTransactionDetail result = await _unitOfWork.Repository<SubscriberTransactionDetail>().AdvancedSearchFilterAsync(expression);

            if (result == null)
            {
                return null;
            }

            return Utility<SubscriberTransactionDetail, SubscriberTransactionDetailDTO>.MapEntity(result);
        }

        public async Task<SubscriberTransactionDetailDTO> SearchClientAsync(string objInclude, Expression<Func<SubscriberTransactionDetail, bool>> expression)
        {
            SubscriberTransactionDetail result = (SubscriberTransactionDetail)await _unitOfWork.Repository<SubscriberTransactionDetail>().AdvancedSearchFilterAsync(objInclude, expression);

            if (result == null)
            {
                return null;
            }

            return Utility<SubscriberTransactionDetail, SubscriberTransactionDetailDTO>.MapEntity(result);
        }

        public async Task<SubscriberTransactionDetailDTO> Update(SubscriberTransactionDetailDTO subscriberTransactionDetailDTO)
        {
            if (subscriberTransactionDetailDTO == null)
            {
                return null;
            }

            SubscriberTransactionDetail mapping = Utility<SubscriberTransactionDetailDTO, SubscriberTransactionDetail>.MapEntity(subscriberTransactionDetailDTO);
            mapping.CreatedDate = DateTime.UtcNow;
            SubscriberTransactionDetail result = await _unitOfWork.Repository<SubscriberTransactionDetail>().Update(mapping);
            if (result == null)
            {
                return null;
            }
            return Utility<SubscriberTransactionDetail, SubscriberTransactionDetailDTO>.MapEntity(result);
        }
    }
}
