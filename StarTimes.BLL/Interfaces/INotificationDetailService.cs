using StarTimes.BLL.DTO;
using StarTimes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarTimes.BLL.Interfaces
{
    public interface INotificationDetailService
    {

        NotificationDetailDTO GetById(int id);

        Task<List<NotificationDetailDTO>> GetAll(Expression<Func<NotificationDetail, bool>> expression);
        Task<List<NotificationDetailDTO>> GetAll();

        Task<NotificationDetailDTO> Create(NotificationDetailDTO notificationDetailDTO);
        Task<NotificationDetailDTO> Update(NotificationDetailDTO notificationDetailDTO);
        Task<NotificationDetailDTO> SearchClientAsync(Expression<Func<NotificationDetail, bool>> expression);
        Task<NotificationDetailDTO> SearchClientAsync(string objInclude, Expression<Func<NotificationDetail, bool>> expression);
    }
}
