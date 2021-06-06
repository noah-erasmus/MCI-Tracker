using System;

namespace MinecraftInventoryTracker{

    class GrassBlock: Block{

        public GrassBlock(int newCount): base(newCount){
            blockType = "Grass Block";
            classType = this;
            image = "grass-block.png";
            hardness = "0.6";
        }
        
        public override void Place()
        {
            Count--;
            Console.WriteLine("Grass block has been placed.");
        }
    }
}