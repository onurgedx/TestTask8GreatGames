using Common.CellSys;
using PassengerPickup.Algorithms.PathFinder;
using System.Collections;
using UnityEngine;

namespace PassengerPickup.Gameplay.MovementSys
{
    /// <summary>
    /// Movement System of the tile system
    /// </summary>
    public class MovementSystem : MonoBehaviour
    {
        /// <summary>
        /// Moves given transform according to Path
        /// </summary>
        /// <param name="a_path"></param>
        /// <param name="a_transform"></param>
        public void Move(IPath a_path, Transform a_transform, float a_speed)
        {
            StartCoroutine(move());
            IEnumerator move()
            {
                while (!a_path.IsPathCompleted())
                {
                    CellPosition destinationCellPosition = a_path.NextCellPosition();
                    Vector3 destinationPos = destinationCellPosition.CellPositionToWorldPosition();
                    Vector3 startPos = a_transform.position;
                    float distance = (destinationPos - startPos).magnitude;
                    float speed = a_speed / distance;

                    float timeCounter = 0;
                    while (timeCounter < 1)
                    {
                        timeCounter += Time.deltaTime * speed;
                        a_transform.position = Vector3.Lerp(startPos, destinationPos, timeCounter);
                        yield return null;
                    }
                }
            }
        }
    }

}