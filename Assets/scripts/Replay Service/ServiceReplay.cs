using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Replay_Service
{
    public class ServiceReplay
    {
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
                    List<InputData> inputlist = new List<InputData>();
                    inputlist.Add(inputData);
                    inputRecord.Add(controls, inputlist);
                }
            }
        }

    }
}