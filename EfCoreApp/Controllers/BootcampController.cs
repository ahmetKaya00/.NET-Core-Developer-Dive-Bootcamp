using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class BootcampController : Controller
    {

        private readonly DataContext _context;

        public BootcampController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurslar.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bootcamp model)
        {
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var btc = await _context.Kurslar.Include(b=>b.KursKayitlari).ThenInclude(k=>k.Ogrenci).FirstOrDefaultAsync(o=>o.BootcampId == id);
            if (btc == null)
            {
                return NotFound();
            }
            return View(btc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bootcamp model)
        {
            if (id != model.BootcampId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Kurslar.Any(o => o.BootcampId == model.BootcampId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var bootcamp = await _context.Kurslar.FindAsync(id);
            if(bootcamp == null){
                return NotFound();
            }

            return View(bootcamp);
        }

        [HttpPost]

        public async Task<IActionResult> Delete([FromForm]int id){
            var bootcamp = await _context.Kurslar.FindAsync(id);

            if(bootcamp ==null){
                return NotFound();
            }
            
            _context.Kurslar.Remove(bootcamp);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}