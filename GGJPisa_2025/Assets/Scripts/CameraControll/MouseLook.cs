using UnityEngine;

namespace CameraControll
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivityX; // Adjust mouse sensitivity
        [SerializeField] private float _mouseSensitivityY;
        [SerializeField] private Transform _playerBody; // Reference to the player's body for horizontal rotation
        [SerializeField] private float _maxAngle; //Max rotation for up and down look
        private float _xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the screen
        }

        private void Update()
        {
            LookAtMouse();
        }

        private void LookAtMouse()
        {
            var mouseX = Input.GetAxis("Mouse X") * _mouseSensitivityX * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivityY * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -_maxAngle, _maxAngle); // Clamp rotation to prevent over-rotation
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}