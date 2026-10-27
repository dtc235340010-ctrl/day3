using day3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace day3.Models
{
    public class ComputerController : Controller
    {
        // gia lap csdl
        public static List<Computer> Computers = new List<Computer>()
        {
          new Computer() { Id = 1,Name ="Laptop" },
          new Computer (){ Id = 2,Name ="Phone" },
          new Computer() { Id = 3,Name = "Tablet" },
        };
        // GET: ComputerController
        public ActionResult Index(int id)
        {
            return View(Computers);
        }

        // GET: ComputerController/Details/5
        public ActionResult Details(int id)
        {
            var computer = Computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }


           

        // GET: ComputerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Computer computer)
        {
            computer.Id = Computers.Count + 1;
            Computers.Add(computer);
            return RedirectToAction(nameof(Index)); 

           
        }

        // GET: ComputerController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditComputer = Computers.FirstOrDefault(c => c.Id == id);
            if (EditComputer == null)
            {
                return NotFound();
            }
            return View(EditComputer);
        }

          
            
        

        // POST: ComputerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Computer computer)
        {
            var existingCategory = Computers.FirstOrDefault(c => c.Id == computer.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = computer.Name;

            return RedirectToAction(nameof(Index));
        }

        

        // GET: ComputerController/Delete/5
        public ActionResult Delete(int id)
        {
            var computer = Computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(   computer);
        }

      

        // POST: ComputerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var category = Computers.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            Computers.Remove(category);
            return RedirectToAction(nameof(Index));
        }

        }
    }

