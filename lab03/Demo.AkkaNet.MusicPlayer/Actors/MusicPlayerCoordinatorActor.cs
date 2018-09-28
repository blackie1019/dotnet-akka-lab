using System.Collections.Generic;
using Akka.Actor;
using Demo.AkkaNet.MusicPlayer.Messages;

namespace Demo.AkkaNet.MusicPlayer.Actors
{
    public class MusicPlayerCoordinatorActor: ReceiveActor
    {
        private Dictionary<string, IActorRef> userMusicPlayerActors;
        
        public MusicPlayerCoordinatorActor()
        {

            userMusicPlayerActors = new Dictionary<string, IActorRef>();
            
            Receive<UserPlaySongMessage>(msg => { PlaySongForUser(msg); });
            Receive<UserStopPlayingMessage>(msg => { StopSongForUser(msg);});
        }

        private void PlaySongForUser(UserPlaySongMessage msg)
        {
            IActorRef targetUserMusicPlayerActor = GetTargetUserMusicPlayerActor(msg.User);
            if (targetUserMusicPlayerActor == null)
            {
                targetUserMusicPlayerActor = Context.ActorOf<UserMusicPlayerActor>(msg.User);
                userMusicPlayerActors.Add(msg.User,targetUserMusicPlayerActor);
            }
            targetUserMusicPlayerActor.Tell(msg);
        }
        
        private void StopSongForUser(UserStopPlayingMessage msg)
        {
            IActorRef targetUserMusicPlayerActor = GetTargetUserMusicPlayerActor(msg.User);
            if (targetUserMusicPlayerActor != null)
            {
                targetUserMusicPlayerActor.Tell(msg);                          
            }
        }

        private IActorRef GetTargetUserMusicPlayerActor(string user)
        {
            userMusicPlayerActors.TryGetValue(user, out var targetUserMusicPlayerActor);
            return targetUserMusicPlayerActor;
        }
       
    }
}