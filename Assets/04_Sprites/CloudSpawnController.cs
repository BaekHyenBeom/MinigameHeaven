//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.UIElements;
//using static UnityEditor.PlayerSettings;
//using Random = UnityEngine.Random;

//public class CloudSpawnController : MonoBehaviour
//{
//    public SatgeManager satgeManager;

//    float platformStartPosition;
//    float platformDistance;

//    int curPlatformIndex = -1;

//    int preloadUpCount = 0;
//    int preloadDownCount = 5;   //5�� ������ �����ҰͰ���.

//    int preloadCount = 5;
//    private void Awake()
//    {
//        satgeManager=GetComponent<SatgeManager>();
//    }

//    public void MakePlatforms(float _startPos, float _distance)
//    {
//        //ī�޶� ������ ũ�⸦ �����´� 
//        var _orthoSize = Camera.main.orthographicSize;

//        //������ ���۵Ǵ� ��ġ���� ȭ���� ������ �� ������ ������ ���Ѵ�
//        var _screenHeight = (_orthoSize * 2) - _startPos;
//        var _divideCount = (int)(_screenHeight / _distance);

//        //ȭ�鿡 ������ ���ǿܿ� ��ܿ� �̸� ������ ���� ������ ������ �߰��Ͽ�
//        //ĳ���� �������� ���� ��� ������ ������ ���Ѵ�.
//        preloadUpCount = _divideCount + preloadCount;

//        //������ ���۵� ��ġ�� ����Ѵ�
//        platformStartPosition = -_orthoSize + _startPos;
//        //���� ������ �Ÿ��� �����Ѵ�
//        platformDistance = _distance;

//        Debug.Log("PreloadCount " + preloadUpCount);

//        transform.position = Vector3.up * -_orthoSize;

//        //������� ������ ������ ���Ѵ�
//        var _loopCount = preloadUpCount + preloadDownCount;
//        var _platFormStartPos = _startPos - (_distance * preloadCount);

//        Debug.Log("_loopCount : " + _loopCount);

//        var _prefab = Resources.Load("PlatformNormal");
//        for (int i = 0; i < _loopCount; i++)
//        {
//            var go = Instantiate(_prefab, transform) as GameObject;
//            var _platform = go.GetComponent<Platform>();
//            var _ypos = _platFormStartPos + (_distance * i);
//            go.transform.localPosition = Vector3.up * _ypos;

//            //������ ������ �����ش�
//            _platform.SetPlatformIndex(i);

//            platforms.Add(_platform);
//        }

//        //�Ʒ��� �ټ����� ����� ������ ���� ��ġ�� 5��°�� �ȴ�.
//        curPlatformIndex = preloadDownCount;
//    }

//    //�ܺο��� Ÿ���� ���̸� �����ͼ� ���� ������ �߽� ��ġ�� �������ش�
//    public void UpdatePlatform(float _targetYposition)
//    {
//        var _diff = _targetYposition - platformStartPosition;
//        var _index = (int)(_diff / platformDistance);

//        //Ÿ���� ��ġ�� �ؿ� ��ġ�Ǵ� ������ ���� ���ؼ� �迭���� ������ġ�� ������ش�
//        _index += preloadDownCount;

      

      
//    }
//    void Start()
//    {
        
        

//    }
//    private void Update()
//    {
     
//    }
    




//}




    

