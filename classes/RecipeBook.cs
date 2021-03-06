using System;
using System.Collections;

namespace MinecraftInventoryTracker{
    class RecipeBook{
        private static ArrayList recipes = new ArrayList();

        public static void Populate(){

            ArrayList records = Database.ReadRecipes();

            foreach(Tuple<string, string[,]> curTuple in records){
                Console.WriteLine(curTuple.Item1);
                Recipe curRecipe = new Recipe((Crafted)Inventory.GetClass(curTuple.Item1), new Block[3,3]
                {{Inventory.GetClass(curTuple.Item2[0,0]), Inventory.GetClass(curTuple.Item2[0,1]), Inventory.GetClass(curTuple.Item2[0,2])},
                {Inventory.GetClass(curTuple.Item2[1,0]),Inventory.GetClass(curTuple.Item2[1,1]),Inventory.GetClass(curTuple.Item2[1,2])},
                {Inventory.GetClass(curTuple.Item2[2,0]),Inventory.GetClass(curTuple.Item2[2,1]),Inventory.GetClass(curTuple.Item2[2,2])}});
                recipes.Add(curRecipe);
            }

        }

        public static ArrayList Recipes{
            get{
                return recipes;
            }
        }

        public static void AddRecipe(Recipe recipe){
            string blockType = recipe.Result.BlockType;

            bool newRecipe = true;
            for (int i = 0; i < recipes.Count; i++)
            {
                Recipe curRecipe = (Recipe)recipes[i];
                if (curRecipe.Result.BlockType == blockType){
                    newRecipe = false;
                }

                if(newRecipe == true){
                    recipes.Add(curRecipe);
                    Database.AddRecipe(recipe);
                }
            }
        }

        public static void ApplyRecipe(string blockType){
            Recipe selectedRecipe = null;
            foreach(Recipe curRecipe in recipes){
                if(curRecipe.Result.BlockType == blockType){
                    selectedRecipe = curRecipe;
                }
            }
            if(selectedRecipe.IsViable()){
                selectedRecipe.Result.Count++;
                foreach(Block curInput in selectedRecipe.Inputs){
                    if(curInput != null){
                        curInput.Count--;
                    }
                }
            }
        }

        // public static void CheckViable(){
        //     Recipe selectedRecipe = null;
        //     foreach(Recipe curRecipe in recipes){
                
        //     }
        // }
    }
}