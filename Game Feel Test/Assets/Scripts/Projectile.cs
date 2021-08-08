using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    public TraumaInducer TI;
    [SerializeField]ParticleSystem _Projectile_Particle;
    [SerializeField] Transform original_position; //position where the projectile will be tweened

    Vector3 origin_position; //position outside the csmera frame 

    public float speed = 10;
    Rigidbody _RB;
    public float waitTime = 2f;
    float OG_waittime;

    bool Missile_sound_play = false;
    [SerializeField] AudioSource Missile_Launch;

    private void OnEnable()
    {
        Actions.OnProjectileReset += Reset_Projectile;
    }
    
    private void Awake()
    {
        OG_waittime = waitTime;
        origin_position = transform.position;
        _RB = GetComponent<Rigidbody>();

        transform.DOMoveZ(original_position.position.z, 1f);
        _Projectile_Particle.gameObject.transform.DOMoveZ(original_position.position.z, 1f);
        //_Projectile_Particle = GetComponentInChildren<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            if(Missile_sound_play == false)
            {
                Missile_Launch.Play();
                Missile_sound_play = true;
            }
            
            _Projectile_Particle.gameObject.SetActive(true);
            _RB.velocity = new Vector3(0, 0, -speed);

            StartCoroutine(TI.ShockWave());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _RB.velocity = Vector3.zero;
        _RB.angularVelocity = Vector3.zero;
        transform.position = origin_position;
        waitTime = OG_waittime;

        Actions.OnProjectileEffected();

        Missile_sound_play = false;
        _Projectile_Particle.gameObject.SetActive(false);
        gameObject.SetActive(false);
        //Debug.Log("yea");
        //Destroy(gameObject);
    }

    void Reset_Projectile()
    {
        gameObject.SetActive(true);

        transform.DOMoveZ(original_position.position.z, 1f);
        _Projectile_Particle.gameObject.transform.DOMoveZ(original_position.position.z, 1f);
    }
}
