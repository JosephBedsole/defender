using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public ParticleSystem hitParticlesPrefab;
    public ParticleSystem paddleParticles;
    public ParticleSystem deathParticles;
    public ParticleSystem scoreParticles;
    public float speed = 8;
    List<ParticleSystem> particlePool = new List<ParticleSystem>();
    public AudioSource sound;
    public AudioClip brickSound;
    public AudioClip paddleSound;
    public AudioClip wallSound;
    public AudioClip deathSound;
    public Animation shakeLives;
    

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        PreLaunch();
    }

    void PreLaunch()
    {
        body.velocity = Vector3.zero;
        transform.SetParent(PaddleController.instance.transform);
        transform.localPosition = Vector3.up;
    }

    void Launch()
    {
        transform.SetParent(null);
        body.velocity = Vector3.up * speed;
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            Vector3 v = body.velocity;
            if (Mathf.Abs(v.x) > 2 * Mathf.Abs(v.y))
            {
                v.x *= 0.9f;
            }
            v = v.normalized * speed;
            body.velocity = v;

            transform.up = v;
            transform.localScale = new Vector3(0.9f, 1.1f, 1);

            DeathCheck();
        }
        else
        {
            transform.localScale = Vector3.one;
            if (Input.GetButton("Jump"))
            {
                Launch();
            }
        }
    }
    void DeathCheck()
    {
        Vector3 view = Camera.main.WorldToViewportPoint(transform.position);
        if (view.y < 0)
        {
            GameManager.LostBall();

            if (GameManager.instance.lives >= 0)
            {
                sound.clip = deathSound;
                sound.Play();

                PreLaunch();

                deathParticles.Stop();
                deathParticles.Play();

            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        if (GameManager.instance.brickCount == 0)
        {
            gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision c) {
        
        ContactPoint cp = c.contacts[0];
        transform.up = cp.normal;
        transform.localScale = new Vector3(1.5f, 0.5f, 1);

        ShakeController shake = Camera.main.gameObject.GetComponent<ShakeController>();
        shake.Shake();

        

        if (c.gameObject.tag == "Player")
        {
            paddleParticles.Stop();
            paddleParticles.transform.position = transform.position;
            paddleParticles.Play();

            sound.clip = paddleSound;
            sound.Play();
        }
        else if (c.gameObject.tag == "Bricks")
        {
            scoreParticles.Stop();
            scoreParticles.Play();

            ParticleSystem hitParticles = null;
            for (int i = 0; i < particlePool.Count; i++)
            {
                ParticleSystem p = particlePool[i];
                if (p.isStopped)
                {
                    hitParticles = p;
                    Debug.Log("reusing from my pool");
                    break;
                }
            }

            if (hitParticles == null)
            {
                hitParticles = Instantiate(hitParticlesPrefab) as ParticleSystem;
                particlePool.Add(hitParticles);
            }

            hitParticles.transform.up = body.velocity;
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
            sound.clip = brickSound;
            sound.Play();
        }
        else if (c.gameObject.tag == "Bricks 2") {
            scoreParticles.Stop();
            scoreParticles.Play();

            ParticleSystem hitParticles = null;
            for (int i = 0; i < particlePool.Count; i++)
            {
                ParticleSystem p = particlePool[i];
                if (p.isStopped)
                {
                    hitParticles = p;
                    Debug.Log("reusing from my pool");
                    break;
                }
            }

            if (hitParticles == null)
            {
                hitParticles = Instantiate(hitParticlesPrefab) as ParticleSystem;
                particlePool.Add(hitParticles);
            }

            hitParticles.transform.up = body.velocity;
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
            sound.clip = brickSound;
            sound.Play();
        }
        else {

            sound.clip = wallSound;
            sound.Play();

        }
    }
}
