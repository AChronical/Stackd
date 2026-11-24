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
        //Thiis creates the reference too the ticket service class (dependency injection)
        private ITicketServices _ticketServices;

        //constructor to pass all the services classes implementations
        public StackdController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

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
    }
}
