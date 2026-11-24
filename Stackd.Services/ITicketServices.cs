using Stackd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stackd.Services
{
    //Anica Janjic 991799177
    //this is used to specify what methods exist for ticket feature
    public interface ITicketServices
    {
        //this is used to return a list of all submitted tickets
        IEnumerable<Ticket> GetTickets();

        //this is used to add ticket and then save into the database
        Ticket AddTicket(Ticket ticket);
    }
}
