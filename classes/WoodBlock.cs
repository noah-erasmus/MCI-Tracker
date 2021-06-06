using System;

namespace MinecraftInventoryTracker{

    class WoodBlock: Block{
        private Recipe recipe;

        public WoodBlock(int newCount): base(newCount){
            blockType = "Wood Block";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Wood block has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}