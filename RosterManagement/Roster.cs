using System;
using System.Linq;
using System.Collections.Generic;

namespace RosterManagement
{
    public class CodeSchool
    {
        Dictionary<int, List<string>> _roster;

        public CodeSchool()
        {
            _roster = new Dictionary<int, List<String>>();
        }
        
        /// <summary>
        /// Should be able to Add Student to a Particular Wave
        /// </summary>
        /// <param name="cadet">Refers to the name of the Cadet</param>
        /// <param name="wave">Refers to the Wave number</param>
        public void Add(string cadet, int wave)
        {
            // Check if our roster contains an entry for this wave
            // create one if it doesn't exist and add 
            if(!_roster.ContainsKey(wave)){
                _roster.Add(wave,new List<string>());
            }
            _roster[wave].Add(cadet);
        }

        /// <summary>
        /// Returns all the Cadets in a given wave
        /// </summary>
        /// <param name="wave">Refers to the wave number from where cadet list is to be fetched</param>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Grade(int wave)
        {
            List<string> list = new List<string>();
            // if we don't contain an reference to the passed wave 
            // then we return an empty list
            if(_roster.ContainsKey(wave)){
                list = _roster[wave];
            }
            list.Sort();
            return list;
        }

        /// <summary>
        /// Return all the cadets in the CodeSchool
        /// </summary>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Roster()
        {
            // getting all keys from dictionary and storing them inside 
            // a list. Sort them and then access their contents 
            List<int> waveList = _roster.Keys.ToList();
            waveList.Sort();
            List<string> cadetRoster = new List<string>();
            // add all cadets in a common list alphabetically ordered and then return it
            foreach(int wave in waveList){
                List<string> cadetListInWave = _roster[wave];
                cadetListInWave.Sort();
                foreach(string cadet in cadetListInWave){
                    cadetRoster.Add(cadet);
                }
            }
            return cadetRoster;
        }
    }
}