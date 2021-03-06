using System;

namespace MinecraftInventoryTracker{

    class GlassBlock: Block, Breakable{

        public GlassBlock(int newCount): base(newCount){
            blockType = "Glass Block";
            classType = this;
            image = "glass-block.png";
            hardness = "0.3";
        }
        
        public override void Place()
        {
            Count--;
            Console.WriteLine("Glass block has been placed");
        }

        public void Break(){
            Console.WriteLine("Glassblock is broken");
            Count--;
        }
    }
}