using Spanish;
using UnityEngine;

namespace CameraControll
{
    public class MirarElMouse : SoltieroComportamiento
    {
        [SerializeField] private float _sensibilidadX; // Adjust mouse sensitivity
        [SerializeField] private float _sensibilidadY;
        [SerializeField] private Transform _jugadorCuerpo; // Reference to the player's body for horizontal rotation
        [SerializeField] private float _angoloMaximos; //Max rotation for up and down look
        private float _rotacionX = 0f;

        protected override void Empieza()
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the screen
        }

        protected override void Ajornamiendo()
        {
            MiraElMouse();
        }

        private void MiraElMouse()
        {
            var mouseX = Input.GetAxis("Mouse X") * _sensibilidadX * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * _sensibilidadY * Time.deltaTime;

            _rotacionX -= mouseY;
            _rotacionX =
                Mathf.Clamp(_rotacionX, -_angoloMaximos, _angoloMaximos); // Clamp rotation to prevent over-rotation
            transform.localRotation = Quaternion.Euler(_rotacionX, 0f, 0f);

            _jugadorCuerpo.Rotate(Vector3.up * mouseX);
        }
    }
}