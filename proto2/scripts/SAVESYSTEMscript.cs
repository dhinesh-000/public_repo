using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SAVESYSTEMscript : MonoBehaviour
{
  public static SAVESYSTEMscript instance;
  private string savepath;
  // object i,j;
  // int m;
  // float f;
  void Awake() 
  {
    instance=this;       
  }
  void Start() 
  {
    savepath=Application.persistentDataPath + "/gamedata.save"; 
    ///...DO THIS FOR THE FINAL BUILD
    loadGameData();
    ///...DO THIS FOR THE FINAL BUILD
  }
  public void saveGameData()
  {
      var save= new datatobesaved()
      {
           gamecoin= gamemanager.instance.lumen,
           playerexp= gamemanager.instance.k
      };
      var binaryformatter=new BinaryFormatter();
      using ( var filestream = File.Create(savepath))
      {
        binaryformatter.Serialize(filestream,save);
      }
      Debug.Log("data saved");
  }
  public void loadGameData()
  {
    if(File.Exists(savepath))
    {
      datatobesaved datatobesaved;
      var binaryformatter = new BinaryFormatter();
      using ( var filestream =  File .Open(savepath,FileMode.Open))
      {
          datatobesaved=(datatobesaved) binaryformatter.Deserialize(filestream);
      }
      gamemanager.instance.lumen= datatobesaved.gamecoin;
      gamemanager.instance.k= datatobesaved.playerexp;
      Debug.Log("data loaded");
    }
  }
}
[System.Serializable]
public class datatobesaved
{
    public  int gamecoin;
    public  float playerexp;

    // public datatobesaved(int gamecoin, float playerexp)
    // {
    //     gamecoin = gamemanager.instance.lumen;
    //     playerexp = gamemanager.instance.k;
    // }
}
