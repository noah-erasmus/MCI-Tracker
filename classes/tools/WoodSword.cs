using System;

namespace MinecraftInventoryTracker{
    class WoodSword: Block, Crafted{
        private Recipe recipe;
        public WoodSword(int newCount): base(newCount){
            blockType = "Wood Sword";
            classType = this;
            image = "wood-sword.png";
            hardness = "59";
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