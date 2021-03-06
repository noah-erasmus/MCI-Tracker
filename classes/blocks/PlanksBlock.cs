using System;

namespace MinecraftInventoryTracker{
    class PlanksBlock: Block, Crafted{
        private Recipe recipe;
        public PlanksBlock(int newCount): base(newCount){
            blockType = "Planks Block";
            classType = this;
            image = "planks-block.png";
            hardness = "2";
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