using System;
using System.Collections;

namespace MinecraftInventoryTracker{
    class RecipeBook{
        private static ArrayList recipes = new ArrayList();

        public static void Populate(){
            Recipe planksRecipe = new Recipe((Crafted)Planks.Get(), new Block[2,2]
            {{Inventory.GetClass("Wood block"), null},{Inventory.GetClass("Wood block"), null}});
            recipes.Add(planksRecipe);
        }

        public static ArrayList Recipes{
            get{
                return recipes;
            }
        }
    }
}