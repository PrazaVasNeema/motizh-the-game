using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public interface CollectionItem
    {
        int ChangeItem(int dir);
        void LoadCollectionChoices(int index);
    }

}