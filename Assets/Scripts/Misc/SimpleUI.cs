﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ModuloKart.CustomVehiclePhysics;

namespace ModuloKart.HUD
{

    public class SimpleUI : MonoBehaviour
    {
        VehicleBehavior[] vehicleBehaviors;
        [HideInInspector] public VehicleBehavior vehicleBehavior;
        public SimpleCharacterSelection simpleCharacterSeleciton;
        public int PlayerID;
        public Text Value_Velocity;
        public Text Value_Nitros;
        public GameObject BeginBackgroundObject;
        public GameObject ViewPortRect;
        public Image velocityRadial;
        public Image velocityRadialRed;
        public Image nitrosRadial;
        public Image extra_nitros_radial;
        SimpleCharacterSelection character;

        public GameObject GameOverBackgroundObject;
        public Text TextGameOver;
        public Text TextRaceProgress;
        public Text TextRacePlacement;
        public Text TextRaceTime;
        public Text TextLastLapTime;
        public GameObject WrongDirectionWarning;
        public GameObject placeshower;
        public GameObject TimeSplitsObj;
       

        private void Start()
        {
            BeginBackgroundObject.SetActive(false);
            character = GameObject.FindObjectOfType<SimpleCharacterSelection>();
            simpleCharacterSeleciton = GetComponent<SimpleCharacterSelection>();
            if (simpleCharacterSeleciton)
                Debug.Log("Has Character Selection");
            vehicleBehaviors = GameObject.FindObjectsOfType<VehicleBehavior>();
            foreach (VehicleBehavior v in vehicleBehaviors)
            {
                if (v.PlayerID == PlayerID)
                {
                    vehicleBehavior = v;
                    //simpleCharacterSeleciton.BeginCharacterSelection(vehicleBehavior);
                }
            }
        }

        private void Update()
        {
            if (vehicleBehavior == null) return;
            if (Value_Velocity == null) return;
            if (Value_Nitros == null) return;

            Value_Velocity.text = (Mathf.FloorToInt(vehicleBehavior.accel_magnitude_float)).ToString();
            Value_Nitros.text = (Mathf.FloorToInt(vehicleBehavior.nitros_meter_float)).ToString();
            Extra_NitrosMeter(vehicleBehavior.extra_nitros_meter_float);

            Speedometer(vehicleBehavior.accel_magnitude_float);
            NitrosMeter(vehicleBehavior.nitros_meter_float);

            if (BeginBackgroundObject.activeSelf)
            {
                if (vehicleBehavior.JoyStick != -1)
                {
                    BeginBackgroundObject.SetActive(false);
                }
            }
        }
        void Speedometer(float fillValue)
        {
            float amount = (((fillValue)/ 100.0f) * 180.0f / 360) * 0.6f;
            if (amount <= 0.6f)
            {
                velocityRadial.fillAmount = amount;
            }
            velocityRadialRed.fillAmount = amount;
        }

        void NitrosMeter(float fillValue)
        {
            float amount = ((fillValue) / 100.0f);
            
            nitrosRadial.fillAmount = amount;
        }
        void Extra_NitrosMeter(float fillValue)
        {
            float amount = ((fillValue) / 50.0f);

           extra_nitros_radial.fillAmount = amount;
        }
       
    }

}