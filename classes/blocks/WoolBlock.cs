using System;

namespace MinecraftInventoryTracker{
    class WoolBlock: Block, Crafted{
        private Recipe recipe;
        public WoolBlock(int newCount): base(newCount){
            blockType = "Wool Block";
            classType = this;
            image = "wool-block.png";
            hardness = "2";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Wool Block have been placed");
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public void SetRecipe(Recipe newRecipe){
            recipe = newRecipe;
        }
    }
}