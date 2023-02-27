using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using TMPro;
using UnityEngine.UI;

public class File_Manager : MonoBehaviour
{
    public  string base_file_path;
    static string room_good_global;
    static string room_user_global;
    public string baseFilePath;
    public GameObject DOOR;
    public GameObject popup;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
       //Debug.Log();
        DeleteFiles();
       // WriteString();
       // CompareFiles();

        Invoke("check", 1);
        
    }

    // Update is called once per frame

    public  void WriteString()
    {
        //string path = Path.GetFullPath("./");
        string path = Application.dataPath;
        string what_to_write = "test";

        /* Citam los fajl i upisujem contents u what_to_write */
        string bad_path = Path.GetFullPath("./") + "/Template/Bad/roomBad.txt";
        StreamReader reader = new StreamReader(bad_path);
        what_to_write = reader.ReadToEnd();
        reader.Close();

        StreamWriter writer1 = new StreamWriter(base_file_path + "/door.txt", true);
        writer1.Close();


        /* Citam fajl koji player treba da eddituje, sadrzaj fajla pisem u check*/
        string check = "";
        string path_check = base_file_path + "/door.txt";
        StreamReader reader_check = new StreamReader(path_check);
        check = reader_check.ReadToEnd();
        reader_check.Close();

        /* Testiram da l je fajl koji player treba da eddituje prazan, ako jeste upisujem ono sto treba da se eddituje*/
        if (check.Length == 0)
        {
            StreamWriter writer = new StreamWriter(base_file_path + "/door.txt", true);
            writer.WriteLine(what_to_write);
            writer.Close();
        }

    }

    public  void DeleteFiles()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/escape/");
        File.WriteAllText(Application.streamingAssetsPath + "/escape/" + "door"+".txt", "*******************************\n*******************************\n****-----------------------****\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n****--------DOOR=false------|***\n*******************************\n*******************************");



        //string path = Path.GetFullPath("./");
        string path = Application.dataPath;
        int pom = 0;
        //string actual_path = ;
        base_file_path = Application.streamingAssetsPath + "/escape/" + "door" + ".txt";
        /* Uzimam relative fajl path fajla u kome je smestena igrica, uzimam samo prvi "nivo" fajla */
        //char[] main_path = path.ToCharArray();
        //for (int i = 0; i < main_path.Length; i++)
        //{
        //    if ((int)main_path[i] == 92)
        //    {
        //        pom++;
        //        if (pom == 2)
        //        {
        //            base_file_path = string.Copy(actual_path);
        //            //baseFilePath = base_file_path;
        //            break;
        //        }
        //    }
        //    actual_path = actual_path.Insert(i, main_path[i].ToString());
        //}

        //string pathh = System.IO.Path.Combine(base_file_path, "door.txt");
        //UnityEditor.FileUtil.DeleteFileOrDirectory(pathh);
        //AssetDatabase.Refresh();

    }

    public  void CompareFiles()
    {
        string room_good = "";
        string room_user = "";


        string path = base_file_path;
        StreamReader reader = new StreamReader(path);
        room_user = reader.ReadToEnd();
        room_user_global = room_user;

        reader.Close();

        string path_good = Path.GetFullPath("./") + "/Template/roomGood.txt";
        StreamReader reader_good = new StreamReader(path_good);
        room_good = reader_good.ReadToEnd();
        room_good_global = room_good;
        reader_good.Close();

        

        if (room_user.Equals( "*******************************\n*******************************\n****-----------------------****\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n****--------DOOR=true------|***\n*******************************\n*******************************"))
        {
            DOOR.SetActive(true);
            popup.SetActive(false);
            Debug.Log(" BOG NIJE MRTAV!!!!!!!!!!!!! (i ova 2 fajla su ista) ");
        }
        else
        {
            Debug.Log("bog je mrtav :(");
        }
    }


    void Update()
    {

    }


    void check()
    {
        string room_user = "";
        string path = base_file_path;
        StreamReader reader = new StreamReader(path);
        room_user = reader.ReadToEnd();
        reader.Close();
        //text.text = room_user;

        if (room_user == "*******************************\n*******************************\n****-----------------------****\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n***|///////////////////////|***\n****--------DOOR=true------|***\n*******************************\n*******************************")
        {
            Debug.Log("++++++++++++++++++++++++++++++++udate loop jesete equal");
            DOOR.SetActive(true);
            popup.SetActive(false);
            
        }
        else
        {
            Debug.Log("--------------------------------udate loop nije equal");

        }
        Invoke("check", 1);
    }

}


