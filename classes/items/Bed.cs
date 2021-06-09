using System;

namespace MinecraftInventoryTracker{
    class Bed: Block, Crafted{
        private Recipe recipe;
        public Bed(int newCount): base(newCount){
            blockType = "Bed";
            classType = this;
            image = "bed.png";
            hardness = "0.2";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Bed has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}