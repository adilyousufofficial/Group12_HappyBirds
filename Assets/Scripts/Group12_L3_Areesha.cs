using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Group12_L3_Areesha : MonoBehaviour
{
    List<GameObject> cubes = new List<GameObject>();

    public Text validation_txt, steps_txt;

    public InputField field;

    public GameObject animate;
    public GameObject interfacee;
    public GameObject Cam;
    public GameObject parent;
    public GameObject Btn;
    public GameObject ff;
    public GameObject can;
    public GameObject Prefab;

    //Sound Objects
    public AudioSource SpaceClick;
    public AudioSource audioSrc;
    public AudioClip audioFile;

    bool showAnimationAccept = false;
    bool showAnimationReject = false;
    bool checkReject = false;
    bool created;
    int curr = 0;
    int selected_box;
    string currentState = "0";
    String movement = "R";

    // Start is called before the first frame update
    void Start()
    {
        created = false;
        selected_box = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!showAnimationAccept && !showAnimationReject)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpaceClick.Play();                  
                string txt = cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text;

                if (currentState == "0")
                {
                    if (txt == "a")
                    {
                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "x";
                        steps_txt.text = ("State => Q1");
                        movement = "R";
                        currentState = "1";
                    }
                    else if (txt == "b")
                    {
                        steps_txt.text = ("State => Q3");
                        movement = "R";
                        currentState = "3";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);
                }
                else if (currentState == "1")
                {
                    if (txt == "a" || txt == "b" || txt == "y")
                    {
                        steps_txt.text = ("State => Q1");
                        currentState = "1";
                        movement = "R";
                    }
                    else if (txt == "c")
                    {
                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "y";
                        steps_txt.text = ("State => Q2");
                        currentState = "2";
                        movement = "L";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                    Head_Direction(movement);
                }
                else if (currentState == "2")
                {
                    if (txt == "a" || txt == "b" || txt == "y")
                    {
                        steps_txt.text = ("State => Q2");
                        currentState = "2";
                        movement = "L";
                    }
                    else if (txt == "x")
                    {
                        steps_txt.text = ("State => Q0");
                        currentState = "0";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);
                }
                else if (currentState == "3")
                {
                    if (txt == "b")
                    {
                        steps_txt.text = ("State => Q3");
                        currentState = "3";
                        movement = "R";
                    }
                    else if (txt == "y")
                    {
                        steps_txt.text = ("State => Q4");
                        currentState = "4";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);
                }
                else if (currentState == "4")
                {
                    if (txt == "y")
                    {
                        steps_txt.text = ("State => Q4");
                        currentState = "4";
                        movement = "R";
                    }
                    else if (txt == "d")
                    {
                        steps_txt.text = ("State => Q5");
                        currentState = "5";
                        movement = "L";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);
                }
                else if (currentState == "5")
                {
                    if (txt == "b" || txt == "y")
                    {

                        //cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "E";
                        steps_txt.text = ("State => Q5");
                        currentState = "5";
                        movement = "L";
                    }
                    else if (txt == "x")
                    {
                        steps_txt.text = ("State => Q6");
                        currentState = "6";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);
                }
                else if (currentState == "6")
                {
                    if (txt == "b")
                    {
                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "x";
                        steps_txt.text = ("State => Q7");
                        currentState = "7";
                        movement = "R";
                    }
                    else if (txt == "y")
                    {
                        steps_txt.text = ("State => Q9");
                        currentState = "9";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);

                }
                else if (currentState == "7")
                {
                    if (txt == "b" || txt == "y")
                    {

                        //cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "E";
                        steps_txt.text = ("State => Q7");
                        currentState = "7";
                        movement = "R";
                    }
                    else if (txt == "d")
                    {

                        cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "y";
                        steps_txt.text = ("State => Q8");
                        currentState = "8";
                        movement = "L";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);
                }
                else if (currentState == "8")
                {
                    if (txt == "b" || txt == "y")
                    {

                        //cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "E";
                        steps_txt.text = ("State => Q8");
                        currentState = "8";
                        movement = "L";
                    }
                    else if (txt == "x")
                    {

                        //cubes[curr].transform.GetChild(0).GetComponent<TMP_InputField>().text = "E";
                        steps_txt.text = ("State => Q6");
                        currentState = "6";
                        movement = "R";
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }

                    Head_Direction(movement);
                }
                else if (currentState == "9")
                {
                    if (txt == "y")
                    {
                        steps_txt.text = ("State => Q9");
                        currentState = "9";
                        movement = "R";
                    }
                    else if (txt == "E")
                    {
                        steps_txt.text = ("State => Q10");
                        currentState = "10";
                        movement = "R";
                        return;
                    }
                    else
                    {
                        showAnimationReject = true;
                        Validate_String();
                        return;
                    }
                    Head_Direction(movement);

                }
                else if (currentState == "10")
                {
                    steps_txt.text = ("State => Q10");
                    print("Accepted");
                    showAnimationAccept = true;
                    Validate_String();
                }
            }
        }
    }

    //Validating
    public void Validate_String()
    {
        if (showAnimationAccept)
        {
            animate.GetComponent<Animator>().enabled = true;
            animate.GetComponent<Animator>().Play("acteee");
            validation_txt.color = Color.green;
            ShowAnimation("accept");
            PlaySound("accept");
            validation_txt.text = "VALID STRING";
            interfacee.SetActive(true);
        }
        else if (showAnimationReject)
        {
            if (checkReject)
            {
                animate.GetComponent<Animator>().enabled = true;
                animate.GetComponent<Animator>().Play("reeeejact");
                checkReject = false;
                validation_txt.color = Color.red;
                ShowAnimation("reject");
                PlaySound("reject");
                print("346: checkReject: " + checkReject);
                validation_txt.text = "INVALID STRING";
                Debug.Log("INVALID STRING");
                interfacee.SetActive(true);
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
        PlaySound("forward");
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
                //v.x = v.x + 2;
                v.x = (float)(v.x + 2.5);
                Cam.transform.position = v;
            }
        }
        curr++;
    }

    public void moveLeft()
    {
        PlaySound("backward");
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
                    v.x = (float)(v.x - 2.5);
                    Cam.transform.position = v;
                }
            }
        }
    }

    //Play Sound
    public void PlaySound(string audioFileName)
    {
        audioFile = Resources.Load<AudioClip>(audioFileName);
        audioSrc.PlayOneShot(audioFile);
    }

    //Animations
    public void ShowAnimation(string condition)
    {
        if (condition == "accept")
        {
            animate.gameObject.GetComponent<Animator>().SetInteger("run", 1);
            showAnimationReject = false;
            showAnimationAccept = true;
        }
        else if (condition == "reject")
        {
            animate.gameObject.GetComponent<Animator>().SetInteger("run", 2);
            showAnimationAccept = false;
            showAnimationReject = true;
        }
    }

    //Generating Cube on Button Click
    public void Generate()
    {
        if (created)
        {
            animate.gameObject.GetComponent<Animator>().Rebind();

            for (int i = 0; i < cubes.Count; i++)
                Destroy(cubes[i].gameObject);


            created = false;
            cubes.Clear();

            Vector3 v = Cam.transform.position;
            v.x = 0;
            Cam.transform.position = v;

            selected_box = 0;
            validation_txt.text = "";
            curr = 0;
            showAnimationAccept = false;
            showAnimationReject = false;
            currentState = "0";
            movement = "R";
        }

        int n = field.text.Length;
        bool input = true;
        char[] Arr = field.text.ToCharArray();
        if (Regex.IsMatch(field.text, "^[abcd]+$") || field.text.Length == 0)
            input = true;
        else
            input = false;

        if (input == false)
        {
            validation_txt.text = "";
            field.text = "Invalid";
            return;
        }
        Instantiate_Boxes(n + 4);
    }
    public void Instantiate_Boxes(int n)
    {
        steps_txt.text = ("State => Q0");
        GameObject Can = GameObject.Find("Canvas");
        created = true;
        string st = field.text;
        char[] chars = st.ToCharArray();
        int count = 0;
        for (int i = 0; i < n; i++)
        {

            GameObject obj = Instantiate(Prefab, new Vector3(i * 2.5F, 0, 0), Quaternion.identity);
            obj.transform.SetParent(parent.transform);

            if (i < 2 || i >= n - 2)
                obj.transform.GetChild(0).GetComponent<TMP_InputField>().text = "E";
            else
            {

                obj.transform.GetChild(0).GetComponent<TMP_InputField>().text = chars[count] + "";
                count++;
            }
            cubes.Add(obj);
        }
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
