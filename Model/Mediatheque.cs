﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    public class Mediatheque
    {
        [XmlElement(typeof(Video))]
        [XmlElement(typeof(Audio))]
        [XmlElement(typeof(Texte))]
        [XmlElement(typeof(Article))]
        [XmlElement(typeof(Livre))]
        [XmlElement(typeof(Multimedia))]
        public List<Document> documents { get; set; }


        public Mediatheque()
        {
            documents = new List<Document>();
        }
        
        public void Ajouter(Document _doc){
            if(!documents.Contains(_doc))
            {
                documents.Add(_doc); 
                this.Sauvegarder();
            }
            
        }

        public void Supprimer(Document _doc)
        {
            if (documents.Contains(_doc))
            {
                documents.Remove(_doc);
                this.Sauvegarder();
            }
        }

        public List<T> GetDocuments<T>() where T : Document
        {
            return documents.OfType<T>().ToList(); 
        }

        public List<T> GetDocumentsByAuteur<T>() where T : Document
        {
            var res = from doc in GetDocuments<T>()
                      orderby doc.auteur
                      select doc;

            return res.ToList();
        }

        public List<T> GetDocumentsByTitre<T>() where T : Document
        {
            var res = from doc in GetDocuments<T>()
                      orderby doc.titre
                      select doc;

            return res.ToList();
        }

        public void Sauvegarder(string filename = "mediatheque.dat")
        {
            FileStream file = File.Open(filename, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Mediatheque));
            serializer.Serialize(file, this);
            file.Close();
        }

        public static Mediatheque Charger(string filename = "mediatheque.dat")
        {
            if (File.Exists(filename))
            {
                FileStream file = File.Open(filename, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(Mediatheque));
                Mediatheque maMediatheque = (Mediatheque)serializer.Deserialize(file);
                file.Close();
                return maMediatheque;
            }
            else
                return new Mediatheque(); 
        }
    }
}
