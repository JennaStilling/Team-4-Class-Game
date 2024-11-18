using UnityEngine;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;

namespace Player_Potion_Making
{
    public class WorkbenchInventory : MonoBehaviour
    {
        public Dictionary<int, Ingredient> workbenchInventory;
        private int _numberOfSlots = 8;
        private int _takenSlots;
        private int _slotOneQuantity = 0;
        private int _slotTwoQuantity = 0;
        private int _slotThreeQuantity = 0;
        private int _slotFourQuantity = 0;
        private int _slotFiveQuantity = 0;
        private int _slotSixQuantity = 0;
        private int _slotSevenQuantity = 0;
        private int _slotEightQuantity = 0;

        public WorkbenchInventory()
        {
            workbenchInventory = new Dictionary<int, Ingredient>();
        }

        public void AddToInventory(Ingredient ingredient)
        {
            if (_takenSlots >= _numberOfSlots)
            {
                Debug.Log("Max slots reached - cannot add more");
            }
            else
            {
                
            }
        }

        public void AddToSlot(int slotNum)
        {
            switch (slotNum)
            {
                case 1:
                    _slotOneQuantity++;
                    break;
                case 2:
                    _slotTwoQuantity++;
                    break;
                case 3:
                    _slotThreeQuantity++;
                    break;
                case 4:
                    _slotFourQuantity++;
                    break;
                case 5:
                    _slotFiveQuantity++;
                    break;
                case 6:
                    _slotSixQuantity++;
                    break;
                case 7:
                    _slotSevenQuantity++;
                    break;
                case 8:
                    _slotEightQuantity++;
                    break;
                default:
                    Debug.LogError("Slot number did not match any available slots");
                    break;
            }
        } 
        
        public void RemoveFromSlot(int slotNum)
        {
            switch (slotNum)
            {
                case 1:
                    _slotOneQuantity--;
                    break;
                case 2:
                    _slotTwoQuantity--;
                    break;
                case 3:
                    _slotThreeQuantity--;
                    break;
                case 4:
                    _slotFourQuantity--;
                    break;
                case 5:
                    _slotFiveQuantity--;
                    break;
                case 6:
                    _slotSixQuantity--;
                    break;
                case 7:
                    _slotSevenQuantity--;
                    break;
                case 8:
                    _slotEightQuantity--;
                    break;
                default:
                    Debug.LogError("Slot number did not match any available slots");
                    break;
            }
        } 
        
        private bool CheckIfIdTaken(int id)
        {
            foreach (var inventoryItem in workbenchInventory)
            {
                if (inventoryItem.Key.Equals(id))
                    return true;
            }

            return false;
        }
    }
}