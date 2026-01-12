namespace UserTask.Application.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}