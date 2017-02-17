using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour 
{
	public Transform target;
	public float speed = 20;
    public int m_Health = 5;
    bool isKnockback = false;
    bool isMolesting = false;

	Vector2[] path;
	int targetIndex;

	void Start() 
    {
		StartCoroutine (RefreshPath ());
	}

	IEnumerator RefreshPath() 
    {
		Vector2 targetPositionOld = (Vector2)target.position + Vector2.up; // ensure != to target.position initially
			
		while (true) {
			if (targetPositionOld != (Vector2)target.position) {
				targetPositionOld = (Vector2)target.position;

				path = Pathfinding.RequestPath (transform.position, target.position);
				StopCoroutine ("FollowPath");
				StartCoroutine ("FollowPath");
			}

			yield return new WaitForSeconds (.25f);
		}
	}

		
	IEnumerator FollowPath() {
		if (path.Length > 0) {
			targetIndex = 0;
			Vector2 currentWaypoint = path [0];

			while (true) 
            {
				if ((Vector2)transform.position == currentWaypoint) 
                {
					targetIndex++;
					if (targetIndex >= path.Length)
                    {
						yield break;
					}
					currentWaypoint = path [targetIndex];
				}
                if(!isMolesting)
				transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);
				yield return null;

			}
		}
	}

	public void OnDrawGizmos() 
    {
		if (path != null) 
        {
			for (int i = targetIndex; i < path.Length; i ++) 
            {
				Gizmos.color = Color.black;
				//Gizmos.DrawCube((Vector3)path[i], Vector3.one *.5f);

				if (i == targetIndex)
                {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else
                {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}

    public void TakeDamage()
    {

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            isMolesting = true;
        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isMolesting = false;
        }
    }

}
