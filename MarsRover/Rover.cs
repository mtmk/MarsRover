using System;

namespace MarsRover
{
    public class Rover
    {
        private int _x;
        private int _y;
        private int _r;
        private int _maxX;
        private int _maxY;

        public Rover Init(int maxX, int maxY,int x, int y, Direction d)
        {
            _maxX = maxX;
            _maxY = maxY;
            _x = x;
            _y = y;
            _r = (int)d;

            return this;
        }

        public Rover Right()
        {
            if (_r == 270)
                _r = 0;
            else
                _r += 90;

            return this;
        }

        public Rover Left()
        {
            if (_r == 0)
                _r = 270;
            else
                _r -= 90;

            return this;
        }

        public Rover Move()
        {
            switch (_r)
            {
                case 0:
                    _y++;
                    if (_y > _maxY) _y = _maxY;
                    break;
                case 90:
                    _x++;
                    if (_x > _maxX) _x = _maxX;
                    break;
                case 180:
                    _y--;
                    if (_y < 0) _y = 0;
                    break;
                case 270:
                    _x--;
                    if (_x < 0) _x = 0;
                    break;
                default:
                    throw new Exception("Unexpected position");
            }

            return this;
        }

        public Position Position => new Position(_x, _y, (Direction)_r);

        public Rover Exec(string cmd)
        {
            foreach (var c in cmd)
            {
                switch (c)
                {
                    case 'L':
                        Left();
                        break;
                    case 'R':
                        Right();
                        break;
                    case 'M':
                        Move();
                        break;
                }
            }
            return this;
        }
    }
}