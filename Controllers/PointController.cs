using MapApplication;
using MapApplication.Models;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class PointController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	public PointController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	[HttpGet]
	public Response<List<CustomPoint>> GetAll()
	{
		var points = _unitOfWork.PointService.GetAll();
		return new Response<List<CustomPoint>>(points, true, "Points retrieved successfully");
	}

	[HttpGet("{id}")]
	public Response<CustomPoint> GetById(long id)
	{
		var point = _unitOfWork.PointService.GetById(id);
		if (point == null)
		{
			return new Response<CustomPoint>(null, false, "Point not found");
		}
		return new Response<CustomPoint>(point, true, "Point retrieved successfully");
	}

	[HttpPost]
	public Response<CustomPoint> Add(CustomPoint point)
	{
		var addedPoint = _unitOfWork.PointService.Add(point);
		_unitOfWork.SaveChanges();
		return new Response<CustomPoint>(addedPoint, true, "Point added successfully");
	}

	[HttpPut("{id}")]
	public Response<CustomPoint> Update(long id, CustomPoint updatedPoint)
	{
		var point = _unitOfWork.PointService.Update(id, updatedPoint);
		if (point == null)
		{
			return new Response<CustomPoint>(null, false, "Point not found");
		}
		_unitOfWork.SaveChanges();
		return new Response<CustomPoint>(point, true, "Point updated successfully");
	}

	[HttpDelete("{id}")]
	public Response<CustomPoint> Delete(long id)
	{
		var point = _unitOfWork.PointService.Delete(id);
		if (point == null)
		{
			return new Response<CustomPoint>(null, false, "Point not found");
		}
		_unitOfWork.SaveChanges();
		return new Response<CustomPoint>(point, true, "Point deleted successfully");
	}
}