using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    public static LoadScript loader;
    public int checkpointNumber = 0;
    public float playerWeight = 0;
    public int playerCharge = 0;
    public Vector3[] checkpointPos;
    public Vector3[] checkpointRot;
    public Camera[] checkpointCamera;
    private string savePath;
    private SaveData save;
    public GameObject weightPrefab;
    public GameObject batteryPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) { Save(); }
        if (Input.GetKeyDown(KeyCode.KeypadPeriod)) { Load(); }
    }

    private void Awake()
    {
        loader = this;
        savePath = Application.persistentDataPath + "/RoboHeist.dat";
    }

    public void Load()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            save = (SaveData)bf.Deserialize(file);
            file.Close();
            if(SceneManager.GetActiveScene().name != save.level) { Pause.pause.ChangeScene(save.level); }
            checkpointNumber = save.checkpoint;
            PlayerMove.player.gameObject.transform.position = checkpointPos[checkpointNumber];
            PlayerMove.player.gameObject.transform.rotation = Quaternion.Euler(checkpointRot[checkpointNumber]);
            CameraMenu.camMenu.ChangeCamera(checkpointCamera[checkpointNumber]);
            for(int i = 0; i < save.weight; i++)
            {
                if (i < save.charge)
                {
                    GameObject temp = Instantiate(batteryPrefab);
                    temp.GetComponent<ScoopableObject>().Scoop();
                }
                else
                {
                    GameObject temp = Instantiate(weightPrefab);
                    temp.GetComponent<ScoopableObject>().Scoop();
                }
            }
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if(File.Exists(savePath)) { file = File.Open(savePath, FileMode.Open); }
        else { file = File.Create(savePath); }
        Debug.Log(checkpointNumber + " " + playerWeight + " " + playerCharge);
        save = new SaveData(playerWeight, playerCharge, checkpointNumber, SceneManager.GetActiveScene().name);
        bf.Serialize(file, save);
        file.Close();
        DataPackage.NewGame = false;
    }
}

[System.Serializable]
public class SaveData
{
    public string level;
    public float weight;
    public int charge;
    public int checkpoint;

    public SaveData(float weight, int charge, int checkpoint, string level)
    {
        this.weight = weight;
        this.charge = charge;
        this.checkpoint = checkpoint;
        this.level = level;
    }
}