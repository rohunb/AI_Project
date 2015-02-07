//U//using UnityEngine;
//U//using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public enum ComponentType { Weapon, Defense, Power, Support }

public abstract class ShipComponent//U// : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    //Component info and stats
    //U//[SerializeField]
    private ComponentType compType;
    public ComponentType CompType
    {
        get { return compType; }
    }
    public string componentName;
    public bool unlocked;

    //U//[SerializeField]
    private float activationCost;
    public float ActivationCost
    {
        get { return activationCost; }
    }
    //U//[SerializeField]
    private float powerDrain;
    public float PowerDrain
    {
        get { return powerDrain; }
    }
    //U//[SerializeField]
    private float maxHP;

    private float compHP;
    public float CompHP
    {
        get { return compHP; }
    }

    //interface
    private bool selected;
    public bool Selected
    {
        get { return selected; }
        set
        {
            selected = value;
            //selection effect here
//#if FULL_DEBUG
//            if(!selectionHalo)
//            {
//                Debug.LogError("Selection Halo not set");
//            }
//#endif
//            selectionHalo.SetActive(value);
        }
    }

    //cached references
    //U//[SerializeField]
    //U//private GameObject selectionHalo;


    public virtual void Init()
    {
        //selectionHalo = transform.FindChild("SelectionHalo").gameObject;
        compHP = maxHP;

    }

}
