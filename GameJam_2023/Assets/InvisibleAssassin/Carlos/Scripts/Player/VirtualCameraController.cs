using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualCameraController : MonoBehaviour
{
    public static VirtualCameraController instance;

    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private Animator VirtualCameraAnimator;
    [SerializeField] private int sceneIndex;

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        VirtualCameraAnimator = GetComponent<Animator>();
        VirtualCameraDontDestroyOnLoad();
    }

    private void VirtualCameraDontDestroyOnLoad()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex.Equals(0)) sceneIndex = 1;
        else sceneIndex = 0;
    }

    public void VirtualCameraBeginAnimation()
    {
        VirtualCameraAnimator.SetTrigger("TransitionBegin");
    }

    public void VirtualCameraEndAnimation()
    {
        _cinemachineVirtualCamera.Follow = FindObjectOfType<PlayerController>().transform;
        VirtualCameraAnimator.SetTrigger("TransitionEnd");
    }
    
    public void PlayerParametersWhenAnimationRunning(int boolNumber)
    {
        bool shouldEnable = boolNumber.Equals(1);
     
        PlayerStorage playerStorage = FindObjectOfType<PlayerStorage>();
        playerStorage.PlayerController.enabled = shouldEnable;
        playerStorage.PlayerController.Animator.SetBool("IsWalking", false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}