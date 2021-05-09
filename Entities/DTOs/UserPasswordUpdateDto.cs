using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class UserPasswordUpdateDto:IDto
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string currentPassword { get; set; }
    }
}
