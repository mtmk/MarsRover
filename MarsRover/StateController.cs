using System.Web.Http;

namespace MarsRover
{
    public class StateController : ApiController
    {
        // TODO implement Dependency Injection with proper lifecycle
        private static readonly Rover RoverInstance = new Rover().Init(20, 20, 0, 0, Direction.N);
        public StateController()
        {
            _rover = RoverInstance;
        }

        private readonly Rover _rover;

        public StateController(Rover rover)
        {
            _rover = rover;
        }

        [Route("api/state")]
        [HttpGet]
        public PositionJson Get()
        {
            return _rover.Position.ToJson();
        }

        [Route("api/state")]
        [HttpGet]
        public string Get(int x, int y, int r, string message)
        {
            return new Rover().Init(5,5,x,y,(Direction)r).Exec(message).Position.ToString();
        }

        [Route("api/state")]
        [HttpPost]
        public PositionJson Post(CommandJson command)
        {
            return _rover.Exec(command.Message).Position.ToJson();
        }
    }
}