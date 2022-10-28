using UnityEngine;

namespace MiniJam
{
    public static class InputSystem
    {
        public static InputActions.PlayerActions Player { get; private set; }

        public static InputActions.UIActions UI { get; private set; }

        private static InputActions s_Instance;

        public static void Init()
        {
            s_Instance = new InputActions();
            Player = s_Instance.Player;
            UI = s_Instance.UI;

            UI.Enable();
        }

        public static void Shutdown()
        {
            s_Instance.Disable();
        }
    }
}
