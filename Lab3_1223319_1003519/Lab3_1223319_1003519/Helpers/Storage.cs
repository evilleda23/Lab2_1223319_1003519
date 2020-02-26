using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab3_1223319_1003519.Models;

namespace Lab3_1223319_1003519.Helpers
{
    public class Storage
    {
        private static Storage _instance;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public List<Farmaco> Indice = new List<Farmaco>();
    }
}