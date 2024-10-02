using MapApplication.Models;

namespace MapApplication
{
	public interface IPointService
	{
		List<CustomPoint> GetAll();
		CustomPoint GetById(long id);
		CustomPoint Add(CustomPoint point);
		CustomPoint Update(long id, CustomPoint point);
		CustomPoint Delete(long id);
	}
}