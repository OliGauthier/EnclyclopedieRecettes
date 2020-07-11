using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EnclyclopedieRecettes
{
    public class Formulaire : Form
    {
        public Button button1;
        public TextBox boxNomRecette;
        public Label labelNomRecette;
        public Label labelIngredients;
        public List<TextBox> listeIngredients;
        public Button buttonAjoutIngredient;
        public Formulaire()
        {
            this.SuspendLayout();

            listeIngredients = new List<TextBox>();

            this.Name = "Recettes entrées manuellement";
            this.ClientSize = new Size(400, 600);
            this.Load += new System.EventHandler(this.Formulaire_Load);

            labelNomRecette = new Label();
            labelNomRecette.Text = "Nom de la recette";
            labelNomRecette.Location = new Point(20, 100);
            this.Controls.Add(labelNomRecette);

            boxNomRecette = new TextBox();
            boxNomRecette.Size = new Size(200, 50);
            boxNomRecette.Location = new Point(180, 100);
            boxNomRecette.Text = "Nom de la recette";
            this.Controls.Add(boxNomRecette);

            labelIngredients = new Label();
            labelIngredients.Text = "Ingrédients";
            labelIngredients.Location = new Point(20, 150);
            this.Controls.Add(labelIngredients);


            listeIngredients.Add(new TextBox());
            listeIngredients.Add(new TextBox());
            listeIngredients.Add(new TextBox());
            

            for (int i = 0; i < listeIngredients.Count; i++)
            {
                listeIngredients[i].Size = new Size(200, 50);
                listeIngredients[i].Location = new Point(180, 150 + 30 * i);
                listeIngredients[i].Text = $"Ingrédient {i+1}";
                this.Controls.Add(listeIngredients[i]);
            }

            buttonAjoutIngredient = new Button();
            buttonAjoutIngredient.Size = new Size(150, 30);
            buttonAjoutIngredient.Location = new Point(20, 180);
            buttonAjoutIngredient.Text = "Ajouter un ingrédient";
            this.Controls.Add(buttonAjoutIngredient);
            buttonAjoutIngredient.Click += new EventHandler(buttonAjoutIngredient_Click);

            button1 = new Button();
            button1.Size = new Size(40, 40);
            button1.Location = new Point(180, 500);
            button1.Text = "OK";
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
            this.ResumeLayout(false);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Henlo");
            listeIngredients[1].Text = "test";
        }

        private void buttonAjoutIngredient_Click(object sender, System.EventArgs e)
        {
            
            Console.WriteLine("hola");
            TextBox box = new TextBox();
            box.Size = new Size(200, 50);
            box.Location = new Point(180, 150 + 30 * listeIngredients.Count);
            box.Text = $"Ingrédient {listeIngredients.Count}";
            listeIngredients.Add(box);
            
        }

        

        private void Formulaire_Load(object sender, EventArgs e)
        {

        }
    }
}
