using System;

namespace MinecraftInventoryTracker{
    class Planks: Block, Crafted{
        private Recipe recipe;
        public Planks(int newCount): base(newCount){
            blockType = "Planks block";
            classType = this;
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Planks have been placed");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}