using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTimer : MonoBehaviour
{
    public double time = 60*60;
    float sliderValue;
    bool isStop = true;
    bool isSongPlaying;
    public int miniFontSize = 18;
    public AudioSource song;
    public UnityEngine.UI.Text timeValueText;
    public UnityEngine.UI.Text buttonText;
    public UnityEngine.UI.Text passedTimeText;
    public UnityEngine.UI.Image circleValueImage;
    public UnityEngine.UI.Slider timeValueSlider;

    float passedTime;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTime(time);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStop){
            time -= Time.deltaTime;
            passedTime += Time.deltaTime;
            int hour = (int)(passedTime / 3600);
            int min = (int)(passedTime / 60 % 60);
            passedTimeText.text = hour+"<size=15>"+min+"</size>";

            // if time got 0sec
            if(time < 0){
                time = 0;
                // Stop first
                OnPressButton();
                // Ball
                MakeSound(true);
            }
            ChangeTime(time);
            
        }
        
    }

    void MakeSound(bool isStart){
        if(isStart){
            buttonText.text = "StopSong!!!! Fuck";
            isSongPlaying = true;
            song.Play();
        }
        else{
            buttonText.text = "Start";
            isSongPlaying = false;
            song.Stop();
        }
    }

    public void OnPressButton(){
        if(!isSongPlaying){
            isStop = !isStop;
            if(isStop){
            buttonText.text = "Start";
            }
            else
            {
                buttonText.text = "Stop";
            }
        }else{

            // Init to 
            MakeSound(false);
            time = 3600;
            ChangeTime(time);
        }
    }

    public void OnSliderChanged(float t){
        sliderValue = t;
        ChangeTime(t * 60 * 60);
    }


    void ChangeTime(double _time){
        time = _time;
        float t = (float)(time/3600f);
        circleValueImage.fillAmount = 1-t;
        timeValueSlider.value = t;

        int min = (int)(time/60);
        int sec = (int)(time % 60);
        timeValueText.text = min+"<size="+miniFontSize+">"+sec+"</size>";
    }    
}
