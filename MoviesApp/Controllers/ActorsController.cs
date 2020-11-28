using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;
using System.Linq;

namespace MoviesApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MoviesContext _context;
        private readonly ILogger<HomeController> _logger;


        public ActorsController(MoviesContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Actors
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Actors.Select( m => new ActorViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Birthday = m.Birthday,
                Growth = m.Growth,
                Weight = m.Weight
            }).ToList());
        }

        // GET: Actors/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _context.Actors.Where(m => m.Id == id).Select(m => new ActorViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Birthday = m.Birthday,
                Growth = m.Growth,
                Weight = m.Weight
            }).FirstOrDefault();


            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Actors/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Birthday,Weight,Growth")] InputActorViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Actor
                {
                    FirstName = inputModel.FirstName,
                    LastName = inputModel.LastName,
                    Birthday = inputModel.Birthday,
                    Growth = inputModel.Growth,
                    Weight = inputModel.Weight
                });
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }

        [HttpGet]
        // GET: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editModel = _context.Actors.Where(m => m.Id == id).Select(m => new EditActorViewModel
            {
                FirstName = m.FirstName,
                LastName = m.LastName,
                Birthday = m.Birthday,
                Growth = m.Growth,
                Weight = m.Weight
            }).FirstOrDefault();

            if (editModel == null)
            {
                return NotFound();
            }

            return View(editModel);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FirstName,LastName,Birthday,Weight,Growth")] EditActorViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var actor = new Actor
                    {
                        FirstName = editModel.FirstName,
                        LastName = editModel.LastName,
                        Birthday = editModel.Birthday,
                        Growth = editModel.Growth,
                        Weight = editModel.Weight
                    };

                    _context.Update(actor);
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (!ActorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editModel);
        }

        [HttpGet]
        // GET: Actors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = _context.Actors.Where(m => m.Id == id).Select(m => new DeleteActorViewModel
            {
                FirstName = m.FirstName,
                LastName = m.LastName,
                Birthday = m.Birthday,
                Growth = m.Growth,
                Weight = m.Weight
            }).FirstOrDefault();

            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = _context.Actors.Find(id);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            _logger.LogError($"Actor with id {actor.Id} has been deleted!");
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
