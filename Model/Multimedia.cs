﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Multimedia : Document, Imprimable
    {
        public Multimedia() { }

        public Multimedia(string _titre, string _auteur, string _path, bool _hasCopyright)
            : base(_titre, _auteur, _path, _hasCopyright) { type = typeof(Multimedia).Name; }

        public override string Afficher()
        {
            string res = "";
            return res;
        }

        public void Print()
        {

        }
    }
}
