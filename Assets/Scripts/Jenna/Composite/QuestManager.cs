using System;
using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class QuestManager : MonoBehaviour
    {
        private List<IQuest> _questList;
        private CompositeQuest _largeQuest;
        private void Start()
        {
            _questList = new List<IQuest>();
            _questList.Add(new Quest("Name 1", "Description 1"));
            _questList.Add(new Quest("Name 2", "Description 2"));

            foreach (Quest quest in _questList)
            {
                Debug.Log(quest.ToString());
            }
            
            // Manually adding complex quest

            _largeQuest = new CompositeQuest("Assault the Fortress", "Assault Adament Fortress");
            _largeQuest.AddSubquest(new Quest("Travel to the Western Approach", "Use the map to travel to the Western Approach in Orlais"));
            _largeQuest.AddSubquest(new Quest("Speak to your troops", "Speak to Commander Cullen in the forward advance camp"));

            Debug.Log("Large quest: " + _largeQuest.GetName() + ", " + _largeQuest.GetDescription() );
            
            foreach (IQuest subQuest in _largeQuest.GetSubQuests())
            {
                Debug.Log(subQuest.ToString());
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                foreach (Quest quest in _questList)
                {
                    quest.CompleteQuest();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _largeQuest.CompleteQuest();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                foreach (IQuest subQuest in _largeQuest.GetSubQuests())
                {
                    subQuest.CompleteQuest();
                }
            }
            
        }
    }
}