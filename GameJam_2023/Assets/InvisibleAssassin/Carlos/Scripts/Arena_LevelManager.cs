using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena_LevelManager : MonoBehaviour
{
    [SerializeField] private PlayerStorage playerStorage;

    private void Awake()
    {
        playerStorage = FindObjectOfType<PlayerStorage>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        ScenePlayerParameters();
        VirtualCameraController.instance.VirtualCameraEndAnimation();
    }
    
    private void ScenePlayerParameters()
    {
        playerStorage.PlayerController.Speed = 5f;
        playerStorage.PlayerController.TurnSmoothTime = 0.1f;
        playerStorage.PlayerController.Animator.SetFloat("PlayerSpeed", playerStorage.PlayerController.Speed);
        playerStorage.PlayerController.Animator.SetLayerWeight(1, 1);
        playerStorage.Sword.SetActive(true);
        playerStorage.Trail.SetActive(true);
    }
}
