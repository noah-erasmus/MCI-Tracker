using System.Collections.Generic;

namespace MinecraftInventoryTracker{
    interface Crafted{
        void SetRecipe(Recipe newRecipe);
        Recipe GetRecipe();
    }
}