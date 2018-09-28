namespace Demo.AkkaNet.MusicPlayer.Messages
{
    public class PlaySongMessage
    {
        public PlaySongMessage(string song)
        {
            Song = song;
        }

        public string Song { get; }
    }
}