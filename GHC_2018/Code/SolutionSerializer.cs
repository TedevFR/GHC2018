using GHC.Parsing;
using GHC_2018.Code.Entities;
using System.Text;

namespace GHC_2018.Code
{
    public class SolutionSerializer
    {
        private readonly string _outputPath;

        public SolutionSerializer(string outputPath)
        {
            _outputPath = outputPath;
        }

        public void Serialize(ProblemData problemData)
        {
            using (FileCreator fc = new FileCreator(_outputPath))
            {
                foreach(var car in problemData.CarsWhichCanTMoveAnymore)
                {
                    WriteCarLine(fc, car);
                }
            }
        }

        private void WriteCarLine(FileCreator fileCreator, Car car)
        {
            var sb = new StringBuilder();
            sb.Append(car.Rides.Count);
            string line = car.Rides.Count.ToString();

            foreach (var ride in car.Rides)
            {
                sb.Append(" ").Append(ride.Id);
            }

            fileCreator.WriteLine(sb.ToString());
        }
    }
}