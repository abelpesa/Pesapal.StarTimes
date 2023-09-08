using StarTimes.BLL.DTO;
using StarTimes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarTimes.BLL.Interfaces
{
   public interface ISubscriberTransactionDetailService
    {
        SubscriberTransactionDetailDTO GetById(int id);

        Task<List<SubscriberTransactionDetailDTO>> GetAll(Expression<Func<SubscriberTransactionDetail, bool>> expression);
        Task<List<SubscriberTransactionDetailDTO>> GetAll();
        Task<List<SubscriberTransactionDetailDTO>> GetAllData(TransactionAdminSearchRequestDTO transactionAdminSearchRequest);

        Task<SubscriberTransactionDetailDTO> Create(SubscriberTransactionDetailDTO subscriberTransactionDetailDTO);
        Task<SubscriberTransactionDetailDTO> Update(SubscriberTransactionDetailDTO subscriberTransactionDetailDTO);
        Task<SubscriberTransactionDetailDTO> SearchClientAsync(Expression<Func<SubscriberTransactionDetail, bool>> expression);
        Task<SubscriberTransactionDetailDTO> SearchClientAsync(string objInclude, Expression<Func<SubscriberTransactionDetail, bool>> expression);
    }
}
