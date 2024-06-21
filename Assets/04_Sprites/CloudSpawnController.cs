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
//    int preloadDownCount = 5;   //5개 정도가 적당할것같다.

//    int preloadCount = 5;
//    private void Awake()
//    {
//        satgeManager=GetComponent<SatgeManager>();
//    }

//    public void MakePlatforms(float _startPos, float _distance)
//    {
//        //카메라 영역의 크기를 가져온다 
//        var _orthoSize = Camera.main.orthographicSize;

//        //발판이 시작되는 위치부터 화면의 영역에 들어갈 발판의 갯수를 구한다
//        var _screenHeight = (_orthoSize * 2) - _startPos;
//        var _divideCount = (int)(_screenHeight / _distance);

//        //화면에 보여질 발판외에 상단에 미리 생성해 놓을 발판의 갯수를 추가하여
//        //캐릭터 기준으로 위로 몇개의 발판이 놓일지 정한다.
//        preloadUpCount = _divideCount + preloadCount;

//        //발판이 시작될 위치를 계산한다
//        platformStartPosition = -_orthoSize + _startPos;
//        //발판 사이의 거리를 지정한다
//        platformDistance = _distance;

//        Debug.Log("PreloadCount " + preloadUpCount);

//        transform.position = Vector3.up * -_orthoSize;

//        //만들어질 발판의 갯수를 정한다
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

//            //발판의 순서를 정해준다
//            _platform.SetPlatformIndex(i);

//            platforms.Add(_platform);
//        }

//        //아래로 다섯개가 생기기 때문에 현재 위치는 5번째가 된다.
//        curPlatformIndex = preloadDownCount;
//    }

//    //외부에서 타겟의 높이를 가져와서 현재 발판의 중심 위치를 갱신해준다
//    public void UpdatePlatform(float _targetYposition)
//    {
//        var _diff = _targetYposition - platformStartPosition;
//        var _index = (int)(_diff / platformDistance);

//        //타겟의 위치에 밑에 배치되는 발판의 수를 더해서 배열상의 발판위치를 만들어준다
//        _index += preloadDownCount;

      

      
//    }
//    void Start()
//    {
        
        

//    }
//    private void Update()
//    {
     
//    }
    




//}




    

