using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CameraPos
{
    public Vector3 position;
    public Quaternion quat;

}

 class CameraReplay
{
    public List<CameraPos> list;
    public int currentFrame;
    public CameraReplay()
    {
        this.currentFrame = 0;
        list = new List<CameraPos>();

    }
    public void add(CameraPos pos)
    {
        this.list.Add(pos);


    }
    public void nextFrame()
    {
        currentFrame++;
    }
    public  CameraPos getCurrentFrameTransform()
    {
        if (currentFrame==0)
            return list[this.currentFrame];
        else if (currentFrame >= this.list.Count - 1)
            return list[this.list.Count - 1];

        return this.list[currentFrame];

    }
    public CameraPos getPrevFrame()
    {
        if (this.currentFrame == 0)
            return this.list[0];
        else if(this.currentFrame>=this.list.Count-1)
            return list[this.list.Count - 1];

        return this.list[currentFrame - 1];

    }

    public bool isLastFrame()
    {
        if (this.currentFrame == this.list.Count - 1)
            return true;
        else return false;
    }
    public void gotoBeginning()
    {
        this.currentFrame = 0;

    }
}
public class ReplyCamera : MonoBehaviour {
    public bool record = false;
    public bool replay = false;
    // Use this for initialization
    public GameObject character;
    public float startingPointForRecording=-40.0f;
    public float endPointForRecording = 42.0f;
    public bool startRecording = false;
    public GameObject cam;
    CameraReplay replayForCamera;
    public GameObject replayCamera;
    public GameObject replayCharacter; 


    float time = 0.0f;
    float timeRecordingInterval = 0.3f;
    float timeReplay = 0.0f;
    float timeReplayInterval = 0.03f;

    void Start() {

        replayForCamera = new CameraReplay();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (record)
        {//when the character start surring 
        if (character.transform.position.z > startingPointForRecording &&
        character.transform.position.z < endPointForRecording)
            startRecording = true;//start recording
        else
            startRecording = false;

            if (startRecording)
            {
                time += Time.deltaTime; 
                if (time > timeRecordingInterval)
                {
                CameraPos pos = new CameraPos();
                pos.position = cam.transform.position;
                pos.quat = cam.transform.rotation;
                this.replayForCamera.add(pos);
                    time = 0.0f;//reset the time  to check again if the 

                }
               


            }
        }


        if (replay)
        {//replay camera 
            CameraPos pos;
            timeReplay += Time.deltaTime;

            if (timeReplay > timeReplayInterval && this.replayForCamera.isLastFrame())//check if its a last frame or not
                pos = this.replayForCamera.getCurrentFrameTransform();
            replayCamera.transform.position = pos.position;
            replayCharacter.SetActive(true);//set the replay camera 
            character.SetActive(false);



            ReplyCamera.transform.rotation = pos.quat;
            ReplyCamera.transform.position = new Vector3(pos.position.x, replayCharacter.transform.y, pos.position.z);
            this.replayForCamera.nextFrame();
            timeReplay = 0.0f;
        }
        else if (timeReplay <= timeReplayInterval && !this.replayForCamera.isLastFrame)

        {
            CameraPos.revPos;
            PrevPos = this.replayForCamera.getPrevFrame();
            camPos = this.replayForCamera.getCurrentFrameTransform();
            CameraPos PrevPos;

            CameraPos camPos;

            CameraPos InterPolatedPos;

            prevPos = this.replayForCamera.getPrevFrame(); camPos = this.replayForCamera.getCurrentFrameTransform();
            Vector3.Lerp(prevPos.position, camPos.position, timeReplay / timeReplayInterval);
            //time replay is always changing therefore timereplay divide by timereplayinterval will give the value so normalized the timrereply and timereplayin




        }

	}
}
