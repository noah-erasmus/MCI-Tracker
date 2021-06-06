using System;

namespace MinecraftInventoryTracker{

    class Diamond: Block{
        private Recipe recipe;

        public Diamond(int newCount): base(newCount){
            blockType = "Diamond";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Diamond has been placed.");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}