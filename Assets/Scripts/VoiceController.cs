using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;
public class VoiceController : MonoBehaviour
{

    const string LANG_CODE = "en-US";

    [SerializeField]
    Text uiText;
    void Start()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = onPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

        CheckPermission();
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif

    }

    #region Speech to Text

    public void StartListening(){
        SpeechToText.instance.StartRecording();
    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }
    void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
    }
    void onPartialSpeechResult(string result)
    {
        uiText.text = result;
    }
    #endregion
    void Setup(string code)
    {
        //TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }

}
