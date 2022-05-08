using UnityEngine;

namespace Cave.Common
{
    public class SaveDataManager
    {
        public void SetMaxScore(string scoreKey, int value)
        {
            PlayerPrefs.SetInt(scoreKey, value);
        }
        public int GetMaxScore(string scoreKey)
        {
            return PlayerPrefs.GetInt(scoreKey);
        }
    }
}