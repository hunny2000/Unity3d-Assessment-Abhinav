using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffect : MonoBehaviour
{
    [SerializeField] GameObject Character_Ragdoll;
    [SerializeField] Transform Parent;

    Vector3 original_position;

    
    private void OnEnable()
    {
        Actions.OnCharacterReset += Reset_Characters;
    }
    

    private void Awake()
    {
        original_position = transform.position;
    }
    private void OnCollisionEnter(Collision collision)  
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Projectile")
        {
            //Debug.Log("ye");
            Instantiate(Character_Ragdoll, transform.position, transform.rotation);

            Actions.OnCharaterEffected();

            gameObject.transform.position = original_position;
            gameObject.SetActive(false);
        }
    }

    void Reset_Characters()
    {
        gameObject.SetActive(true);
    }
}
