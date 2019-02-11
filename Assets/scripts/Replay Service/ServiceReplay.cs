using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Replay_Service
{
    public class ServiceReplay : NonMonoSingleton<ServiceReplay>
    {
        public Dictionary<PlayerNumber,Vector3> playerPosition=new Dictionary<PlayerNumber, Vector3>();
        Dictionary<Controls, List<InputData>> inputRecord = new Dictionary<Controls, List<InputData>>();
        public void RecordInput(InputData inputData, Controls controls)
        {
            if (inputData.direction != 0 || inputData.forward != 0 || inputData.boost || inputData.shoot)
            {
                if (inputRecord.ContainsKey(controls))
                {
                    inputRecord[controls].Add(inputData);
                }
                else
                {
                    List<InputData> inputq = new List<InputData>();
                    inputq.Add(inputData);
                    inputRecord.Add(controls, inputq);
                }
            }
        }
        public void SetPosition(PlayerNumber playerNumber, Vector3 position){
            playerPosition.Add(playerNumber,position);
        }
        public void SetQueue(){
            //Debug.Log("Last frame number Peek"+inputRecord[Controls.WASD].Peek().frame);
           // Debug.Log("Last frame number Dequeue"+inputRecord[Controls.WASD].Dequeue().frame);
            InputManager.Instance.SetQueue(inputRecord);
            
        }

    }
}