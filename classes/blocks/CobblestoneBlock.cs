using System;

namespace MinecraftInventoryTracker{

    class CobblestoneBlock: Block{

        public CobblestoneBlock(int newCount): base(newCount){
            blockType = "Cobblestone Block";
            classType = this;
            image = "cobblestone-block.png";
            hardness = "2";
        }
        
        public override void Place()
        {
            Count--;
            Console.WriteLine("Cobblestone Block has been placed.");
        }
    }
}