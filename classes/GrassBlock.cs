using System;

namespace MinecraftInventoryTracker{

    class GrassBlock: Block{

        public GrassBlock(int newCount): base(newCount){
            blockType = "Grass Block";
        }
        
        public override void Place()
        {
            Count--;
            Console.WriteLine("Grass block has been placed.");
        }
    }
}