using System;

namespace MinecraftInventoryTracker{
    class StoneAxe: Block, Crafted{
        private Recipe recipe;
        public StoneAxe(int newCount): base(newCount){
            blockType = "Stone Axe";
            classType = this;
            image = "stone-axe.png";
            hardness = "131";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Wood sword has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}