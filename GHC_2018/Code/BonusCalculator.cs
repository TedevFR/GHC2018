using GHC_2018.Code.Entities;

namespace GHC_2018.Code
{
    public static class BonusCalculator
    {
        public static int CalculateBonus(Car car, Ride ride, int bonus)
        {
            var stepsToGoToRide = StepCalculator.CalculateStepsFromCarToRideStart(car, ride);

            return  ((car.OccupiedUntil + stepsToGoToRide) <= ride.RideEarliestStart) ? bonus : 0;
        }
    }
}