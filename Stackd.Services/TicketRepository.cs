using Microsoft.EntityFrameworkCore;
using Stackd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stackd.Services
{
    //Anica Janjic 991799177
    //This is used to implement our methods that are being called in the Controller class.
    //Creating the methods here, so it doesn't directly interact with our database directly.
    public class TicketRepository : ITicketServices
    {
        //holds the database context used for saving data
        private readonly StackdDb _context;

        //constructor to pass all the StackdDb implementations (dependency injection)
        public TicketRepository(StackdDb context)
        {
            _context = context;
        }

        //grabs all the submitted ticket data from the database into a list
        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.Include(t => t.User).ToList();
        }

        //adds the new ticket to the database and then displays it
        public Ticket AddTicket(Ticket ticket)
        {
            ticket.Status = "Open";
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }
    }
}
