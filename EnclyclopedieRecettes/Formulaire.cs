using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace EnclyclopedieRecettes
{
    public class Formulaire : Form
    {
        public Button button1;
        public TextBox boxNomRecette;
        public TextBox boxTempsCuisson;
        public TextBox boxTempsPreparation;
        public TextBox boxPhoto;
        public Label labelNomRecette;
        public Label labelTempsCuisson;
        public Label labelTempsPreparation;
        public Label labelMinutes1;
        public Label labelMinutes2;
        public Label labelIngredients;
        public Label labelEtapes;
        public List<TextBox> listeIngredients;
        public List<TextBox> listeQuantites;
        public List<ComboBox> listeUniteDeQuantite;
        public List<TextBox> listeEtapes;
        public Button buttonAjoutIngredient;
        public Button buttonAjoutEtape;
        public Button buttonAjoutPhoto;
        public TextBox pathPhoto;

        public string[] unitesDeMesure = new string[] { "kg", "lbs", "ml", "tasse", "tbsp", "tsp" };
        public Formulaire()
        {
            this.SuspendLayout();

            listeIngredients = new List<TextBox>();
            listeEtapes = new List<TextBox>();
            listeQuantites = new List<TextBox>();
            listeUniteDeQuantite = new List<ComboBox>();

            this.Name = "Recettes entrées manuellement";
            this.ClientSize = new Size(1000, 400);
            this.Load += new System.EventHandler(this.Formulaire_Load);
            this.Text = "Recette entrée manuellement";

            #region nom recette
            labelNomRecette = new Label();
            labelNomRecette.Text = "Nom de la recette";
            labelNomRecette.Location = new Point(20, 20);
            this.Controls.Add(labelNomRecette);

            boxNomRecette = new TextBox();
            boxNomRecette.Size = new Size(200, 50);
            boxNomRecette.Location = new Point(180, 20);
            boxNomRecette.Text = "Nom de la recette";
            this.Controls.Add(boxNomRecette);
            #endregion

            #region photo
            buttonAjoutPhoto = new Button();
            buttonAjoutPhoto.Size = new Size(150, 30);
            buttonAjoutPhoto.Location = new Point(520, 20);
            buttonAjoutPhoto.Text = "Ajouter une photo";
            this.Controls.Add(buttonAjoutPhoto);
            buttonAjoutPhoto.Click += new EventHandler(buttonAjoutPhoto_Click);

            boxPhoto = new TextBox();
            boxPhoto.Size= new Size(150, 50);
            boxPhoto.Location = new Point(680, 20);
            boxPhoto.Text = "Path photo";
            this.Controls.Add(boxPhoto);
            #endregion

            #region temps

            labelTempsPreparation = new Label();
            labelTempsPreparation.Size = new Size(140, 20);
            labelTempsPreparation.Text = "Temps de preparation";
            labelTempsPreparation.Location = new Point(20, 65);
            this.Controls.Add(labelTempsPreparation);

            boxTempsPreparation = new TextBox();
            boxTempsPreparation.Size = new Size(50, 50);
            boxTempsPreparation.Location = new Point(180, 65);
            this.Controls.Add(boxTempsPreparation);

            labelMinutes1 = new Label();
            labelMinutes1.Location = new Point(240, 65);
            labelMinutes1.Text = "min";
            this.Controls.Add(labelMinutes1);

            labelTempsCuisson = new Label();
            labelTempsCuisson.Text = "Temps de cuisson";
            labelTempsCuisson.Location = new Point(520, 65);
            this.Controls.Add(labelTempsCuisson);

            boxTempsCuisson = new TextBox();
            boxTempsCuisson.Size = new Size(50, 50);
            boxTempsCuisson.Location = new Point(680, 65);
            this.Controls.Add(boxTempsCuisson);

            labelMinutes2 = new Label();
            labelMinutes2.Location = new Point(740, 65);
            labelMinutes2.Text = "min";
            this.Controls.Add(labelMinutes2);
            #endregion


            #region ingredients
            labelIngredients = new Label();
            labelIngredients.Text = "Ingrédients";
            labelIngredients.Location = new Point(20, 110);
            this.Controls.Add(labelIngredients);

            for (int i = 0; i < 3; i++)
            {
                listeIngredients.Add(new TextBox());
                listeIngredients[i].Size = new Size(140, 50);
                listeIngredients[i].Location = new Point(180, 110 + 30 * i);
                listeIngredients[i].Text = $"Ingrédient {i+1}";
                this.Controls.Add(listeIngredients[i]);

                listeQuantites.Add(new TextBox());
                listeQuantites[i].Size = new Size(50, 50);
                listeQuantites[i].Location = new Point(330, 110 + 30 * i);
                listeQuantites[i].Text = "Quantité";
                this.Controls.Add(listeQuantites[i]);

                listeUniteDeQuantite.Add(new ComboBox());
                listeUniteDeQuantite[i].Size = new Size(50, 50);
                listeUniteDeQuantite[i].Location = new Point(390, 110 + 30 * i);
                listeUniteDeQuantite[i].Items.AddRange(unitesDeMesure);
                listeUniteDeQuantite[i].DropDownStyle = ComboBoxStyle.DropDownList;
                this.Controls.Add(listeUniteDeQuantite[i]);
            }

            buttonAjoutIngredient = new Button();
            buttonAjoutIngredient.Size = new Size(150, 30);
            buttonAjoutIngredient.Location = new Point(20, 140);
            buttonAjoutIngredient.Text = "Ajouter un ingrédient";
            this.Controls.Add(buttonAjoutIngredient);
            buttonAjoutIngredient.Click += new EventHandler(buttonAjoutIngredient_Click);
            #endregion
            #region etapes
            labelEtapes = new Label();
            labelEtapes.Text = "Étapes";
            labelEtapes.Location = new Point(520, 110);
            this.Controls.Add(labelEtapes);

            listeEtapes.Add(new TextBox());
            listeEtapes.Add(new TextBox());
            listeEtapes.Add(new TextBox());

            for (int i = 0; i < listeEtapes.Count; i++)
            {
                listeEtapes[i].Size = new Size(200, 50);
                listeEtapes[i].Location = new Point(680, 110 + 30 * i);
                listeEtapes[i].Text = $"Étape {i + 1}";
                this.Controls.Add(listeEtapes[i]);
            }

            buttonAjoutEtape = new Button();
            buttonAjoutEtape.Size = new Size(150, 30);
            buttonAjoutEtape.Location = new Point(520, 140);
            buttonAjoutEtape.Text = "Ajouter une étape";
            this.Controls.Add(buttonAjoutEtape);
            buttonAjoutEtape.Click += new EventHandler(buttonAjoutEtape_Click);
            #endregion 


            button1 = new Button();
            button1.Size = new Size(40, 40);
            button1.Location = new Point(480, 300);
            button1.Text = "OK";
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
            this.ResumeLayout(false);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Henlo");
        }

        private void buttonAjoutIngredient_Click(object sender, System.EventArgs e)
        {
            listeIngredients.Add(new TextBox());
            listeIngredients[listeIngredients.Count-1].Size = new Size(150, 50);
            listeIngredients[listeIngredients.Count-1].Location = new Point(180, 110 + 30 * (listeIngredients.Count-1));
            listeIngredients[listeIngredients.Count-1].Text = $"Ingrédient {listeIngredients.Count}";
            this.Controls.Add(listeIngredients[listeIngredients.Count-1]);

            listeQuantites.Add(new TextBox());
            listeQuantites[listeQuantites.Count - 1].Size = new Size(50, 50);
            listeQuantites[listeQuantites.Count - 1].Location = new Point(330, 110 + 30 * (listeQuantites.Count-1));
            listeQuantites[listeQuantites.Count - 1].Text = "Quantité";
            this.Controls.Add(listeQuantites[listeQuantites.Count-1]);

            listeUniteDeQuantite.Add(new ComboBox());
            listeUniteDeQuantite[listeUniteDeQuantite.Count - 1].Size = new Size(50, 50);
            listeUniteDeQuantite[listeUniteDeQuantite.Count - 1].Location = new Point(390, 110 + 30 * (listeUniteDeQuantite.Count-1));
            listeUniteDeQuantite[listeUniteDeQuantite.Count - 1].Items.AddRange(unitesDeMesure);
            listeUniteDeQuantite[listeUniteDeQuantite.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(listeUniteDeQuantite[listeUniteDeQuantite.Count-1]);
        }

        private void buttonAjoutEtape_Click(object sender, System.EventArgs e)
        {
            listeEtapes.Add(new TextBox());
            listeEtapes[listeEtapes.Count - 1].Size = new Size(200, 50);
            listeEtapes[listeEtapes.Count - 1].Location = new Point(680, 110 + 30 * (listeEtapes.Count - 1));
            listeEtapes[listeEtapes.Count - 1].Text = $"Étape {listeEtapes.Count}";
            this.Controls.Add(listeEtapes[listeEtapes.Count - 1]);
        }

        private void buttonAjoutPhoto_Click(object sender, System.EventArgs e)
        {
            string path = getFileName("Sélectionnez la photo à importer","Fichier PNG (*.png)|*.png","C:\\");//rajouter plus de types de fichiers
            boxPhoto.Text = path;
        }

        private void Formulaire_Load(object sender, EventArgs e)
        {
            this.Refresh();
            Application.DoEvents();
        }

        static private string getFileName(string titre, string filtre, string path)
        {
            string selectedFile = "";
            OpenFileDialog file = new OpenFileDialog();
            Form form = new Form();
            form.TopMost = true;
            file.Title = titre;
            file.InitialDirectory = path;
            file.Filter = filtre;
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            if (file.ShowDialog(form) == DialogResult.OK)
            {
                selectedFile = file.FileName;
            }

            return selectedFile;
        }
    }

   
}
