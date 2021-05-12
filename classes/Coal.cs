using System;

namespace MinecraftInventoryTracker{

    class Coal: Block{
        public Coal(int newCount): base(newCount){
            blockType = "Coal resource";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Coal has been placed");
        }
    }
}