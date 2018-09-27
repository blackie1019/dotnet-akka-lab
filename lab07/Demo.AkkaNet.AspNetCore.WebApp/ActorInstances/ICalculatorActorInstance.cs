using System.Threading.Tasks;
using Demo.AkkaNet.AspNetCore.WebApp.Messages;

namespace Demo.AkkaNet.AspNetCore.WebApp.ActorInstances
{
    public interface ICalculatorActorInstance
    {
        Task<AnswerMessage> Sum(AddMessage message);
    }
}