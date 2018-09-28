namespace Demo.AkkaNet.MusicPlayer.Messages
{
    public class UserStopPlayingMessage
    {
        public UserStopPlayingMessage(string user)
        {
            User = user;
        }
        
        public string User { get; }
    }
}