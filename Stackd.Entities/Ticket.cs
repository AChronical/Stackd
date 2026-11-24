using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Stackd.Entities.ValidationUtilities;

namespace Stackd.Entities
{
    // Anica Janjic 991799177
    //This class is used to hold the data for any ticket submitted to the site for any missing posts or information needed. It will inform the user the status of their current ticket.
    //I needed the foreign key value attached with the User so we could see who submitted the request
    //I needed to set the ticket status to open as the User cannot adjust or select the status of the ticket
    public class Ticket
    {
        [Key] public int TicketId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Submission date is required.")]
        [StackdDate(ErrorMessage = "Submission date must be today.")]
        [DataType(DataType.DateTime)]
        public DateTime DateSubmitted { get; set; } = DateTime.Now; 
        
        [Required(ErrorMessage = "Please select a ticket status.")]
        [StringLength(30, ErrorMessage = "Status cannot exceed 30 characters.")] 
        public string Status { get; set; } = "Submitted";

        [Required(ErrorMessage = "Please select a ticket type.")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")] 
        public string Type { get; set; } 

        [Required(ErrorMessage = "A valid User must be assigned to this ticket.")] 
        public int UserId { get; set; } 
        public User? User { get; set; }
    }
}
