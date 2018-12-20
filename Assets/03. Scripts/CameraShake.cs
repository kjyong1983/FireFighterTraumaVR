using UnityEngine;
using System.Collections;

// 카메라 흔들기
public class CameraShake : MonoBehaviour
{
    // 디버그 모드
    public bool _debugMode = false;

    // 흔들기 크기
    public float _shakeAmount;
    // 흔들기 시간
    public float _shakeDuration;

    // 보관용 흔들기 크기
    private float _originShakeAmount;
    // 보관용 흔들기 시간
    private float _originshakeDuration;

    float _shakePercentage; // 회전에 대한 흔들기 크기 (0-1)
    float _startAmount; // 초기 흔들기 크기 (백분율)
    float _startDuration; // 초기 흔들기 시간

    bool isRunning = false; //Is the coroutine running right now?

    Quaternion rot;

    void Start()
    {
        // 초기 흔들기 관련 수치 저장
        _originShakeAmount = _shakeAmount;
        _originshakeDuration = _shakeDuration;

        // 초기 회전 수치 저장
        rot = transform.rotation;

        // 테스트용 흔들기
        if (_debugMode) ShakeCamera();
    }


    // 설정값으로 카메라 흔들기
    void ShakeCamera()
    {

        _startAmount = _shakeAmount;
        _startDuration = _shakeDuration;

        if (!isRunning) StartCoroutine(Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
    }

    // 지정된 값으로 카메라 흔들기
    public void ShakeCamera(float amount, float duration)
    {

        _shakeAmount += amount;
        _startAmount = _shakeAmount;
        _shakeDuration += duration;
        _startDuration = _shakeDuration;

        if (!isRunning) StartCoroutine(Shake());
    }

    // 흔들기 코루틴
    IEnumerator Shake()
    {
        // 흔들기 시작
        isRunning = true;

        // 흔들기 시간이 0이될때까지 흔들어라
        while (_shakeDuration > 0.01f)
        {
            // 랜덤한 회전 수치를 구함
            Vector3 rotationAmount = Random.insideUnitSphere * _shakeAmount;
            // Z축은 건들지 않음
            rotationAmount.z = 0;

            // 흔들기 퍼센트지를 구함
            _shakePercentage = _shakeDuration / _startDuration;

            // 흔들기 힘 계산
            _shakeAmount = _startAmount * _shakePercentage;
            // 흔들기 시간 감소
            _shakeDuration = Mathf.Lerp(_shakeDuration, 0, Time.deltaTime);
            // 흔들기 수행
            transform.rotation = Quaternion.Euler(rot.eulerAngles - rotationAmount);

            yield return null;
        }

        // 모두 흔들었다면 초기화
        _shakeAmount = _originShakeAmount;
        _shakeDuration = _originshakeDuration;
        transform.rotation = rot;

        // 흔들기 끝
        isRunning = false;
    }

}