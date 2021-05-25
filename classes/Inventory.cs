using System;
using System.Collections;

namespace MinecraftInventoryTracker{
    class Inventory{
        private static ArrayList items = new ArrayList();

        public Inventory(){
            items.Add(new Coal(4));
            items.Add(new SandBlock(10));
            items.Add(new WoodBlock(6));
            items.Add(new Planks(1));
        }

        public static Block GetClass(string index){
            foreach(Block curItem in items){
                if(curItem.BlockType == index){
                    return curItem;
                }
            }

            return null;
        }

        public static int GetCount(string index){
            foreach(Block curItem in items){
                if(curItem.BlockType ==  index){
                    return curItem.Count;
                }
            }

            return -1;
        }

        public ArrayList Items{
            get{
                return items;
            }
        }
    }
}