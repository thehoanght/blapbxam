using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public int blood;

    [SerializeField]
    public AudioClip deadSoundClip;
    private AudioSource deathSound;
    private bool die;
    private void Awake()
    {
        deathSound = GetComponent < AudioSource >();
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Boudary" && collision.tag != "Orcs" )
        {
            blood--;
            Destroy(collision.gameObject);
            if (blood <= 0)
            {
                deathSound.Play(); yield return new WaitForSeconds(0.3f);
                Destroy(transform.gameObject);
            }
        }
    }
}
