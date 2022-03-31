using UnityEngine;

namespace Cave.Main.Shared
{
    public class CameraOffset : MonoBehaviour
    {
        [SerializeField] private GameObject targetObject;
        void Start()
        {
            targetObject = GameObject.FindWithTag("Player");
        }
        public void UpateCameraOffset()
        {
            var offset = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, transform.position.z);
            transform.position = offset;
        }
    }

}