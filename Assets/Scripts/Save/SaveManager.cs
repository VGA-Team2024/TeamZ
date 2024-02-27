using UnityEngine;
using System.IO;

/// <summary>
/// 他クラスのinstanceに対して行う。
/// </summary>
public class SaveManager : MonoBehaviour
{
    private static string _goldSaveFileName = "gold_data.json";
    private static string _bossSaveFileName = "boss_data.json";
    /// <summary>
    /// GoldManagerをセーブ
    /// </summary>
    /// <param name="goldManager"></param>
    public static void SaveGoldData(GoldManager goldManager)
    {
        var jsonData = JsonUtility.ToJson(goldManager);
        // ファイルパスの生成
        var filepath = Path.Combine(Application.persistentDataPath, _goldSaveFileName);
        File.WriteAllText(filepath, jsonData);
    }

    /// <summary>
    /// GoldManagerをLoad
    /// </summary>
    /// <param name="goldManager"></param>
    public static void LoadGoldData(GoldManager goldManager)
    {
        //ファイルパスの生成
        var filePath = Path.Combine(Application.persistentDataPath, _goldSaveFileName);

        //ファイルの確認
        if (File.Exists(filePath))
        {
            //テキストを読み込み
            var jsonData = File.ReadAllText(filePath);

            // JSONデータをGoldManagerクラスにデシリアライズ
            JsonUtility.FromJsonOverwrite(jsonData, goldManager);
        }
    }

    /// <summary>
    /// BossをSave
    /// </summary>
    /// <param name="boss"></param>
    public static void SaveBossData(Boss boss)
    {
        var jsonData = JsonUtility.ToJson(boss);
        var filepath = Path.Combine(Application.persistentDataPath, _bossSaveFileName);
        File.WriteAllText(filepath, jsonData);
    }

    /// <summary>
    /// BossをLoad
    /// </summary>
    /// <param name="boss"></param>
    public static void LoadBossData(Boss boss)
    {
        var filePath = Path.Combine(Application.persistentDataPath, _bossSaveFileName);
        if (File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(jsonData, boss);
        }
    }
}