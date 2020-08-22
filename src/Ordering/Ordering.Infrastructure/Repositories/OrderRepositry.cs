using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepositry: Repository<Order>, IOrderRepository
    {
        private readonly OrderContext _dbContext;

        public OrderRepositry(OrderContext dbContext): base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Order>> GetOrderByUserName(string userName)
        {
            var orderList = await _dbContext.Orders.Where(x=>x.UserName==userName).ToListAsync();
            return orderList;
        }
    }
}
