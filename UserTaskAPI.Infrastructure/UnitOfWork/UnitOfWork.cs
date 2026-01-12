using UserTask.Application.Interfaces;
using UserTask.Infrastructure.Data;

namespace UserTask.Infrastructure.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{ 
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
} 