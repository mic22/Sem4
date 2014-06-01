using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smtp
{
    public class PersonEntry
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }   
    }
    public class MailContentDefinition
    {
        public IEnumerable<PersonEntry> People { get; set; }
        public string Footer { get; set; }
    }
}
