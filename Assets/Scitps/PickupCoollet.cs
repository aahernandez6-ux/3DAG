using System;
using UnityEngine;
using UnityEngine.UI;
public class PickupCoollet : MonoBehaviour
{
    //Battery Coollet logic


    public static int pickAmount = 0;


    // Hold the images
    public static RawImage hud;

    //Battery sprite
    [SerializeField] Texture pickpu1Tex;
    [SerializeField] Texture pickpu2Tex;
    [SerializeField] Texture pickpu3Tex;
    [SerializeField] Texture pickpu4Tex;
    [SerializeField] Texture pickpu0Tex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Find the GameObject
        hud = gameObject.GetComponentInChildren<RawImage>();

        //Hide the image on start
        hud.enabled = false;

        //Set in
        pickAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickAmount == 1)
        {
            hud.texture = pickpu1Tex;

            hud.enabled = true;
        }
        else if (pickAmount == 2)
        {
            hud.texture = pickpu2Tex;

        }
        else if (pickAmount == 3)
        {
            hud.texture = pickpu3Tex;

        }
        else if (pickAmount == 4)
        {
            hud.texture = pickpu4Tex;

        }
        else
        {
            hud.texture = pickpu0Tex;
        }
     }  
