using basics.Models;
using Microsoft.AspNetCore.Mvc;
namespace basics.Controllers;

public class BootcampController: Controller{

    public IActionResult Index(){
        var bootcamp = new Bootcamp();
        bootcamp.Id = 1;
        bootcamp.Title = "AspNet Core Bootcamp";
        bootcamp.Description = "3 hafta sürecek bir eğitim.";
        bootcamp.Image = "1.png";
        return View(bootcamp);
    }

    public IActionResult Details(int? id){
        if(id==null){
            return RedirectToAction("List","Bootcamp");
        }
        var bootcamp = Repository.GetById(id);
        return View(bootcamp);
    }
    public IActionResult List(){
        return View(Repository.Bootcamps);
    }
}