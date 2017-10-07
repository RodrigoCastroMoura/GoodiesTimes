namespace GoodiesTime.Domain.UnityOfWork
{
    public interface IUnitiOfWork
    {
        void SaveChanges();

        void Dispose();
    }
}
