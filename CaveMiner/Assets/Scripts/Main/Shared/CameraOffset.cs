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
        private void Update()
        {
            var offset = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, transform.position.z);
            transform.position = offset;
        }
    }

}