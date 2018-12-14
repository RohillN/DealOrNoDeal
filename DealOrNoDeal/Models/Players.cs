using System;

namespace DealOrNoDeal.Models
{
    public class Players : IComparable<Players>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Interest { get; set; }

        public int CompareTo(Players player)
        {
            return this.LastName.CompareTo(player.LastName);
        }
    }
}
