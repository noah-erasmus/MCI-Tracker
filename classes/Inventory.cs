using System;
using System.Collections;

namespace MinecraftInventoryTracker{
    class Inventory{
        private static ArrayList items;

        public Inventory(){
            items.Add(new Coal(4));
            items.Add(new SandBlock(10));
        }

        public ArrayList Items{
            get{
                return items;
            }
        }
    }
}