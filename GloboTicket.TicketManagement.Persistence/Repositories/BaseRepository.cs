using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly GloboTicketDbContext context;

        public BaseRepository(GloboTicketDbContext context)
        {
            this.context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.context.Set<T>().Remove(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
