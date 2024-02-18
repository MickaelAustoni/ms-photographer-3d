using UnityEngine;
using UnityEngine.Serialization;

namespace Volumetric_Galaxy.scripts
{
    public class MouseLook : MonoBehaviour
    {
        private Vector2 _rotation = Vector2.zero;
        [FormerlySerializedAs("RotationSpeed")] public float rotationSpeed = 5.0f;
        [FormerlySerializedAs("ScrollSpeed")] public float scrollSpeed = 5000.0f;
        public float smoothTime = 5f;

        private Vector3 _velocity = Vector3.zero;
        private Vector2 _rotationVelocity = Vector2.zero;

        private void Update()
        {
            var transform1 = transform;
            var scroll = Input.GetAxis("Mouse ScrollWheel");      // Scroll wheel
            var targetRotationX = _rotation.x;
            var targetRotationY = _rotation.y;

            // Handle mouse inputs for movement with smoothing
            var position = transform1.position;
            var targetPosition = position + transform1.forward * (scroll * scrollSpeed);
            transform.position = Vector3.SmoothDamp(position, targetPosition, ref _velocity, smoothTime);


            if (Input.GetKey(KeyCode.UpArrow)) {
                targetRotationX -= rotationSpeed;
            }

            if (Input.GetKey(KeyCode.DownArrow)) {
                targetRotationX += rotationSpeed;
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                targetRotationY -= rotationSpeed;
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                targetRotationY += rotationSpeed;
            }

            // Smoothly rotate the camera based on input
            _rotation.x = Mathf.SmoothDamp(_rotation.x, targetRotationX, ref _rotationVelocity.x, smoothTime);
            _rotation.y = Mathf.SmoothDamp(_rotation.y, targetRotationY, ref _rotationVelocity.y, smoothTime);
            transform.eulerAngles = (Vector2)_rotation * rotationSpeed;
        }
    }
}
