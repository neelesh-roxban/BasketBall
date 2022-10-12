using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Rigidbody ballRigidbody;
    public GameManager gameManager;
	public Transform target;

	public float h = 25;
	public float gravity = 0;
    private bool isLaunched = false;


	void Start() {
		ballRigidbody.useGravity = false;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Launch ();
		}

		
	}

	void Launch() {
        if(isLaunched == false )
        {
          Physics.gravity = Vector3.up * gravity;
		  ballRigidbody.useGravity = true;
		  ballRigidbody.velocity = CalculateLaunchData ().initialVelocity;
          isLaunched = true;
          gameManager.SpawnBall();
        }
		
	}

	LaunchData CalculateLaunchData() {
		float displacementY = target.position.y - ballRigidbody.position.y;
		Vector3 displacementXZ = new Vector3 (target.position.x - ballRigidbody.position.x, 0, target.position.z - ballRigidbody.position.z);
		float time = Mathf.Sqrt(-2*h/gravity) + Mathf.Sqrt(2*(displacementY - h)/gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt (-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	

	struct LaunchData {
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData (Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}
		
	}

    public void DestroyBall()
    {
       Destroy(gameObject,3);
       Debug.Log("destroy");
    }
}