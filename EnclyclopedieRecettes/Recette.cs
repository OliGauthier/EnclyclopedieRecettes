using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnclyclopedieRecettes
{
    class Recette
    {
        private string nomRecette;
        public string NomRecette
        {
            get { return nomRecette; }
            set { nomRecette = value; }
        }

        private List<Tuple<string, int, int>> ingredients; // Tuple<nom de l'ingredient, quantité en grammes, quantités en ml>
        public List<Tuple<string, int, int>> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        private List<string> etapes;
        public List<string> Etapes
        {
            get { return etapes; }
            set { etapes = value; }
        }

        private List<string> categories;
        public List<string> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public Recette(string nom, List<Tuple<string, int, int>> ingredients, List<string> etapes, List<string> categories)
        {
            this.nomRecette = nom;
            this.ingredients = ingredients;
            this.etapes = etapes;
            this.categories = categories;
        }

        public void ajouterIngredient(Tuple<string, int, int> ingredient)
        {
            bool existant = false;
            foreach (var item in this.ingredients)
            {
                if (item.Item1 == ingredient.Item1)
                    existant = true;
            }
            if (!existant)
                this.ingredients.Add(ingredient);
            else
                Console.WriteLine("Cet ingrédient existe déjà.");
        }

        public void retirerIngredient(string ingredient)
        {
            this.ingredients.RemoveAll(item => item.Item1 == ingredient);
        }

        public void ajouterCategorie(string categorie)
        {
            if (!this.categories.Contains(categorie))
                this.categories.Add(categorie);
            else
                Console.WriteLine("Cette catégorie existe déjà.");
        }

        public void retirerCategorie(string categorie)
        {
            if (this.categories.Contains(categorie))
                this.categories.Remove(categorie);
        }

        public void ajouterEtape(string etape, int numeroEtape)
        {
            if (numeroEtape > this.etapes.Count + 1)
                this.etapes.Add(etape);
            else//on veut placer l'étape quelque part en particulier
            {
                this.etapes.Insert(numeroEtape - 1, etape);
            }
        }

        public void retirerEtape(int numeroEtape)
        {
            if (this.etapes.Count >= numeroEtape)
                this.etapes.RemoveAt(numeroEtape - 1);
            else
                Console.WriteLine($"Il n'y a pas d'étape {numeroEtape} dans cette recette.");
        }

    }
}
