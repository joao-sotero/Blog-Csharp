namespace Blog.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, new()
    {
        public IEnumerable<TEntity> GetAll();

        public TEntity Get(long id);

        public long Create(TEntity request);

        public bool Update(TEntity request);

        public bool Delete(long id);
    }
}