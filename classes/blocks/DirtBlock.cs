using System;

namespace MinecraftInventoryTracker{

    class DirtBlock: Block{

        public DirtBlock(int newCount): base(newCount){
            blockType = "Dirt Block";
            classType = this;
            image = "dirt-block.png";
            hardness = "0.5";
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Dirt block has been placed.");
        }
    }
}