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


        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var entity = await _dataContext.Ogretmenler
                              .FirstOrDefaultAsync(o => o.OgretmenId == id);
            //.FindAsync(id);
            //     var ogr=await _dataContext.Ogrenciler.FirstOrDefaultAsync(o=>o.OgrenciId==id);//diger kullanim sekli. farkli türde filtreleme yapilailir bu sekilde
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Kullanici adina islem yapilmasini önlemek icin ( Crossigt Attack ) önlmek icin.
        public async Task<IActionResult> Edit(int id, Ogretmen model)
        {
            if (id != model.OgretmenId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(model);//isaretleme yapildi
                    await _dataContext.SaveChangesAsync();//Güncelleme gerceklesiyor
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataContext.Ogretmenler.Any(ogr => ogr.OgretmenId == model.OgretmenId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("Index");
            }
            //Günceleme yoksa gelen modeli direkt gonderecek
            return View(model);
        }
    }
}
