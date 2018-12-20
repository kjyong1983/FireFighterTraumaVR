using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jongs.TestCode
{
    public class FireProcess02 : MonoBehaviour
    {
        //하위 계층(자식오브젝트)에 보유한 모든 파티클
        private ParticleSystem[] MyChildFireParticle;
        //각 파티클의 최대 파워(EmmisionRate)
        private float[] MyChildFirePower;
        //각 파티클의 현재 파워
        public float[] MyChilFireCurrentPower;
        //불이 다시 일어나기까지 대기시간
        public float RisingCoolTime;

        //파티클 충돌 갯수로 불끄기 제어
        public int ParticleCollisionCount;

        //시간으로 불끄기 제어
        //waterTime을 달성했을 때 불끄기 호출
        public float waterTime;
        //waterOut이 0이됬을때 WaterCollision충돌이 되지 않고있는것으로 체크
        public float waterOut;
        //물이 충돌되고있는지 확인하는 bool
        public bool WaterCollision;

        //초기화
        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            //불씨가 되살아날 시간이 되었다면
            if (RisingCoolTime <= 0)
            {
                for (int i = 0; i < MyChildFireParticle.Length - 1; i++)
                {
                    //현재 불의 파워가 0보다 크고, 최대치보다 작을때 
                    if (MyChilFireCurrentPower[i] > 0 && MyChilFireCurrentPower[i] < MyChildFirePower[i])
                    {
                        //5초에 걸쳐서 최대파워 복구 30프레임 고정일때 프레임당 (200 / 5 * 1 / 30)
                        MyChilFireCurrentPower[i] += MyChildFirePower[i] / 5 * Time.deltaTime;

                        MyChildFireParticle[i].emissionRate = MyChilFireCurrentPower[i];
                    }
                }
            }
            else
            {
                //fps 30고정일때 델타타임은 1/30 
                RisingCoolTime -= Time.deltaTime;
            }

            if (waterOut <= 0)
            {
                WaterCollision = false;
            }
            else
            {
                waterOut -= Time.deltaTime;
            }

            if (WaterCollision)
            {
                waterTime += Time.deltaTime;
                if (waterTime > 3f)
                {
                    TurnOffFire();
                    waterTime = 0;
                }
            }
        }
        //변수 초기화
        public void Init()
        {
            //자식 오브젝트의 갯수확인.
            int child = this.transform.childCount;
            if (child != 0)
            {
                //자식 오브젝트의 개수만큼 배열 할당
                MyChildFirePower = new float[child];
                MyChilFireCurrentPower = new float[child];
                MyChildFireParticle = new ParticleSystem[child];

                //할당된 배열에 값 입력
                for (int i = 0; i < MyChildFireParticle.Length - 1; i++)
                {
                    MyChildFireParticle[i] = this.transform.GetChild(i).GetComponent<ParticleSystem>();
                    MyChildFirePower[i] = MyChildFireParticle[i].emissionRate;
                    MyChilFireCurrentPower[i] = MyChildFirePower[i];
                }
            }
        }

        //불 끄기 호출
        public void TurnOffFire()
        {
            
            //불씨가 다시 살아나기까지의 시간(쿨타임) 초기화.
            RisingCoolTime = 3f;

            //모든 파티클을 1번 호출당 1%의 emissionRate감소.
            for (int i = 0; i < MyChildFireParticle.Length - 1 ; i++)
            {
                MyChilFireCurrentPower[i] -= MyChildFirePower[i] / 100;

                

                //파티클의 현재 파워가 0.1보다 낮은경우 0.1을 유지(다시 살아나는 효과를 주기위한 것)
                if (MyChilFireCurrentPower[i] <= 0.1f)
                {
                    //불이 다시 살아나지 않고, 파괴하겠다면 Detroy주석 제거
                    Destroy(this.gameObject);
                    MyChilFireCurrentPower[i] = 0.1f;
                }

                //파티클에 적용
                MyChildFireParticle[i].emissionRate = MyChilFireCurrentPower[i];
            }
        }

        //파티클과 이 스크립트가 적용된 오브젝트의 Collider가 충돌을 일으켰을 때 자동 호출
        void OnParticleCollision(GameObject other)
        {
            //other은 충돌된 대상(파티클)의 GameObject
            //충돌한 대상의 이름이 Water 일때 TurnOffFire()함수 호출
            if (other.name.CompareTo("Water") == 0)
            {
                TurnOffFire();
                /*
                WaterCollision = true;
                waterOut = 2; */


                /*
                //충돌 카운트로 불끄기 체크
                ParticleCollisionCount++;
                if (ParticleCollisionCount > 30)
                {
                    Debug.Log("불끄기 호출");
                    TurnOffFire();
                    ParticleCollisionCount = 0;
                }*/
            }
        }
    }
}
