﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Group12_L1_Adil : MonoBehaviour
{
    List<GameObject> cubes = new List<GameObject>();

    public Text validation_txt, steps_txt;

    public InputField field;

    public GameObject interfacee;
    public GameObject Cam;
    public GameObject parent;
    public GameObject Btn;
    public GameObject ff;
    public GameObject can;
    public GameObject Prefab;

    public GameObject angry_anim;
    public GameObject accept;
    public GameObject reject;

    //Sound Objects
    public AudioSource audioSrc;
    public AudioClip audioFile;

    public AudioSource audioSrcBG;
    public AudioSource audioSrcAccept;
    public AudioSource audioSrcReject;
    public AudioSource audioSrcForward;
    public AudioSource audioSrcBackward;

    //Animations Objects
    bool showAnimationAccept = false;
    bool showAnimationReject = false;
    bool showAnimationAcceptOnce = false;
    bool showAnimationRejectOnce = false;

    float spacingBox = 2.0F;
    int curr = 0;
    int selected_box;
    bool created;
    string CState = "1";
    String movement = "R";
    bool checkReject = false;


    // Start is called before the first frame update
    void Start()
    {
        created = false;
        selected_box = 0;
        audioSrcBG.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (showAnimationAccept && showAnimationAcceptOnce)
        {
            showAnimationAcceptOnce = false;

            angry_anim.GetComponent<Animator>().enabled = true;
            angry_anim.GetComponent<Animator>().Play("RejectAdil");
            audioSrcAccept.Play();

        }
        else if (showAnimationReject && showAnimationRejectOnce)
        {
            showAnimationRejectOnce = false;

            angry_anim.GetComponent<Animator>().enabled = true;
            angry_anim.GetComponent<Animator>().Play("AcceptAdil");
            audioSrcReject.Play();
        }


        if (!showAnimationAccept && !showAnimationReject)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                string txt = cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text;

                if (CState == "0")
                {
                    if (txt == "a")
                    {
                        CState = "0";
                        movement = "L";
                    }
                    else if (txt == "#")
                    {
                        CState = "5";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "1")
                {
                    if (txt == "a")
                    {
                        CState = "1";
                        movement = "R";
                    }
                    else if (txt == "b")
                    {
                        CState = "2";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "2")
                {
                    if (txt == "a")
                    {
                        CState = "3";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "3")
                {
                    if (txt == "a")
                    {
                        CState = "3";
                        movement = "R";
                    }
                    else if (txt == "#")
                    {
                        CState = "4";
                        movement = "L";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "4")
                {
                    if (txt == "a")
                    {
                        CState = "4";
                        movement = "L";
                    }
                    else if (txt == "b")
                    {
                        CState = "4";
                        movement = "L";
                    }
                    else if (txt == "#")
                    {
                        CState = "5";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "5")
                {
                    if (txt == "a")
                    {
                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "#";
                        CState = "6";
                        movement = "R";
                    }
                    else if (txt == "b")
                    {
                        CState = "13";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "6")
                {
                    if (txt == "a")
                    {
                        CState = "6";
                        movement = "R";
                    }
                    else if (txt == "b")
                    {
                        CState = "7";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "7")
                {
                    if (txt == "a")
                    {
                        CState = "8";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "8")
                {
                    if (txt == "a")
                    {
                        CState = "8";
                        movement = "R";
                    }
                    else if (txt == "#")
                    {
                        CState = "9";
                        movement = "L";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "9")
                {
                    if (txt == "a")
                    {
                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "#";
                        CState = "10";
                        movement = "L";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "10")
                {
                    if (txt == "a")
                    {
                        CState = "10";
                        movement = "L";
                    }
                    else if (txt == "b")
                    {
                        CState = "11";
                        movement = "L";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "11")
                {
                    if (txt == "a")
                    {
                        CState = "0";
                        movement = "L";
                    }
                    else if (txt == "#")
                    {
                        CState = "12";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "12")
                {
                    if (txt == "b")
                    {
                        CState = "13";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "13")
                {
                    if (txt == "a")
                    {
                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "#";
                        CState = "14";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                else if (CState == "14")
                {
                    if (txt == "a")
                    {
                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "#";
                        CState = "14";
                        movement = "R";
                    }
                    else if (txt == "#")
                    {
                        CState = "15";
                        steps_txt.text = ("State => Q" + CState);
                        showAnimationAccept = true;
                        Validate_String();
                        return;
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                }
                steps_txt.text = ("State => Q" + CState);
                Head_Direction(movement);
            }
        }
    }

    //Validating Palidrome String
    public void Validate_String()
    {
        if (showAnimationAccept)
        {
            validation_txt.color = Color.green;
            ShowAnimation("accept");
            validation_txt.text = "VALID STRING";
            interfacee.SetActive(true);
            showAnimationAcceptOnce = true;
        }
        else if (showAnimationReject)
        {
            if (checkReject)
            {
                checkReject = false;
                validation_txt.color = Color.red;
                ShowAnimation("reject");
                print("346: checkReject: " + checkReject);
                validation_txt.text = "INVALID STRING";
                Debug.Log("INVALID STRING");
                interfacee.SetActive(true);
                showAnimationRejectOnce = true;
            }
            else
            {
                showAnimationReject = false;
                print("352: checkReject: " + checkReject);
                checkReject = true;
            }
        }
    }

    //Movement Functions
    void Head_Direction(string direction = "R")
    {
        if (direction == "R")
        {
            moveRight();
        }
        else if (direction == "L")
        {
            moveLeft();
        }
    }

    public void moveRight()
    {
        audioSrcForward.Play();
        angry_anim.GetComponent<Animator>().enabled = true;
        angry_anim.GetComponent<Animator>().Rebind();
        angry_anim.GetComponent<Animator>().Play("right_movement");
        //moveText.text = "R";
        Vector3 forward = Vector3.forward;
        Ray ray = new Ray(Cam.transform.position, forward);
        RaycastHit hit;

        Debug.DrawRay(Cam.transform.position, forward * 10, Color.red);
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (selected_box < cubes.Count - 1)
            {
                selected_box++;
                cubes[selected_box].transform.GetChild(0).GetComponent<TMP_InputField>().ActivateInputField();

                Vector3 v = Cam.transform.position;
                v.x = (float)(v.x + spacingBox);
                Cam.transform.position = v;
            }
        }
        curr++;
    }

    public void moveLeft()
    {
        audioSrcBackward.Play();
        angry_anim.GetComponent<Animator>().enabled = true;
        angry_anim.GetComponent<Animator>().Rebind();
        angry_anim.GetComponent<Animator>().Play("left_movement");
        curr--;
        Vector3 forward = Vector3.forward;
        Ray ray = new Ray(Cam.transform.position, forward);
        RaycastHit hit;

        Debug.DrawRay(Cam.transform.position, forward * 10, Color.red);
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (selected_box > 0)
            {
                selected_box--;
                cubes[selected_box].transform.GetChild(0).GetComponent<TMP_InputField>().ActivateInputField();
                if (selected_box != -1)
                {
                    Vector3 v = Cam.transform.position;
                    v.x = (float)(v.x - spacingBox);
                    Cam.transform.position = v;
                }
            }
        }
    }

    //Animations
    public void ShowAnimation(string condition)
    {
        if (condition == "accept")
        {
            showAnimationReject = false;
            showAnimationAccept = true;
        }
        else if (condition == "reject")
        {
            showAnimationAccept = false;
            showAnimationReject = true;
        }
    }

    //Generating Cube on Button Click
    public void Generate()
    {
        if (created)
        {
            angry_anim.GetComponent<Animator>().Rebind();
            angry_anim.GetComponent<Animator>().enabled = false;

            for (int i = 0; i < cubes.Count; i++)
                Destroy(cubes[i].gameObject);

            created = false;
            cubes.Clear();

            Vector3 v = Cam.transform.position;
            v.x = 0;
            Cam.transform.position = v;

            curr = 0;
            selected_box = 0;
            validation_txt.text = "";
            CState = "1";
            showAnimationAccept = false;
            showAnimationReject = false;
        }

        int n = field.text.Length;
        bool input = true;
        char[] Arr = field.text.ToCharArray();
        if (Regex.IsMatch(field.text, "^[ab]+$") || field.text.Length == 0)
            input = true;
        else
            input = false;

        if (input == false)
        {
            validation_txt.text = "";
            field.text = "Invalid";
            return;
        }
        Instantiate_Boxes(n + 6);
    }

    public void Instantiate_Boxes(int n)
    {
        GameObject Can = GameObject.Find("Canvas");
        created = true;
        string st = field.text;
        char[] chars = st.ToCharArray();
        int count = 0;
        for (int i = 0; i < n; i++)
        {

            GameObject obj = Instantiate(Prefab, new Vector3(i * spacingBox, -0.3F, 0), Quaternion.identity);
            obj.transform.SetParent(parent.transform);

            if (i < 3 || i >= n - 3)
                obj.transform.GetChild(0).GetComponent<TMP_InputField>().text = "#";
            else
            {
                obj.transform.GetChild(0).GetComponent<TMP_InputField>().text = chars[count] + "";
                count++;
            }
            cubes.Add(obj);
        }
        moveRight();
        moveRight();
        moveRight();
        validation_txt.text = "";
        interfacee.SetActive(false);
    }

    public void back()
    {
        SceneManager.LoadScene("Group12_Main_Menu");
    }
}