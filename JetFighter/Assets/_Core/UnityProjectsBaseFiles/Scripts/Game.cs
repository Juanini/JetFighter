using System;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    private static bool isInputBlocked = false;
    public static bool IsOnline { get; set; }
    public static bool IsInputBlocked => isInputBlocked;

    public static void BlockInput()
    {
        Trace.Log("GAME - BLOCK INPUT");
        isInputBlocked = true;
        // GameEventManager.TriggerEvent(GameEvents.BLOCK_INPUT);
    }
    
    public static void ReleaseInput()
    {
        Trace.Log("GAME - RELEASE INPUT");
        isInputBlocked = false;
        // GameEventManager.TriggerEvent(GameEvents.RELEASE_INPUT);
    }

    public static string GetDateAndTime()
    {
        DateTime now = DateTime.Now;
        return now.ToString("yyyy-MM-dd HH:mm:ss");
    }
    
    public static bool IsValidDate(string _date)
    {
        DateTime fecha;
        string format = "yyyy-MM-dd HH:mm:ss";
        CultureInfo culture = CultureInfo.InvariantCulture;
        bool isValidDate = DateTime.TryParseExact(_date, format, culture, DateTimeStyles.None, out fecha);
        return isValidDate;
    }

    public static double GetSecondsDifference(string _date)
    {
        DateTime date1 = DateTime.Parse(_date);
        DateTime date2 = DateTime.Parse(GetDateAndTime());
        
        TimeSpan difference = date2.Subtract(date1);
        return difference.TotalSeconds;
    }

    public static T GetRandomElementFromArray<T>(T[] array)
    {
        if (array.Length == 0)
        {
            Trace.Log("Empty Array");
            return default(T);
        }

        int randomIndex = Random.Range(0, array.Length);
        return array[randomIndex];
    }
    
    public static string IntToStringWithCommas(int num)
    {
        return $"{num:N0}";
    }

}