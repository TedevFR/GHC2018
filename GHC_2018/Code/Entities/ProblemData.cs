using System.Collections.Generic;

namespace GHC_2018.Code.Entities
{
    public class ProblemData
    {
        #region parse
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public int NumberOfVehicles { get; set; }
        public int NumberOfRides { get; set; }
        public int PerRideBonus { get; set; }
        public int NumberOfSteps { get; set; }

        public List<Ride> RidesToDo { get; } = new List<Ride>();
        #endregion

        public List<Car> Cars { get; } = new List<Car>();
        public List<Car> CarsWhichCanTMoveAnymore { get; } = new List<Car>();
    }
}