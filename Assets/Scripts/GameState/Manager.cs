using System;

namespace GameState
{
    public class Manager
    {
        private static readonly Lazy<Manager> Instance = new(() => new Manager());
        public bool GameOver = false;
        public bool StartGame = false;

        private Manager()
        {
        }

        public static Manager GetInstance => Instance.Value;
    }
}