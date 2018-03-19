/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EZhex1991
{
    public class HanoiTower : MonoBehaviour
    {
        public List<Transform> tower;
        public float interval = 0.5f;

        public Transform t1;
        public Transform t2;
        public Transform t3;

        void Start()
        {
            for (int i = 0; i < tower.Count; i++)
            {
                tower[i].position = -Vector3.up * i;
                tower[i].localScale = Vector3.one + Vector3.right * i;
            }
            StartCoroutine(Move(tower, t1.position, t2.position, t3.position));
        }

        IEnumerator Move(List<Transform> tower, Vector3 current, Vector3 idle, Vector3 dest)
        {
            if (tower.Count == 1)
            {
                yield return new WaitForSeconds(interval);
                SetX(tower[0], dest.x);
            }
            else
            {
                List<Transform> newTower = new List<Transform>();
                for (int i = 0; i < tower.Count - 1; i++)
                {
                    newTower.Add(tower[i]);
                }
                yield return Move(newTower, current, dest, idle);
                yield return new WaitForSeconds(interval);
                SetX(tower[tower.Count - 1], dest.x);
                yield return Move(newTower, idle, current, dest);
            }
        }

        void SetX(Transform tf, float x)
        {
            Vector3 position = tf.position;
            position.x = x;
            tf.position = position;
        }
    }
}