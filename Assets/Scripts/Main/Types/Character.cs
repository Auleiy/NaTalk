using UnityEngine;

namespace NPT.Main.Types
{
    public class Character
    {
        public Sprite Portrait;
        public string Name;

        public Character(Sprite portrait, string name)
        {
            Portrait = portrait;
            Name = name;
        }
    }
}
