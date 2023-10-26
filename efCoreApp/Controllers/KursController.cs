using efCoreApp.Entities;
using efCoreApp.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace efCoreApp.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _dataContext;

        public KursController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task< IActionResult> Index()
        {
            var kurslar= await _dataContext.Kurslar.ToListAsync();
            return View(kurslar);
           // return View(await _dataContext.Kurslar.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kurs model)//SErver in asenkron (daha hizli) calismasini saglamak icin async olarak tanimladik
        {
            if (ModelState.IsValid)
            {
                 _dataContext.Kurslar.Add(model);
                await _dataContext.SaveChangesAsync();
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //   var kurs = await _dataContext.Kurslar.FirstOrDefaultAsync(o => o.KursId == id);//diger kullanim sekli. farkli türde filtreleme yapilailir bu sekilde
            var kurs =await _dataContext.Kurslar
                .Include(k=>k.KursKayitlari)
                .ThenInclude(k=>k.Ogrenci)
                .FirstOrDefaultAsync(k=>k.KursId==id);//sadece id ye gore arama filtreleme yapar.
            if (kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Kullanici adina islem yapilmasini önlemek icin ( Crossigt Attack ) önlmek icin.
        public async Task<IActionResult> Edit(int id,Kurs model)
        {
            if (id!=model.KursId)
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
                    if (!_dataContext.Kurslar.Any(kurs => kurs.KursId == model.KursId))
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
            var kurs = await _dataContext.Kurslar.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {/*//https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-7.0
          fordan gelen id yi paramaterede karsilamak icin model binding kullanilarak [FromForm] ile karsilanacak
          */
            var kurs = await _dataContext.Kurslar.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();
            }
            _dataContext.Kurslar.Remove(kurs);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
