using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class MainCamera : MonoBehaviour
    {
        [Range(0.1f, 10f)]
        public float smoothFactor = 0.5f;
        private Transform m_targetTransform;
        private void Start()
        {
            m_targetTransform = transform;
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, m_targetTransform.position) > .1f)
            {
                Vector3 smoothPosition = Vector3.Lerp(transform.position, m_targetTransform.position, smoothFactor * Time.fixedDeltaTime);
                transform.position = smoothPosition;
            }
            if (Quaternion.Angle(transform.rotation, m_targetTransform.rotation) > .1f)
            {
                Quaternion smoothRotation = Quaternion.Lerp(transform.rotation, m_targetTransform.rotation, smoothFactor * Time.fixedDeltaTime);
                transform.rotation = smoothRotation;
            }
        }

        public void StriveForTransform(Transform point)
        {
            m_targetTransform = point;
        }

/*        IEnumerator Fly(Transform point)
        {
            while(transform.x)
        }*/
    }

}