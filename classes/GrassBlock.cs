using System;

namespace MinecraftInventoryTracker{

    class GrassBlock: Block{

        public GrassBlock(int newCount): base(newCount){
            blockType = "Grass Block";
        }
    }
}