using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserMVCApplication.BLL.IServices;
using UserMVCApplication.BLL.Models;
using UserMVCApplication.BLL.Services;
using UserMVCApplication.DAL.Context;
using UserMVCApplication.Web.Models;

namespace UserMVCApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStateService _stateService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUserService userService,
            IStateService stateService,
            ILogger<HomeController> logger)
        {
            _userService = userService;
            _stateService = stateService;
            _logger = logger;
        }

        #region Users
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }
        public async Task<IActionResult> CreateUser(string userId)
        {
            UserModel user = new UserModel();
            if (!string.IsNullOrEmpty(userId))
            {
                user = await _userService.GetUserDetailsById(Convert.ToInt32(userId));
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            try
            {
                if (user.Id == 0)
                {
                    await _userService.AddUser(user);
                }
                else
                {
                    await _userService.UpdateUser(user);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving user with Id: {UserId}", user.Id);
                ModelState.AddModelError("", "An unexpected error occurred while saving the user. Please try again.");
                return View(user);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var isDeleted = await _userService.DeleteUser(userId);

            if (!isDeleted)
            {
                return Json(new { success = false, message = "User not deleted." });
            }

            return Json(new { success = true, message = "User deleted successfully." });
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _userService.GetUserDetailsById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching user details for Id: {UserId}", id);
                return View("Error");
            }
        }

        #endregion

        #region States
        public async Task<JsonResult> GetAllStates()
        {
            var states = await _stateService.GetAllStates();
            if (states.Any())
            {
                return Json(states);
            }
            return new JsonResult(null);
        }
        #endregion
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
