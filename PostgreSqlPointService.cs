using MapApplication.Models;

namespace MapApplication
{
	public class PostgreSqlPointService : GenericService<CustomPoint>, IPointService
	{
		public PostgreSqlPointService(PointDbContext context) : base(context)
		{
		}
	}
}