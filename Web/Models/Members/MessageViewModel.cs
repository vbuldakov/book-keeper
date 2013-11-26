using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Members
{
    public enum MessageStatus : int
    {
        Success,
        Info,
        Warning,
        Error
    }

    public class MessageViewModel
    {
        public MessageStatus Status { get; set; }        
        public string Message { get; set; }
    }
}