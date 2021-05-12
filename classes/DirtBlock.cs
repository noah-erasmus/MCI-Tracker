using System;

namespace MinecraftInventoryTracker{

    class DirtBlock: Block{

        public DirtBlock(int newCount): base(newCount){
            blockType = "Dirt Block";
        }
    }
}