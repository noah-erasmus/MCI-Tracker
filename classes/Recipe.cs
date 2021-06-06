using System.Collections.Generic;

namespace MinecraftInventoryTracker{
    class Recipe{
        private Block[,] inputs;

        private Crafted result;

        public Recipe(Crafted newResult, Block[,] newInputs){
            inputs = newInputs;
            result = newResult;
            result.SetRecipe(this);
        }

        public Block[,] Inputs{
            get{
                return inputs;
            }
        }

        public Block Result{
            get{
                return (Block)result;
            }
        }

        public bool IsViable(){
            var map = new Dictionary<string,int>();

            foreach(Block curBlock in inputs){
                if(curBlock != null){
                    int count;
                    if(map.TryGetValue(curBlock.BlockType, out count)){
                        map[curBlock.BlockType] += 1;
                    }else{
                        map.Add(curBlock.BlockType, 1);
                    }
                }
            }

            bool result = true;
            foreach(var pair in map){
                if(pair.Value>Inventory.GetCount(pair.Key)){
                    result = false;
                }
            }

            return result;
        }
    }
}