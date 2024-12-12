using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnictiveTest.Data;
using UnictiveTest.Models;

namespace UnictiveTest.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: UserController
        public ActionResult Index()
        {
            var usersWithHobbies = _context.tUser
            .Include(u => u.UserHobbies)
            .ThenInclude(uh => uh.Hobby)
            .Select(u => new UserRead
            {
                fID = u.fID,
                fName = u.fName,
                fHobbies = u.UserHobbies.Select(uh => uh.Hobby.fHobby).ToList()
            })
            .ToList();

            return View(usersWithHobbies);
        }

        public IActionResult GetHobbies()
        {
            var hobbies = _context.tHobby.Select(h => new { h.fID, h.fHobby }).ToList();
            return Json(hobbies);  // Mengirim data hobbies dalam bentuk JSON
        }

        // GET: UserController/Details/5
        public ActionResult GetUser(int id)
        {
            var user = _context.tUser
            .Include(u => u.UserHobbies)
            .ThenInclude(uh => uh.Hobby)
            .Select(u => new UserRead
            {
                fID = u.fID,
                fName = u.fName,
                fHobbies = u.UserHobbies.Select(uh => uh.Hobby.fHobby).ToList()
            })
            .Where(u => u.fID == id)
            .ToList();

            if (user == null)
            {
                return NotFound();
            }

            //var userDto = new UserDtoModel
            //{
            //    Id = user.Id,
            //    Name = user.Name,
            //    UserHobbies = user.UserHobbies.Select(uh => new UserHobbyDto
            //    {
            //        HobbyId = uh.HobbyId,
            //        HobbyName = uh.Hobby.Name
            //    }).ToList()
            //};

            return Ok(user);
        }

        // GET: UserController/Create
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreate model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    fName = model.fName
                };

                _context.tUser.Add(user);
                await _context.SaveChangesAsync();

                var userHobbies = model.fHobbyID.Select(hobbyId => new UserHobby
                {
                    fUserID = user.fID,
                    fHobbyID = hobbyId
                }).ToList();

                _context.tUserHobby.AddRange(userHobbies);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserCreate model)
        {
            var user = await _context.tUser.Include(u => u.UserHobbies)
                                            .ThenInclude(uh => uh.Hobby)
                                            .FirstOrDefaultAsync(u => u.fID == id);

            if (user == null)
                return NotFound();

            user.fName = model.fName;

            var existingHobbies = _context.tUserHobby.Where(uh => uh.fUserID == id);
            _context.tUserHobby.RemoveRange(existingHobbies);

            if (model.fHobbyID != null && model.fHobbyID.Any())
            {
                var userHobbies = model.fHobbyID.Select(hobbyId => new UserHobby
                {
                    fUserID = user.fID,
                    fHobbyID = hobbyId
                }).ToList();

                _context.tUserHobby.AddRange(userHobbies);
            }

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
