using Akka.Configuration;

namespace Demo.AkkaNet.Gambling.Core

{
    public static class HoconLoader
    {
        public static Config FromFile(string path)
        {
            var hoconContent = System.IO.File.ReadAllText(path);
            return ConfigurationFactory.ParseString(hoconContent);
        }
    }
}