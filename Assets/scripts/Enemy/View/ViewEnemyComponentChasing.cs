using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class ViewEnemyComponentChasing : MonoBehaviour
    {
        Rigidbody rb;
        public ViewEnemy mainview;
        // Start is called before the first frame update
        Vector3 lastSeen;

        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        private void Update()
        {
            //Debug.Log(Mathf.Abs((gameObject.transform.position - lastSeen).magnitude));

            if (Mathf.Abs((gameObject.transform.position - lastSeen).magnitude) > 6)
            {
                gameObject.transform.LookAt(lastSeen);
                rb.velocity = transform.forward * 10;
            }
            else
            {
                mainview.StateChange(EnemyState.Petrolling);
            }
        }
        public void SetFollowPosition(Vector3 position)
        {
            lastSeen = position;
        }
        private void OnEnable()
        {

        }

        IEnumerator ChangeToPetrolling(Vector3 curr)
        {
            yield return new WaitForSeconds(10);
            mainview.StateChange(EnemyState.Petrolling);
        }
    }
}