using System;

namespace MinecraftInventoryTracker{
    class WoodHoe: Block, Crafted{
        private Recipe recipe;
        public WoodHoe(int newCount): base(newCount){
            blockType = "Wood Hoe";
            classType = this;
            image = "wood-hoe.png";
            hardness = "59";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Wood hoe has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}