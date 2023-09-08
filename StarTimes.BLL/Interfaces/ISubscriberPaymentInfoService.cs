using StarTimes.BLL.DTO;
using StarTimes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarTimes.BLL.Interfaces
{
   public interface ISubscriberPaymentInfoService
    {
        SubscriberPaymentInfoDTO GetById(int id);

        Task<List<SubscriberPaymentInfoDTO>> GetAll(Expression<Func<SubscriberPaymentInfo, bool>> expression);
        Task<List<SubscriberPaymentInfoDTO>> GetAll();

        Task<SubscriberPaymentInfoDTO> Create(SubscriberPaymentInfoDTO subscriberPaymentInfoDTO);
        Task<SubscriberPaymentInfoDTO> Update(SubscriberPaymentInfoDTO subscriberPaymentInfoDTO);
        Task<SubscriberPaymentInfoDTO> SearchClientAsync(Expression<Func<SubscriberPaymentInfo, bool>> expression);
        Task<SubscriberPaymentInfoDTO> SearchClientAsync(string objInclude, Expression<Func<SubscriberPaymentInfo, bool>> expression);
    }
}
