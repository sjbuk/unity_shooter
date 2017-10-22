using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float speed = 5;
    public float tiltSpeed = 30;
    public float maxTilt = 30;
    public GameObject[] thrustersForward;
    public GameObject[] thrustersReverse;
    public float bulletDelay = 0.2f;
    public GameObject[] guns;
    public GameObject bullet;
    public float bulletVelocity = 300;
    public float points;

    enum Thrusters{ Forward, Reverse};
    
	private float tilt;
	private ParticleSystem ps;
    private bool isShooting;


	// Use this for initialization
	void Start () {
		SetThrusters(thrustersReverse, false);
		SetThrusters(thrustersForward, true);
        isShooting = false;
        points = 0;
	}
	
	// Update is called once per frame
	void Update () {
        DoMovement();

        if (Input.GetKey("space") && !isShooting)
        {
            isShooting = true;
            StartCoroutine("Shoot");
        }

        if (!Input.GetKey("space") && isShooting) {
            isShooting = false;
            StopCoroutine("Shoot");
        }
    }


    IEnumerator Shoot() {
        GameObject shotBullet;
        while (isShooting)
        {
            foreach (GameObject gun in guns)
            {
                shotBullet = Instantiate(bullet, gun.transform.position, bullet.transform.rotation);
                shotBullet.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletVelocity;
                Destroy(shotBullet, 0.5f);
            }
            yield return new WaitForSeconds(bulletDelay);
        }
    }

    void DoMovement()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            tilt = x * maxTilt * -1;
            transform.eulerAngles = new Vector3(0, 0, tilt);
            transform.Translate(x * Time.deltaTime * speed, 0, z * Time.deltaTime * speed, Space.World);

            //Clamp to viewport
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, 0.07f, 0.93f);
            pos.y = Mathf.Clamp(pos.y, 0.06f, 0.94f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

            if (z < 0.0)
            {
                SetThrusters(thrustersReverse, true);
                SetThrusters(thrustersForward, false);
            }
            else
            {
                SetThrusters(thrustersReverse, false);
                SetThrusters(thrustersForward, true);

            }
        }

    
    void SetThrusters (GameObject[] thrusters, bool start)
	{

		foreach (GameObject go in thrusters) {
			if (start && !go.GetComponent<ParticleSystem> ().isPlaying) {
				go.GetComponent<ParticleSystem> ().Play (true);
			} else if (!start && go.GetComponent<ParticleSystem> ().isPlaying) {
				go.GetComponent<ParticleSystem> ().Stop (true);
			}
		}
	}
}
