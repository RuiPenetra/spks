using System;
using System.Collections.Generic;

namespace SPKS___Server
{
    class GestorDeClientes
    {
        private static Dictionary<string, int> clientDictionary;



        public static void Constructor()
        {
            clientDictionary = new Dictionary<string, int>();
        }



        public static void addEntry_clientDictionary(string key)
        {
            if (clientDictionary.ContainsKey(key))
            {
                if (clientDictionary[key] < 2)
                {
                    clientDictionary[key] += 1;
                }
            }
            else
            {
                clientDictionary.Add(key, 1);
            }
        }



        public static void removeEntry_clientDictionary(string key)
        {
            clientDictionary[key] -= 1;
        }



        public static Boolean roomAvailability(string key)
        {
            try
            {
                if (clientDictionary[key] >= 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (KeyNotFoundException)
            {
                clientDictionary.Add(key, 0);
                return true;
            }
        }

    }
}
