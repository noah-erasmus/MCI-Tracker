using System;

namespace MinecraftInventoryTracker{

    class SandBlock: Block{
        public SandBlock(int newCount): base(newCount){
            blockType = "Sand Block";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Sand block has been placed");
        }
    }
}