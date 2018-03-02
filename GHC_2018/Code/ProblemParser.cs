using GHC.Parsing;
using GHC_2018.Code.Entities;

namespace GHC_2018.Code
{
    public class ProblemParser
    {
        private readonly string _path;

        public ProblemParser(string path)
        {
            _path = path;
        }

        public ProblemData Parse()
        {
            var problemData = new ProblemData();

            using (var parser = new Parser(_path))
            {
                ParseFirstLine(problemData, parser);
                ParseAllRides(problemData, parser);
                InitCars(problemData);
            }

            return problemData; 
        }

        private void InitCars(ProblemData problemData)
        {
            for (int i = 0; i < problemData.NumberOfVehicles; ++i)
            {
                problemData.Cars.Add(new Car());
            }
        }

        private void ParseAllRides(ProblemData problemData, Parser parser)
        {
            for (int i = 0; i < problemData.NumberOfRides; ++i)
            {
                var rideLine = parser.GetIntsOfLine();

                var ride = new Ride();
                ride.Id = i;
                ride.RideStartRow = rideLine[0];
                ride.RideStartColumn = rideLine[1];
                ride.RideFinishRow = rideLine[2];
                ride.RideFinishColumn = rideLine[3];
                ride.RideEarliestStart = rideLine[4];
                ride.RideLatestFinish = rideLine[5];

                problemData.RidesToDo.Add(ride);
            }
        }

        private void ParseFirstLine(ProblemData problemData, Parser parser)
        {
            var firstLineInts = parser.GetIntsOfLine();

            problemData.NumberOfRows = firstLineInts[0];
            problemData.NumberOfColumns = firstLineInts[1];
            problemData.NumberOfVehicles = firstLineInts[2];
            problemData.NumberOfRides = firstLineInts[3];
            problemData.PerRideBonus = firstLineInts[4];
            problemData.NumberOfSteps = firstLineInts[5];
        }
    }
}