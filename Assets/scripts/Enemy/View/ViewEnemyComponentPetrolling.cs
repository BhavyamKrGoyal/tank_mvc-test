using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class ViewEnemyComponentPetrolling : MonoBehaviour
    {
        // Start is called before the first frame update
        Vector3 pos1, pos2, current;
        Rigidbody rb;
        Coroutine delay;
        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
            //gameObject.transform.LookAt(current);
            delay= StartCoroutine(ChangePetrollingDirection(current));
        }
        // Update is called once per frame
        void Update()
        {
            if (!(pos1 == pos2))
            {
                rb.velocity = transform.forward * 4;
                if (Mathf.Abs((gameObject.transform.position - current).magnitude) < 1)
                {
                    if (current == pos1)
                    {
                        current = pos2;
                    }
                    else
                    {
                        current = pos1;
                    }
                    gameObject.transform.LookAt(current);
                    StopCoroutine(delay);
                    delay= StartCoroutine(ChangePetrollingDirection(current));
                    
                }
            }
        }

        IEnumerator ChangePetrollingDirection(Vector3 curr)
        {
            yield return new WaitForSeconds(10);
            if (curr == pos1)
            {
                current = pos2;
            }
            else
            {
                current = pos1;
            }
            gameObject.transform.LookAt(current);

            //Debug.Log(current);
            StartCoroutine(ChangePetrollingDirection(current));
        }
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {//Debug.Log("ground");
                pos1 = gameObject.transform.position;
                pos2 = pos1;
                if (Random.Range(0, 10) > 5)
                {
                    pos2.x += 20;
                }
                else
                {
                    pos2.x += 20;
                }
                current = pos2;

            }

        }
    }
}