using System;

namespace MinecraftInventoryTracker{

    class CobblestoneBlock: Block{

        public CobblestoneBlock(int newCount): base(newCount){
            blockType = "Cobblestone Block";
        }
        
        public override void Place()
        {
            Count--;
            Console.WriteLine("Cobblestone Block has been placed.");
        }
    }
}