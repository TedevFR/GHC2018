using System;

namespace GHC_2018.Code
{
    public static class DistanceCalulator
    {
        public static int CalculateDistance(int startRow, int startColumn, int finishRow, int finishColumn)
        {
            return Math.Abs(finishRow - startRow) + Math.Abs(finishColumn - startColumn);
        }
    }
}