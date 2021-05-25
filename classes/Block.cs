using System;

namespace MinecraftInventoryTracker
{
    abstract class Block{
        private int count;
        protected string blockType;
        protected static Block classType;

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

        public abstract void Place();

        public static Block Get(){
            return classType;
        }
    }
}