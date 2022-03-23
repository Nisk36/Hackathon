using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnemyScript : MonoBehaviour
{
    public int enemyHp = 1;
    private GameObject player;

    public float shotSpan = 3f;
    private float currentTime = 0f;

    [SerializeField] private GameObject enemyBullet;

    [SerializeField]
    private Renderer _renderer;

    private Sequence _seq;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            enemyHp -= 1;
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }*/

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > shotSpan)
        {
            
            currentTime = 0f;
            Shot();
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            enemyHp -= 1;

            if (enemyHp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                HitBlink();
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Blow");

        }


    }
    //https://sunagitsune.com/unitycollisionvector2d/
    IEnumerator Blow()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(0.03f);
            player.transform.Translate(
                (player.transform.position - this.transform.position).normalized.x / 2,
                (player.transform.position - this.transform.position).normalized.y,
                0
            );

            i++;
        }
    }


    private void HitBlink()
    {
        _seq?.Kill();
        _seq = DOTween.Sequence();
        _seq.AppendCallback(() => _renderer.enabled = false);
        _seq.AppendInterval(0.05f);
        _seq.AppendCallback(() => _renderer.enabled = true);
        _seq.AppendInterval(0.05f);
        _seq.SetLoops(2);
        _seq.Play();
    }

    public void Shot()
    {

        var pos = this.gameObject.transform.position;

        var t = Instantiate(enemyBullet) as GameObject;
        t.transform.position = pos;
        Vector3 vec = Vector3.Scale((player.transform.position - pos), new Vector3(1, 1, 0)).normalized;
        t.GetComponent<Rigidbody>().velocity = vec * 10.0f; 
    }



}