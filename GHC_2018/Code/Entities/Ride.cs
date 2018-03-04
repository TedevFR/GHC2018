namespace GHC_2018.Code.Entities
{
    public class Ride
    {
        public int Id { get; set; }

        public int RideStartRow { get; set; }
        public int RideStartColumn { get; set; }
        public int RideFinishRow { get; set; }
        public int RideFinishColumn { get; set; }
        public int RideEarliestStart { get; set; }
        public int RideLatestFinish { get; set; }

        public bool GotBonus { get; set; } = false;

        public float MagicNumber { get; private set; }

        public int RidePointsWithoutBonus
            => DistanceCalulator.CalculateDistance(RideStartRow, RideStartColumn, RideFinishRow, RideFinishColumn);

        public void CalculateMagicRatio(Car car, ProblemData problemData)
        {
            var stepsToGoToRideStart = StepCalculator.CalculateStepsFromCarToRideStart(car, this);
            int waitTime = StepCalculator.CalculateWaitTime(car, this);
            var endRideStep = StepCalculator.CalculateStepAfterRide(car, this);

            // Si le trajet peut etre fini avant la fin de la simu
            // ou si le trajet peut etre fini avant la fin du ride
            if ((endRideStep >= problemData.NumberOfSteps)
                || (endRideStep >= RideLatestFinish))
            {
                MagicNumber = 0;
                return;
            }

            var bonus = BonusCalculator.CalculateBonus(car, this, problemData.PerRideBonus);
            var totalPoint = RidePointsWithoutBonus + bonus;
            var totalTime = stepsToGoToRideStart + waitTime + RidePointsWithoutBonus;
            var wastedTime = stepsToGoToRideStart + waitTime;
            float ponderation = 1F / (1F + wastedTime);

            MagicNumber = (totalPoint / (float)totalTime) * ponderation;
        }
    }
}