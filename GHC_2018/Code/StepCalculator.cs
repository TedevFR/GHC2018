using GHC_2018.Code.Entities;

namespace GHC_2018.Code
{
    public static class StepCalculator
    {
        public static int CalculateStepAfterRide(Car car, Ride ride)
        {
            var stepsToGoToRide = CalculateStepsFromCarToRideStart(car, ride);
            var waitTime = CalculateWaitTime(car, ride);
            return car.OccupiedUntil + stepsToGoToRide + waitTime + ride.RidePointsWithoutBonus;
        }

        public static int CalculateWaitTime(Car car, Ride ride)
        {
            var stepsFromCarToRideStart = CalculateStepsFromCarToRideStart(car, ride);
            var waitTime = ride.RideEarliestStart - (car.OccupiedUntil + stepsFromCarToRideStart);

            if (waitTime < 0)
                return 0;
            else
                return waitTime;
        }

        public static int CalculateStepsFromCarToRideStart(Car car, Ride ride)
        {
            return DistanceCalulator.CalculateDistance(car.CurrentRow, car.CurrentColumn, ride.RideStartRow, ride.RideStartColumn);
        }
    }
}