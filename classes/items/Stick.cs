using System;

namespace MinecraftInventoryTracker{
    class Stick: Block, Crafted{
        private Recipe recipe;
        public Stick(int newCount): base(newCount){
            blockType = "Stick";
            classType = this;
            image = "stick.png";
            hardness = "n/a";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Stick has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}