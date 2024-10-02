namespace MapApplication
{
    public interface IUnitOfWork : IDisposable
	{
		IPointService PointService { get; }
		int SaveChanges();
	}
}
