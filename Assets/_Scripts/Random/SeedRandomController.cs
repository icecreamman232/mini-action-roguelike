using UnityEngine;

namespace SGGames.Scripts.Random
{
    public enum RandomCategory
    {
        WEAPON,
        ITEM,
        ENEMY,
        COUNT,
    }
    
    public static class SeedRandomController
    {
        private static int m_seed;
        private static System.Random[] m_randomSet;
        
        public static int GetSeed()
        {
            return m_seed;
        }
        
        public static void SetSeed(int seed)
        {
            m_seed = seed;
            Debug.Log("Set Seed: " + m_seed);
            InitRandom();
        }

        public static int GetRandomInt(RandomCategory category, int min, int max)
        {
            return m_randomSet[(int)category].Next(min, max);
        }

        public static float GetRandomFloat(RandomCategory category, float min, float max)
        {
            return (float)(m_randomSet[(int)category].NextDouble() * (max - min) + min);
        }

        private static void InitRandom()
        {
            m_randomSet = new System.Random[(int)RandomCategory.COUNT];
            for (int i = 0; i < m_randomSet.Length; i++)
            {
                m_randomSet[i] = new System.Random(m_seed);
            }
        }
    }
}
