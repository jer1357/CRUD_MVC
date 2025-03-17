using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD_MVC_Demo.Services;
using CRUD_MVC_Demo.Models;

namespace CRUD_MVC_Demo.Controllers
{
    public class ShippersController : Controller
    {
        private readonly IShipperService _shipperService;

        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        // 📌 GET: Shippers（顯示所有貨運公司）
        public async Task<IActionResult> Index()
        {
            var shippers = await _shipperService.GetAllShippersAsync();
            return View(shippers);
        }

        // 📌 GET: Shippers/Details/5（顯示特定貨運公司詳情）
        public async Task<IActionResult> Details(int id)
        {
            var shipper = await _shipperService.GetShipperByIdAsync(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        // 📌 GET: Shippers/Create（顯示新增貨運公司表單）
        public IActionResult Create()
        {
            return View();
        }

        // 📌 POST: Shippers/Create（處理表單提交）
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName,Phone")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                await _shipperService.CreateShipperAsync(shipper);
                return RedirectToAction(nameof(Index));
            }
            return View(shipper);
        }

        // 📌 GET: Shippers/Edit/5（顯示編輯貨運公司表單）
        public async Task<IActionResult> Edit(int id)
        {
            var shipper = await _shipperService.GetShipperByIdAsync(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        // 📌 POST: Shippers/Edit/5（處理編輯提交）
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipperId,CompanyName,Phone")] Shipper shipper)
        {
            if (id != shipper.ShipperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _shipperService.UpdateShipperAsync(shipper);
                if (!success)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shipper);
        }

        // 📌 GET: Shippers/Delete/5（顯示刪除確認頁面）
        public async Task<IActionResult> Delete(int id)
        {
            var shipper = await _shipperService.GetShipperByIdAsync(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        // 📌 POST: Shippers/Delete/5（執行刪除）
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _shipperService.DeleteShipperAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}