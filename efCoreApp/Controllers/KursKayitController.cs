using efCoreApp.Entities;
using efCoreApp.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efCoreApp.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _dataContext;

        public KursKayitController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var kursKayitlari = await _dataContext.KursKayits
                .Include(x=>x.Ogrenci)
                .Include(k=>k.Kurs)
                
                .ToListAsync();
            //include: iliskili tablodaki herseyi yükle
            return View(kursKayitlari);
        }
        
        public async Task<IActionResult> Create()
        {
 
            ViewBag.Ogrenciler = new SelectList(await _dataContext.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
            //formdaki selectBox'a veri gondermek icin SelectList kullaniyoruz.
            ViewBag.Kurslar = new SelectList(await _dataContext.Kurslar.ToListAsync(), "KursId", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KursKayit model)
        {
        //    model.KayitTarihi =  DateTime.Now;
            _dataContext.KursKayits.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
