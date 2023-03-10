using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);

        void UpdateOrderStatus(int OrderId, string orderStatus, string? paymentStatus = null);
        void UpdateStripePaymentId(int OrderId, string sessionId, string paymentItentId);
    }
}
