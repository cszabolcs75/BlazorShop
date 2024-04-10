namespace Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
    }
}