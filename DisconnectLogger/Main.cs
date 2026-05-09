using System;
using System.Linq;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;
using LabApi.Loader.Features.Plugins.Enums;
using MEC;

namespace DisconnectLogger
{
    public class Main : Plugin<Config>
    {
        public override string Name => "Disconnect Logger";

        public override string Description => "Logs your disconnects because LabAPI forgot to!";

        public override string Author => "@Someone";

        public override Version Version { get; } = new(1, 0, 0);

        public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);

        public override LoadPriority Priority => LoadPriority.Highest;

        public override void Enable()
        {
            Timing.CallDelayed(0.1F, () =>
            {
                if (Config.WorkIfExiledInstalled || !AppDomain.CurrentDomain.GetAssemblies().Any(asm => asm.GetName().Name.Contains("Exiled.Events")))
                {
                    PlayerEvents.Left += Print;
                }
            });
        }

        public override void Disable() => PlayerEvents.Left -= Print;

        private static void Print(PlayerLeftEventArgs ev) => Logger.Raw($"Player {ev.Player.Nickname} disconnected", ConsoleColor.Gray);
    }
}