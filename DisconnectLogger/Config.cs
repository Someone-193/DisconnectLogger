using System.ComponentModel;

namespace DisconnectLogger
{
    public class Config
    {
        [Description("Indicates if DisconnectLogger should still log disconnects, even if Exiled is installed (which adds disconnect logs by default)")]
        public bool WorkIfExiledInstalled { get; set; } = false;
    }
}