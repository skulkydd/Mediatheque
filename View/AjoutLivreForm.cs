﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class AjoutLivreForm : Form
    {
        private Ctrl ctrl;

        public AjoutLivreForm(Ctrl _ctrl)
        {
            ctrl = _ctrl;

            InitializeComponent();
        }

        private void parcourirButton_Click(object sender, EventArgs e)
        {
            openLivreFileDialog.ShowDialog();

        }

        private void openLivreFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string file = openLivreFileDialog.FileName;
            cheminTextBox.Text = string.Format("{1}", Path.GetDirectoryName(file), openLivreFileDialog.FileName);
        }

        private void annulerButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validerButton_Click(object sender, EventArgs e)
        {
            if (titreTextBox.Text == "" || auteurTextBox.Text == "" || editeurTextBox.Text == "" || DateTime.Parse(anneeParutionTextBox.Text).ToString() != anneeParutionTextBox.Text || cheminTextBox.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs correctement.");
            }
            else
            {
                Livre l = new Livre(titreTextBox.Text, cheminTextBox.Text, copyrightCheckBox.Checked, DateTime.Parse(anneeParutionTextBox.Text), editeurTextBox.Text);

                ctrl.mediatheque.Ajouter(l);

                this.Close();
            }
        }
    }
}