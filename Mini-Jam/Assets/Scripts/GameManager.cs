using UnityEngine;

namespace MiniJam
{
    [DefaultExecutionOrder(-1)]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else Destroy(gameObject);
            
            InputSystem.Init();
        }
    }
}
