using System;

namespace MinecraftInventoryTracker
{
    abstract class Block{
        private int count;
        protected string blockType;
        protected static Block classType;
        protected string image;
        protected string hardness;

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
                Database.UpdateBlockCount(blockType, count);
            }
        }

        public string BlockType{
            get{
                return blockType;
            }
        }
        public string Hardness{
            get{
                return hardness;
            }
        }

        public string Image{
            get{
                return image;
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