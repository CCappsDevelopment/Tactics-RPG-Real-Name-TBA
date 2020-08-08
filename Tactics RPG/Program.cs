using System;

// Application entry point to TacticsRPG
namespace Tactics_RPG
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new TacticsRPG())
                game.Run();
        }
    }
#endif
}
