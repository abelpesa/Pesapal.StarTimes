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
    public class NotificationDetailService : INotificationDetailService
    {
        private IUnitOfWork _unitOfWork;

        public NotificationDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NotificationDetailDTO> Create(NotificationDetailDTO notificationDetailDTO)
        {
            if (notificationDetailDTO == null)
            {
                return null;
            }

            NotificationDetail notificationDetail = Utility<NotificationDetailDTO, NotificationDetail>.MapEntity(notificationDetailDTO);
            notificationDetail.CreatedDate = DateTime.UtcNow;
            NotificationDetail result = await _unitOfWork.Repository<NotificationDetail>().Create(notificationDetail);
            if (result == null)
            {

                return null;

            }

            return Utility<NotificationDetail, NotificationDetailDTO>.MapEntity(result);
        }

        public async Task<List<NotificationDetailDTO>> GetAll(Expression<Func<NotificationDetail, bool>> expression)
        {
            List<NotificationDetail> notificationDetails = await _unitOfWork.Repository<NotificationDetail>().GetAll(null, expression);

            if (!notificationDetails.Any())
            {
                return new List<NotificationDetailDTO>();
            }
            var additionalProductAttributeDTOs = new List<NotificationDetailDTO>();
            int totalItems = notificationDetails.Count;
            for (int i = 0; i < totalItems; i++)
            {

                additionalProductAttributeDTOs.Add(new NotificationDetailDTO
                {
                    Id = notificationDetails[i].Id,
                    UniqueId = notificationDetails[i].UniqueId

                });
            }

            return additionalProductAttributeDTOs;
        }

        public async Task<List<NotificationDetailDTO>> GetAll()
        {
            List<NotificationDetail> notificationDetails = await _unitOfWork.Repository<NotificationDetail>().GetAll(null);

            if (!notificationDetails.Any())
            {
                return new List<NotificationDetailDTO>();
            }
            var notificationDetailDTOs = new List<NotificationDetailDTO>();
            int totalItems = notificationDetails.Count;
            for (int i = 0; i < totalItems; i++)
            {

                notificationDetailDTOs.Add(new NotificationDetailDTO
                {
                    Id = notificationDetails[i].Id,
                  UniqueId = notificationDetails[i].UniqueId

                });
            }

            return notificationDetailDTOs;
        }

        public NotificationDetailDTO GetById(int id)
        {
            NotificationDetail result = _unitOfWork.Repository<NotificationDetail>().GetById(id);

            if (result == null)
            {
                return null;
            }

            return Utility<NotificationDetail, NotificationDetailDTO>.MapEntity(result);
        }

        public async Task<NotificationDetailDTO> SearchClientAsync(Expression<Func<NotificationDetail, bool>> expression)
        {
            NotificationDetail result = await _unitOfWork.Repository<NotificationDetail>().AdvancedSearchFilterAsync(expression);

            if (result == null)
            {
                return null;
            }

            return Utility<NotificationDetail, NotificationDetailDTO>.MapEntity(result);
        }

        public async Task<NotificationDetailDTO> SearchClientAsync(string objInclude, Expression<Func<NotificationDetail, bool>> expression)
        {
            NotificationDetail result = (NotificationDetail)await _unitOfWork.Repository<NotificationDetail>().AdvancedSearchFilterAsync(objInclude, expression);

            if (result == null)
            {
                return null;
            }

            return Utility<NotificationDetail, NotificationDetailDTO>.MapEntity(result);
        }

        public async Task<NotificationDetailDTO> Update(NotificationDetailDTO notificationDetailDTO)
        {
            if (notificationDetailDTO == null)
            {
                return null;
            }

            NotificationDetail mapping = Utility<NotificationDetailDTO, NotificationDetail>.MapEntity(notificationDetailDTO);
            mapping.CreatedDate = DateTime.UtcNow;
            NotificationDetail result = await _unitOfWork.Repository<NotificationDetail>().Update(mapping);
            if (result == null)
            {
                return null;
            }
            return Utility<NotificationDetail, NotificationDetailDTO>.MapEntity(result);
        }
    }
}
