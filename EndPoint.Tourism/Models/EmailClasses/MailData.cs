﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Models.EmailClasses
{
    public class MailData
    {
        public string Email { get; set; }
        public string EmailToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
