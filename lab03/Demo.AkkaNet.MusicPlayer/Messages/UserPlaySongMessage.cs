namespace Demo.AkkaNet.MusicPlayer.Messages
{
    public class UserPlaySongMessage
    {
        
        public UserPlaySongMessage(string song,string user)
        {
            Song = song;
            User = user;
        }

        public string Song { get; }
        public string User { get; }
    }
}