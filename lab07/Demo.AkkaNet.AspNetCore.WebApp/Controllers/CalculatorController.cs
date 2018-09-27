using System;
using System.Threading.Tasks;
using Akka.Actor;
using Demo.AkkaNet.AspNetCore.WebApp.ActorInstances;
using Demo.AkkaNet.AspNetCore.WebApp.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Demo.AkkaNet.AspNetCore.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private ActorSystem _actorSystem;

        private ICalculatorActorInstance _calculatorActor;
//        public CalculatorController(ActorSystem actorSystem)
//        {
//            _actorSystem = actorSystem;
//        }
        
        public CalculatorController(ICalculatorActorInstance calculatorActor)
        {
            _calculatorActor = calculatorActor;
        }

        [HttpGet("sum")]
        public async Task<double> Sum(double x, double y)
        {   
            IActorRef calculatorRef;
            // version 1:
//            var calculatorActorProps = Props.Create<CalculatorActor>();
//            var calculatorRef = _actorSystem.ActorOf(calculatorActorProps);
            
            // version 2:
//            try
//            {
//                calculatorRef = await _actorSystem.ActorSelection("/user/calculator")
//                    .ResolveOne(TimeSpan.FromMilliseconds(100));
//            }
//            catch (ActorNotFoundException exc)
//            {
//                var calculatorActorProps = Props.Create<CalculatorActor>();
//                calculatorRef = _actorSystem.ActorOf(calculatorActorProps, "calculator");
//            }

            var msg = new AddMessage(x, y);
            // version 3:
//            var answer = await calculatorRef.Ask<AnswerMessage>(msg);
            var answer = await _calculatorActor.Sum(msg);
            
            return answer.Value;
        }
    }
}