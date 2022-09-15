using UnityEngine;

namespace PathCreation.Examples
{
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        [SerializeField] private float leftBorder;
        [SerializeField] private float rightBorder;

        [SerializeField, Range(0.1f, 3f)] private float normCoef = 1.0f;

        private float borderDistance = 0f;
        private float offset = 0f;

        private void Awake()
        {
            SwipeDetection.onSwipe += OnSwipe;
        }

        void Start()
        {
            borderDistance = Mathf.Abs(rightBorder - leftBorder);
         
            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                Vector3 follower = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.position = new Vector3(transform.position.x, follower.y, follower.z);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        void OnSwipe(Vector2 delta)
        {
            if (pathCreator != null)
            {
                offset = borderDistance * normCoef * delta.x / Screen.width;

                transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);

                if (transform.position.x > rightBorder)
                {
                    transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < leftBorder)
                {
                    transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
                }
            }
        }
    }
}