using System;

namespace MinecraftInventoryTracker{

    class SandBlock: Block, Meltable{
        public SandBlock(int newCount): base(newCount){
            blockType = "Sand Block";
            classType = this;
            image = "sand-block.png";
            hardness = "0.5";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Sand block has been placed");
        }

        public Block Melt(){
            Console.WriteLine("Sandblock melts into glass");
            Count--;
            return new GlassBlock(1);
        }
    }
}