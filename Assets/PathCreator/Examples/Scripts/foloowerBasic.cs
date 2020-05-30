using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
namespace PathCreation.Examples
{
    public class foloowerBasic : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                Vector3 nextPoint = pathCreator.path.GetClosestPointOnPath(transform.position);

                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);


            }

        }



    }
}