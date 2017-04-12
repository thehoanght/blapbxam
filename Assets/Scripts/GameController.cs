using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Transform bulletPrefab;

    public Transform orcs1Prefab;
    public Transform orcsPrefab;
    public Transform bossOrcsPrefab;

    //audio
    public AudioClip bulletAudio;
    private AudioSource audioSource;
    public float timeDelayShoot;
    private float countTimeDelayShoot;

    public float xMin, xMax, yTop;
    public float timeWaitOrcs, timeWaitTurn;
    public int numOfOrcs;

    public int numOfTurn;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Waves());
    }

    IEnumerator Waves()
    {
        for (int num = 0; num < numOfTurn; num++)
        {
            for (int i = 0; i < numOfOrcs; i++)
            {
                float xRandom = Random.Range(xMin, xMax);
                //random quai vat
                Transform enemy;
                if (Random.Range(0, 20) % 2 == 0)
                {
                    enemy = orcsPrefab;
                }
                else
                {
                    enemy = orcs1Prefab;
                }
                //clone quai vat
                Instantiate(enemy, new Vector3(xRandom, yTop, 0), Quaternion.identity);
                yield return new WaitForSeconds(timeWaitOrcs);
            }
            yield return new WaitForSeconds(timeWaitTurn);
        }
        //boss
        Vector3 middPos = new Vector3(0, 5, 0);
        Instantiate(bossOrcsPrefab, middPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > countTimeDelayShoot)
        {
            Vector3 touchScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(bulletPrefab, touchScreen, Quaternion.identity);

            audioSource.PlayOneShot(bulletAudio);
            countTimeDelayShoot = Time.time + timeDelayShoot;
        }
    }
    private void FixedUpdate()
    {

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Debug.Log("Touch: " +  Input.touchCount);
        //    Vector3 touchScreen = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //    Instantiate(bulletPrefab, touchScreen, Quaternion.identity);
        //}
    }
}
