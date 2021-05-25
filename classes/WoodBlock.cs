using System;

namespace MinecraftInventoryTracker{

    class WoodBlock: Block{

        public WoodBlock(int newCount): base(newCount){
            blockType = "Wood block";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Wood block has been placed.");
        }
    }
}