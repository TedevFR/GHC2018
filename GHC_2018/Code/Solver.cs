using GHC_2018.Code;
using GHC_2018.Code.Entities;
using MoreLinq;
using System;
using System.Linq;

namespace GHC_2018
{
    public class Solver
    {
        private string _inputFilePath;
        private string _outputFilePath;

        private ProblemData _problemData;

        public Solver(string inputFilePath, string outputFilePath)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
        }

        public void Solve()
        {
            ParseInput();
            DoTheMagic();
            CreateOutput();
            DisplayPoints();
        }

        private void DoTheMagic()
        {
            while (MoveACar()) ;
        }

        private bool MoveACar()
        {
            var orderedCars = _problemData.Cars.OrderBy(x => x.OccupiedUntil);

            foreach (var car in orderedCars)
            {
                _problemData.RidesToDo.ForEach(r => r.CalculateMagicRatio(car, _problemData));

                var orderedRides = _problemData.RidesToDo
                    .Where(r => r.MagicNumber > 0F)
                    .OrderByDescending(r => r.MagicNumber)
                    .ToList();

                if(orderedRides.Any())
                {
                    AssignRideToCar(orderedRides.First(), car);
                    return true;
                }

                _problemData.CarsWhichCanTMoveAnymore.Add(car);
                _problemData.Cars.Remove(car);
            }

            return false;
        }

        private void AssignRideToCar(Ride ride, Car car)
        {
            ride.GotBonus = BonusCalculator.CalculateBonus(car, ride, _problemData.PerRideBonus) > 0;

            car.Rides.Add(ride);
            car.OccupiedUntil = StepCalculator.CalculateStepAfterRide(car, ride);
            car.CurrentColumn = ride.RideFinishColumn;
            car.CurrentRow = ride.RideFinishRow;

            
            _problemData.RidesToDo.Remove(ride);
        }

        private void ParseInput()
        {
            var problemParser = new ProblemParser(_inputFilePath);
            _problemData = problemParser.Parse();
        }

        private void CreateOutput()
        {
            var solutionSerializer = new SolutionSerializer(_outputFilePath);
            solutionSerializer.Serialize(_problemData);
        }

        private void DisplayPoints()
        {
            int nbRide = 0;
            int score = 0;

            foreach (var car in _problemData.CarsWhichCanTMoveAnymore)
            {
                foreach (var ride in car.Rides)
                {
                    nbRide++;
                    score += ride.RidePointsWithoutBonus;
                    score += ride.GotBonus ? _problemData.PerRideBonus : 0;
                }
            }

            Console.WriteLine(_inputFilePath);
            Console.WriteLine($"{score} points");
            Console.WriteLine($"{nbRide}/{_problemData.NumberOfRides} rides done with {_problemData.NumberOfVehicles} cars");
            Console.WriteLine($"{nbRide/(float)_problemData.NumberOfVehicles} rides per car");
            Console.WriteLine(string.Empty);
        }
    }
}