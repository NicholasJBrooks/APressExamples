using Microsoft.EntityFrameworkCore;
using SportsStore.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx; 
        }
        public IQueryable<Order> orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Products);
    }
}
