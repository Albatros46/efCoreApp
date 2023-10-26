using efCoreApp.Entities;
using efCoreApp.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efCoreApp.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly DataContext _dataContext;

        public OgretmenController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task< IActionResult> Index()
        {

            return View(await _dataContext.Ogretmenler.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Ogretmenler.Add(model);
                await _dataContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}
