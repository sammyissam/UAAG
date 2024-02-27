using UnityEngine;

namespace Utility.GameFlow
{
    public class CursorLockModeRelay : MonoBehaviour
    {

        /// <summary>
        /// Locks the cursor to the screen
        /// </summary>
        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        /// <summary>
        /// Unlocks the cursor
        /// </summary>
        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}