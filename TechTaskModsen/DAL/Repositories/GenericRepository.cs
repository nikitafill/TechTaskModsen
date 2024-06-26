﻿using Microsoft.EntityFrameworkCore;
using TechTaskModsen.DAL.Data;
using TechTaskModsen.DAL.Repositories.Interfaces;

namespace TechTaskModsen.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<List<TEntity>> GetListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _ = _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> DeleteAsync(TEntity entity)
        {
            _ = _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
