using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Rubika {
    [CreateAssetMenu(menuName = "Rubika/InputReader", fileName = "InputReader")]
    public class InputReader : ScriptableObject, IA_PlayerInputActions.IPlayerActions {
        IA_PlayerInputActions _playerInputActions;

        public Vector2 Move => _playerInputActions.Player.Move.ReadValue<Vector2>();
        public bool Fire => _playerInputActions.Player.Fire.ReadValue<float>() > 0f;
        
        public event UnityAction OnCycleWeaponEvent;
        
        public void OnEnable() {
            if (_playerInputActions == null) {
                _playerInputActions = new IA_PlayerInputActions();
                _playerInputActions.Player.SetCallbacks(this);
            }
        }

        public void Enable() => _playerInputActions.Enable();

        public void OnMove(InputAction.CallbackContext ctx) { }

        public void OnFire(InputAction.CallbackContext ctx) { }

        public void OnCycleWeapon(InputAction.CallbackContext ctx) {
            if (!ctx.performed) return;
            OnCycleWeaponEvent?.Invoke();
        }
    }
}
