namespace January2024_technical.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }

        void Save();
    }
}
