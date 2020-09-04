using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buisness.Services;
using Microsoft.AspNetCore.Mvc;

namespace Stores.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreService _storeService;
        public StoreController(StoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet]
        public async Task<IActionResult> StoreList()
        => View(await _storeService.GetStores());
    }
}
