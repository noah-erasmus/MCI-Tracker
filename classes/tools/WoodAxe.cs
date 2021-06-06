using System;

namespace MinecraftInventoryTracker{
    class WoodAxe: Block, Crafted{
        private Recipe recipe;
        public WoodAxe(int newCount): base(newCount){
            blockType = "Wood Axe";
            classType = this;
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Wood axe has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}