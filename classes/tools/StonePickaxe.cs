using System;

namespace MinecraftInventoryTracker{
    class StonePickaxe: Block, Crafted{
        private Recipe recipe;
        public StonePickaxe(int newCount): base(newCount){
            blockType = "Stone Pickaxe";
            classType = this;
            image = "stone-pickaxe.png";
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