using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using System;
using UnityEngine;
using UNIX_Fixer;
using static UNIX_Log.Logger;
using System.IO;
using System.Diagnostics.Tracing;
using System.Collections.Generic;

namespace UNIX
{
    public class Menu : MelonMod
    {
        bool MainMenu = false;
        public override void OnInitializeMelon()
        {
            //Clear
            ClearLog();

            //Welcom information
            SendLog(Level.MESSAGE, "Welcome to UNIX");
            SendLog(Level.INFO, "Version: 1.3");
            SendLog(Level.INFO, "Devoloper: BigBrain_Z");

            //Space
            SendLog(Level.SPACE, null);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                this.MainMenu = !this.MainMenu;
            }
        }

        public override void OnGUI()
        {
            GUI.Label(new Rect(900, 0, 100, 60), "<color=magenta>[UNIX]: [1.3]</color>");

            if (MainMenu == true)
            {
                //INSPECTOR
                Base_UI.Window("UNIX | Inspector", new Rect(0f, 0f, 200f, 290f));
                GUI.Label(new Rect(10, 30, 200, 100), "HotKey: F1");
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    obj = InspectorUnity.GetInspect_GameObject();
                    ObjectName = obj.name;
                    ObjectPosition = obj.transform.position;
                }
                GUI.Label(new Rect(10f, 60f, 200f, 60f), $"Name: {ObjectName}");
                GUI.Label(new Rect(10f, 80f, 200f, 60f), $"Position: {ObjectPosition}");
                SendLog(Level.INFO, $"Name: {ObjectName}");
                SendLog(Level.INFO, $"Position: {ObjectPosition}");

                //Editor
                Base_UI.Window("UNIX | Editor", new Rect(200f, 0f, 127f, 290f));
                if (Base_UI.Button("Destroy", Base_UI.NormalButtonSize, 0f))
                {
                    if (Button_patcher.Button_fixer())
                        GameObject.Destroy(obj);
                }

                if (Base_UI.Button("Clone", Base_UI.NormalButtonSize, 1f))
                {
                    if (Button_patcher.Button_fixer())
                    {
                        GameObject CloneObject = GameObject.Instantiate(obj);
                        CloneObject.transform.position = obj.transform.position + obj.transform.forward;
                        CloneObject.AddComponent<Rigidbody>();
                    }
                }

                //FreeCam
                Base_UI.Window("UNIX | FreeCam", new Rect(327f, 0f, 127f, 290f));
                if (Base_UI.Button("Run", Base_UI.NormalButtonSize, 0f))
                {
                    if (Button_patcher.Button_fixer())
                    {
                        ourCamera = new GameObject("Freecam").AddComponent<Camera>();
                        ourCamera.gameObject.tag = "MainCamera";
                        InFreeCam = true;

                        ourCamera.transform.position = Camera.main.transform.position;
                        ourCamera.transform.rotation = Camera.main.transform.rotation;
                        SendLog(Level.WARNING, "FreeCam Running!");
                    }
                }

                if (Base_UI.Button("Stop", Base_UI.NormalButtonSize, 1f))
                {
                    if (Button_patcher.Button_fixer())
                    {
                        GameObject.Destroy(ourCamera);
                        InFreeCam = false;
                        SendLog(Level.WARNING, "FreeCam Stoped!");
                    }
                }

                if (Base_UI.Button("FullBright", Base_UI.NormalButtonSize, 3f))
                {
                    if (Button_patcher.Button_fixer())
                    {
                        RenderSettings.ambientLight = Color.white;
                    }
                }

                if (InFreeCam)
                {
                    //NextGo
                    if (Input.GetKey(KeyCode.W))
                    {
                        ourCamera.transform.position += ourCamera.transform.forward * speed * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        ourCamera.transform.position += ourCamera.transform.forward * -speed * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        ourCamera.transform.position += ourCamera.transform.right * speed * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        ourCamera.transform.position += ourCamera.transform.right * -speed * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        speed = 15f;
                    }
                    else
                    {
                        speed = 6f;
                    }

                    // Rotation
                    if (Input.GetMouseButton(1))
                    {
                        yaw += 5f * Input.GetAxis("Mouse X");
                        pitch -= 5f * Input.GetAxis("Mouse Y");
                        ourCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
                    }
                }
            }
        }

        public static GameObject[] FindObjectsByName(string name)
        {
            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
            List<GameObject> matchingObjects = new List<GameObject>();

            foreach (GameObject obj1 in allObjects)
            {
                if (obj1.name == name)
                {
                    matchingObjects.Add(obj1);
                }
            }

            return matchingObjects.ToArray();
        }

        
        GameObject obj;
        string ObjectName = "None";
        Vector3 ObjectPosition = new Vector3(0, 0, 0);

        bool InFreeCam;
        Camera ourCamera;
        public float yaw;
        public float pitch;
        public float speed = 6f;
    }
}
