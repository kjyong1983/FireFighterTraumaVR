using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTest : MonoBehaviour
{
    private Transform MyTr;
    public float power;
    private ParticleSystem explosion;
    private ParticleSystem[] fires;
    public Rigidbody[] expObjs;

    private void Start()
    {
        MyTr = this.transform;
        explosion = MyTr.GetChild(6).GetComponent<ParticleSystem>();
        fires = new ParticleSystem[6];
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i] = MyTr.GetChild(i).GetComponent<ParticleSystem>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        //폭발 효과 파티클 생성
        explosion.Play();

        //지정된 물체에 폭발력 부여
        for (int i = 0; i < expObjs.Length; i++)
        {
            if (expObjs[i].isKinematic)
                expObjs[i].isKinematic = false;
            MyTr.LookAt(expObjs[i].transform);
            Vector3 vect = MyTr.forward;
            expObjs[i].AddForce(power * vect);
        }

        //폭발 직후 화제 시작
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].Play();
        }

        //5초 후 드럼통 제거
        //Destroy(gameObject, 5.0f);
    }
}