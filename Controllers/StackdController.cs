using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stackd.Entities;
using Stackd.Services;
using System.Security.Claims;

namespace Stackd.Operations.Controllers
{
    //Anica Janjic 991799177 - Ticket and User information
    [Route("Stackd")]
    public class StackdController : Controller
    {
        //This creates the reference to the user service class (dependency injection)
        private ITicketServices _ticketServices;

        //This creates the reference to the user service class (dependency injection)
        private IUserServices _userServices;

        //constructor to pass all the services classes implementations
        public StackdController(ITicketServices ticketServices, IUserServices userServices)
        {
            _ticketServices = ticketServices;
            _userServices = userServices;
        }

        //This is the ticket portion:
        //this is used to fetch the ticket data from service class and pass to the ShowTickets page
        [HttpGet("ShowTickets")]
        [HttpGet("TicketList")]
        public IActionResult ShowTickets()
        {
            return View(_ticketServices.GetTickets());
        }

        //this is used to display the empty create ticket form
        [HttpGet("CreateTicket")]
        [HttpGet("NewTicket")]
        public IActionResult AddTicket()
        {
            return View();
        }

        //This is used to post the information submitted from the ticket form into the database and display it
        [HttpPost("CreateTicket")]
        [HttpPost("NewTicket")]
        public IActionResult AddTicket(Ticket ticket)
        {
            //This is used to verify the user is logged in and then grab their UserId and save it onto the ticket
            ticket.UserId = int.Parse(User.FindFirst("UserId")!.Value);
            //this is used to ensure there is no UserId error that arises as it is not meant to be inputted
            ModelState.Remove(nameof(Ticket.UserId));

            //checks all the validation rules for the ticket form passed
            if (ModelState.IsValid)
            {
                //adds and saves the new ticket data to the service class and displays it into the ShowTickets page
                _ticketServices.AddTicket(ticket);
                return RedirectToAction("ShowTickets");
            }

            return View(ticket);
        }

        //This is the user portion:
        //this is used to display the users profile page
        [HttpGet("Profile")]
        [HttpGet("UserProfile")]
        public IActionResult Profile()
        {
            //this is used to confirm the user is logged in before displaying information
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            //fetches the user record from the service layer
            var user = _userServices.GetUserById(userId.Value);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        //this is used to display the users profile page prior to update changes
        [HttpGet("UpdateUser")]
        public IActionResult Update()
        {
            //this is used to confirm the user is logged in before displaying information
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            //fetches the user record from the service layer
            var user = _userServices.GetUserById(userId.Value);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        //this is used to save the updated profile information and redirect back to the profile page
        [HttpPost("UpdateUser")]
        public IActionResult Update(User updatedUser)
        {
            //this is used to confirm the user is logged in before displaying information
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            //this is used to ensure there is no UserId error that arises as it is not meant to be inputted
            //I needed to implement 'Stackd.Entities' as User already exists as a method within the system, i needed to specify to use my class
            updatedUser.UserId = userId.Value;
            ModelState.Remove(nameof(Stackd.Entities.User.UserId));

            //this is uses to ensure all validation rules have passed 
            if (ModelState.IsValid)
            {
                //updates the user in the database and then redirects to the profile page
                _userServices.UpdateUser(updatedUser);
                return RedirectToAction("Profile");
            }

            return View(updatedUser);
        }

        //this is used to display the login page to access profile page
        [HttpGet("Login")]
        [HttpGet("SignIn")]
        public IActionResult Login()
        {
            return View();
        }

        //this is used to allow users to login and verify if the login is correct by User Id
        [HttpPost("Login")]
        [HttpPost("SignIn")]
        public IActionResult Login(string email, string password)
        {
            //this is used to check that both email and password were entered for login
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "Email and password are required.");
                //I needed to implement 'Stackd.Entities' as User already exists as a method within the system, i needed to specify to use my class
                return View("Login", new Stackd.Entities.User { Email = email });
            }

            //this is used to verify the users through the service class
            var user = _userServices.Login(email, password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View("Login", new Stackd.Entities.User { Email = email });
            }

            //this is used to save the user and ensure they remain logged in and then directs to profile page
            HttpContext.Session.SetInt32("UserId", user.UserId);
            return RedirectToAction("ProfilePage");
        }

        //this is used to display the empty create ticket form
        [HttpGet("Register")]
        [HttpGet("SignUp")]
        public IActionResult Register()
        {
            return View();
        }

        //This is used to post the information submitted from the registration form into the database and display it
        [HttpPost("Register")]
        [HttpPost("SignUp")]
        public IActionResult Register(User user)
        {
            //this is used to ensure there is no UserId error that arises as it is not meant to be inputted
            //I needed to implement 'Stackd.Entities' as User already exists as a method within the system, i needed to specify to use my class
            ModelState.Remove(nameof(Stackd.Entities.User.UserId));

            //checks all the validation rules for the registration form passed
            if (ModelState.IsValid)
            {
                //adds and saves the new user data through the service class and redirects to Profile page
                _userServices.Register(user);
                return RedirectToAction("ProfilePage");
            }

            return View(user);
        }

    }
}
