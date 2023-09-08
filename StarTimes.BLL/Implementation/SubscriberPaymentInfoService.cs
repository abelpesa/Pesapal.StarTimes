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
    public class SubscriberPaymentInfoService : ISubscriberPaymentInfoService
    {
        private IUnitOfWork _unitOfWork;

        public SubscriberPaymentInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SubscriberPaymentInfoDTO> Create(SubscriberPaymentInfoDTO subscriberPaymentInfoDTO)
        {
            if (subscriberPaymentInfoDTO == null)
            {
                return null;
            }

            SubscriberPaymentInfo subscriberPaymentInfo = Utility<SubscriberPaymentInfoDTO, SubscriberPaymentInfo>.MapEntity(subscriberPaymentInfoDTO);
            subscriberPaymentInfo.CreatedDate = DateTime.UtcNow;
            SubscriberPaymentInfo result = await _unitOfWork.Repository<SubscriberPaymentInfo>().Create(subscriberPaymentInfo);
            if (result == null)
            {

                return null;

            }

            return Utility<SubscriberPaymentInfo, SubscriberPaymentInfoDTO>.MapEntity(result);
        }

        public async Task<List<SubscriberPaymentInfoDTO>> GetAll(Expression<Func<SubscriberPaymentInfo, bool>> expression)
        {
            List<SubscriberPaymentInfo> subscriberPaymentInfos = await _unitOfWork.Repository<SubscriberPaymentInfo>().GetAll(null, expression);

            if (!subscriberPaymentInfos.Any())
            {
                return new List<SubscriberPaymentInfoDTO>();
            }
            var subscriberPaymentInfoDTOs = new List<SubscriberPaymentInfoDTO>();
            int totalItems = subscriberPaymentInfos.Count;
            for (int i = 0; i < totalItems; i++)
            {

                subscriberPaymentInfoDTOs.Add(new SubscriberPaymentInfoDTO
                {
                    Id = subscriberPaymentInfos[i].Id,
                    ContactAddress = subscriberPaymentInfos[i].ContactAddress,
                    BasicOfferBusinessClass = subscriberPaymentInfos[i].BasicOfferBusinessClass,
                    BasicOfferDisplayName = subscriberPaymentInfos[i].BasicOfferDisplayName,
                    CustomerName = subscriberPaymentInfos[i].CustomerName,
                    Mobile = subscriberPaymentInfos[i].Mobile,
                    OtherInfo = subscriberPaymentInfos[i].OtherInfo,
                    Reference = subscriberPaymentInfos[i].Reference,
                    ServiceCode = subscriberPaymentInfos[i].ServiceCode,
                    SubsciberId = subscriberPaymentInfos[i].SubsciberId,
                    SubscriberStatus = subscriberPaymentInfos[i].SubscriberStatus,
                });
            }

            return subscriberPaymentInfoDTOs;
        }

        public async Task<List<SubscriberPaymentInfoDTO>> GetAll()
        {
            List<SubscriberPaymentInfo> subscriberPaymentInfos = await _unitOfWork.Repository<SubscriberPaymentInfo>().GetAll(null);

            if (!subscriberPaymentInfos.Any())
            {
                return new List<SubscriberPaymentInfoDTO>();
            }
            var subscriberPaymentInfoDTOs = new List<SubscriberPaymentInfoDTO>();
            int totalItems = subscriberPaymentInfos.Count;
            for (int i = 0; i < totalItems; i++)
            {

                subscriberPaymentInfoDTOs.Add(new SubscriberPaymentInfoDTO
                {
                    Id = subscriberPaymentInfos[i].Id,
                    ContactAddress = subscriberPaymentInfos[i].ContactAddress,
                    BasicOfferBusinessClass = subscriberPaymentInfos[i].BasicOfferBusinessClass,
                    BasicOfferDisplayName = subscriberPaymentInfos[i].BasicOfferDisplayName,
                    CustomerName = subscriberPaymentInfos[i].CustomerName,
                    Mobile = subscriberPaymentInfos[i].Mobile,
                    OtherInfo = subscriberPaymentInfos[i].OtherInfo,
                    Reference = subscriberPaymentInfos[i].Reference,
                    ServiceCode = subscriberPaymentInfos[i].ServiceCode,
                    SubsciberId = subscriberPaymentInfos[i].SubsciberId,
                    SubscriberStatus = subscriberPaymentInfos[i].SubscriberStatus,
                });
            }

            return subscriberPaymentInfoDTOs;
        }

        public SubscriberPaymentInfoDTO GetById(int id)
        {
            SubscriberPaymentInfo result = _unitOfWork.Repository<SubscriberPaymentInfo>().GetById(id);

            if (result == null)
            {
                return null;
            }

            return Utility<SubscriberPaymentInfo, SubscriberPaymentInfoDTO>.MapEntity(result);
        }

        public async Task<SubscriberPaymentInfoDTO> SearchClientAsync(Expression<Func<SubscriberPaymentInfo, bool>> expression)
        {
            SubscriberPaymentInfo result = await _unitOfWork.Repository<SubscriberPaymentInfo>().AdvancedSearchFilterAsync(expression);

            if (result == null)
            {
                return null;
            }

            return Utility<SubscriberPaymentInfo, SubscriberPaymentInfoDTO>.MapEntity(result);
        }

        public async Task<SubscriberPaymentInfoDTO> SearchClientAsync(string objInclude, Expression<Func<SubscriberPaymentInfo, bool>> expression)
        {
            SubscriberPaymentInfo result = (SubscriberPaymentInfo)await _unitOfWork.Repository<SubscriberPaymentInfo>().AdvancedSearchFilterAsync(objInclude, expression);

            if (result == null)
            {
                return null;
            }

            return Utility<SubscriberPaymentInfo, SubscriberPaymentInfoDTO>.MapEntity(result);
        }

        public async Task<SubscriberPaymentInfoDTO> Update(SubscriberPaymentInfoDTO subscriberPaymentInfoDTO)
        {
            if (subscriberPaymentInfoDTO == null)
            {
                return null;
            }

            SubscriberPaymentInfo mapping = Utility<SubscriberPaymentInfoDTO, SubscriberPaymentInfo>.MapEntity(subscriberPaymentInfoDTO);
            mapping.CreatedDate = DateTime.UtcNow;
            SubscriberPaymentInfo result = await _unitOfWork.Repository<SubscriberPaymentInfo>().Update(mapping);
            if (result == null)
            {
                return null;
            }
            return Utility<SubscriberPaymentInfo, SubscriberPaymentInfoDTO>.MapEntity(result);
        }
    }
}
