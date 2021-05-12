using System;

namespace MinecraftInventoryTracker
{
    class Block{
        private int count;
        protected string blockType;

        public int Count{
            get{
                return count;
            }
            set{
                if(value < 0){
                    count = -value;
                }else{
                    count = value;
                }
            }
        }

        public string BlockType{
            get{
                return blockType;
            }
        }

        public Block(int newCount){
            count = newCount;
        }

        public virtual void Place(){
            count--;
            Console.WriteLine("Block placed.");
        }
    }
}