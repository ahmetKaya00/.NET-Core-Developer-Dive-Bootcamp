using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers{

    public class BootcampKayitController : Controller{

        private readonly DataContext _context;

        public BootcampKayitController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult> index(){
            var BootcampKayit = await _context.KursKayitlari.Include(x=>x.Ogrenci).Include(x=>x.Bootcamp).ToListAsync();
            return View(BootcampKayit);
        }

        public async Task<IActionResult> Create(){
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId","AdSoyad");
            ViewBag.Bootcapms = new SelectList(await _context.Kurslar.ToListAsync(), "BootcampId","Baslik");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> create(BootcampKayit model){

            model.KayitTarihi = DateTime.Now;
            _context.KursKayitlari.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

    }
}