using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class Invoker : MonoBehaviour
    {
        public bool _isRecording;
        public bool _isReplaying;
        public float _replayTime;
        public float _recordingTime;
        public bool Replayed;
        private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command)
        {
            command.Execute();
            if (_isRecording)
            {
                _recordedCommands.Add(_recordingTime, command);
            }
            //Debug.Log("Recorded Time: " + _recordingTime);
            //Debug.Log("Recorded Command: " + command);
        }
        public void Record()
        {
            _recordingTime = 0.0f;
            _isRecording = true;
        }

        public void Replay()
        {
            _replayTime = 0.0f;
            _isReplaying = true;

            if (_recordedCommands.Count <= 0)
            {
                //Debug.LogError("No commands to replay!");
            }

        }

        void FixedUpdate()
        {
            Data.instance.isRecording = _isRecording;
            Data.instance.isReplaying = _isReplaying;
            if (_isRecording)
                _recordingTime += Time.fixedDeltaTime;

            if (_isReplaying)
            {
                _replayTime += Time.fixedDeltaTime;

                if (_recordedCommands.Count != 0)
                {
                    if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                    {
                        _recordedCommands.Values[0].Execute();
                        //Debug.Log("Replay Time: " + _replayTime);
                        //Debug.Log("Replay Command: " + _recordedCommands.Values[0]);
                        _recordedCommands.RemoveAt(0);
                       
                    }
                   
                }
                else
                {
                    _isReplaying = false;
                }
            }
        }
    }
}
