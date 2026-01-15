
using UnityEngine;

[CreateAssetMenu(fileName="BuffsSO", menuName="ScriptableObjects/BuffsSO")]
public class BuffsSO : ScriptableObject
{
        [SerializeField] string _buffName;
        [SerializeField] bool _isBuff; 
        [SerializeField] int _hpBuff;
        [SerializeField] int _atkBuff;
        [SerializeField] int _defBuff;
        
        public string BuffName 
        {
                get { return _buffName; }
                private set { _buffName = value; }
        }
        public bool IsBuff
        {
                get { return _isBuff; }
                private set { _isBuff = value; }
        }
        
        public int HPBuff
        {
                get { return _hpBuff; }
                private set { _hpBuff = value; }
        }

        public int ATKBuff
        {
                get { return _atkBuff; }
                private set { _atkBuff = value; }
        }

        public int DEFBuff
        {
                get { return _defBuff; }
                private set { _defBuff = value; }
        }
        
  

        

}
