using System;
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
            try
            {
                var shippers = await _shipperService.GetAllShippersAsync();
                return View(shippers);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "發生錯誤，請稍後再試。");
                Console.WriteLine($"錯誤訊息: {ex.Message}");
                return View();
            }
        }

        // 📌 GET: Shippers/Details/5（顯示特定貨運公司詳情）
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var shipper = await _shipperService.GetShipperByIdAsync(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                return View(shipper);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "發生錯誤，請稍後再試。");
                Console.WriteLine($"錯誤訊息: {ex.Message}");
                return View();
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    await _shipperService.CreateShipperAsync(shipper);
                    return RedirectToAction(nameof(Index));
                }
                return View(shipper);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "無法新增貨運公司，請稍後再試。");
                Console.WriteLine($"錯誤訊息: {ex.Message}");
                return View(shipper);
            }
        }

        // 📌 GET: Shippers/Edit/5（顯示編輯貨運公司表單）
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var shipper = await _shipperService.GetShipperByIdAsync(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                return View(shipper);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "發生錯誤，請稍後再試。");
                Console.WriteLine($"錯誤訊息: {ex.Message}");
                return View();
            }
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
            try
            {
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", "無法更新貨運公司，請稍後再試。");
                Console.WriteLine($"錯誤訊息: {ex.Message}");
                return View(shipper);
            }
        }

        // 📌 GET: Shippers/Delete/5（顯示刪除確認頁面）
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var shipper = await _shipperService.GetShipperByIdAsync(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                return View(shipper);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "發生錯誤，請稍後再試。");
                Console.WriteLine($"錯誤訊息: {ex.Message}");
                return View();
            }
        }

        // 📌 POST: Shippers/Delete/5（執行刪除）
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _shipperService.DeleteShipperAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "無法刪除貨運公司，請稍後再試。");
                Console.WriteLine($"錯誤訊息: {ex.Message}");
                return View();
            }
        }
    }
}