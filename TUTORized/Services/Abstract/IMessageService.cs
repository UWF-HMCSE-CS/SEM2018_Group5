﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUTORized.Services.Abstract
{
    public interface IMessageService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
