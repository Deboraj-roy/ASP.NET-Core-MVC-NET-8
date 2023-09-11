using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
	[Area("admin")]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
			return View();
		}

		#region API CAllS

		[HttpGet]
		public IActionResult GetAll()
		{
			List<OrderHeader> objOrderHeaders = 
				_unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
			return Json(new { data = objOrderHeaders });
		}
		#endregion

	}
}
