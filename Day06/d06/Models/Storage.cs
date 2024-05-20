using System;
using System.Threading;

namespace d06.Models
{
    public class Storage
    {
        private int _itemsInStorage;
        public int ItemsInStorage => _itemsInStorage;
        public bool IsEmpty => _itemsInStorage <= 0;
        
        public Storage(int totalItemCount)
        {
            _itemsInStorage = totalItemCount;
        }

        public bool TryTakeItems(int count)
        {
            if (IsEmpty)
                return false;

            for (int i = 0; i < count; i++)
            {
                if (!TryTakeItem())
                    break;
            }

            return true;
        }
        
        private bool TryTakeItem()
        {
            if (_itemsInStorage > 0)
            {
                Interlocked.Decrement(ref _itemsInStorage);
                return true;
            }

            return false;
        }
    }
}