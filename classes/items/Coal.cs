using System;

namespace MinecraftInventoryTracker{

    class Coal: Block{
        public Coal(int newCount): base(newCount){
            blockType = "Coal";
            classType = this;
            image = "coal.png";
            hardness = "n/a";
        }

        public override void Place(){
            Count--;
            Console.WriteLine("Coal has been placed");
        }
    }
}