using System;

namespace MinecraftInventoryTracker{
    class WoodPickaxe: Block, Crafted{
        private Recipe recipe;
        public WoodPickaxe(int newCount): base(newCount){
            blockType = "Wood Pickaxe";
            classType = this;
            image = "wood-pickaxe.png";
            hardness = "59";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("WoodPickaxe has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}