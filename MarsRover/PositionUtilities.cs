namespace MarsRover
{
    public static class PositionUtilities
    {
        public static PositionJson ToJson(this Position position)
        {
            return new PositionJson
            {
                X = position.X,
                Y = position.Y,
                R = (int)position.Direction
            };
        }
    }
}