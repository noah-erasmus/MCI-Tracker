using System;
using System.Collections;

namespace MinecraftInventoryTracker{
    class Inventory{
        private static ArrayList items = new ArrayList();

        public Inventory(){
            ArrayList data = Database.ReadBlocks();
            foreach(Tuple<string,int> curTuple in data){
                Block newBlock;
                switch(curTuple.Item1){
                    case "Wood Block":
                        newBlock = new WoodBlock(curTuple.Item2);
                        break;
                    case "Stick":
                        newBlock = new Stick(curTuple.Item2);
                        break;
                    case "Wood Axe":
                        newBlock = new WoodAxe(curTuple.Item2);
                        break;
                    case "Wood Pickaxe":
                        newBlock = new WoodPickaxe(curTuple.Item2);
                        break;
                    case "Sand Block":
                        newBlock = new SandBlock(curTuple.Item2);
                        break;
                    case "Dirt Block":
                        newBlock = new DirtBlock(curTuple.Item2);
                        break;
                    case "Planks Block":
                        newBlock = new PlanksBlock(curTuple.Item2);
                        break;
                    case "Cobblestone Block":
                        newBlock = new CobblestoneBlock(curTuple.Item2);
                        break;
                    case "Grass Block":
                        newBlock = new GrassBlock(curTuple.Item2);
                        break;
                    case "Wood Hoe":
                        newBlock = new WoodHoe(curTuple.Item2);
                        break;
                    case "Wood Sword":
                        newBlock = new WoodSword(curTuple.Item2);
                        break;
                    case "Stone Pickaxe":
                        newBlock = new StonePickaxe(curTuple.Item2);
                        break;
                    case "Stone Axe":
                        newBlock = new StoneAxe(curTuple.Item2);
                        break;
                    default:
                        newBlock = null;
                        break;
                }
                items.Add(newBlock);
            }
        }

        public static Block GetClass(string index){
            foreach(Block curItem in items){
                if(curItem.BlockType == index){
                    return curItem;
                }
            }
            // if(newBlock){
            //     Inventory.AddBlock(index);
            //     return Inventory.GetClass(index);
            // }
            // throw new Exception("block not found" + index);

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

        public static ArrayList Items{
            get{
                return items;
            }
        }
    }
}