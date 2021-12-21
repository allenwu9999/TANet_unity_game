using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Password : MonoBehaviour
{
    // Start is called before the first frame update
    public Text passwordUI;
    string DataPath = "./Assets/Password/password_1.txt";
    string UsedPath = "./Assets/Password/used_password.txt";
    int pwdIndex = 0;
    string pwd;
    void Start()
    {
        ReadUsedPwd(UsedPath);
        ReadAllPwd(DataPath);
        WriteFile(UsedPath);
    }

    // Update is called once per frame
    void Update()
    {
        passwordUI.text = "請洽服務人員索取密碼";
    }
    void ReadUsedPwd(string path){
        //pwdIndex = 0;
        //do the reading part
        //string path = "Assets/Password/fight_password.txt";
        StreamReader reader = new StreamReader(path);
        // while(!reader.EndOfStream){
        //     string pwd = reader.ReadLine();
        //     Debug.Log(pwd);
        // }
        while(!reader.EndOfStream){
            reader.ReadLine();
            pwdIndex ++;
        }
        Debug.Log(pwdIndex);
        reader.Close();
    }
    void ReadAllPwd(string path){
        // pwdIndex = 1;
        StreamReader reader = new StreamReader(path);
        while(pwdIndex > 0 && !reader.EndOfStream){
            pwdIndex --;
            reader.ReadLine();
        }
        if(!reader.EndOfStream){
            pwd = reader.ReadLine();
        }
        reader.Close();
    }
    void WriteFile(string path){
        //string path = "Assets/Password/fight_password.txt";
        //string path = "Assets/Password/test.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(pwd);
        writer.Close();
    }
}
