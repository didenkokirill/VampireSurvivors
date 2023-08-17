using TMPro;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private TMP_Text debug1, debug2;

    private void AddText(string text)
    {
        debug1.text = null; debug2.text = null;
        bool debug1Busy = false; bool debug2Busy = false;

        if (!debug1Busy)
        {
            debug1.text = text;
        }
        else if (!debug2Busy)
        {

            debug2.text = text;
        }
    }
}
