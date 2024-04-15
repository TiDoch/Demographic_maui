using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardocheDespagne_MAUI_demo.Models
{
    public class Personne
    {
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Ddn { get; set; }
        public int Nunero { get; set; }
        public string Photo { get; set;}
        [Ignore]
        public string FullName => $"{FirstName} {LastName}";
    }
}
