using System.Collections.Generic;

namespace GHC_2018.Code.Entities
{
    public class Car
    {
        public int OccupiedUntil = 0;
        public int CurrentRow { get; set; } = 0;
        public int CurrentColumn { get; set; } = 0;

        public List<Ride> Rides { get; set; } = new List<Ride>();
    }
}