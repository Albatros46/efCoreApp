using efCoreApp.Entities;
using efCoreApp.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SelectPdf;

namespace efCoreApp.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _dataContext;

        public OgrenciController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task< IActionResult> Index()
        {
            var ogrenciler=await  _dataContext.Ogrenciler.ToListAsync();//veya
            return View(ogrenciler);
            //return View(await _dataContext.Ogrenciler.ToListAsync()); //bu sekilde de yapilabilir
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Ogrenciler.Add(model);
                await _dataContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id==null)
            {
                return NotFound();
            }
     //       var ogr=await _dataContext.Ogrenciler.FindAsync(id);
            var ogr=await _dataContext.Ogrenciler.FirstOrDefaultAsync(o=>o.OgrenciId==id);//diger kullanim sekli. farkli türde filtreleme yapilailir bu sekilde
            if (ogr==null)
            {
                return NotFound();
            }
            return View(ogr);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]//Kullanici adina islem yapilmasini önlemek icin ( Crossigt Attack ) önlmek icin.
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            if (id != model.OgrenciId)
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
                    if (!_dataContext.Ogrenciler.Any(ogr => ogr.OgrenciId == model.OgrenciId))
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

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ogr = await _dataContext.Ogrenciler.FindAsync(id);
            if (ogr==null)
            {
                return NotFound();
            }
            return View(ogr);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {/*//https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-7.0
          fordan gelen id yi paramaterede karsilamak icin model binding kullanilarak [FromForm] ile karsilanacak
          */
            var ogr = await _dataContext.Ogrenciler.FindAsync(id);
            if (ogr == null)
            {
                return NotFound();
            }
            _dataContext.Ogrenciler.Remove(ogr);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
