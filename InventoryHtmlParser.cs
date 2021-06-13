using System;
using System.Text;
using System.IO;
using HtmlAgilityPack;
using System.Net;
using System.Threading.Tasks;
using System.Collections;

namespace MinecraftInventoryTracker
{
    class InventoryHtmlParser
    {
        public static string Process(string input)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(input);

            if(htmlDoc.ParseErrors != null || htmlDoc.DocumentNode == null)
            {
                int count = 0;
                foreach (var htmlParseError in htmlDoc.ParseErrors)
                {
                    count++;
                    Console.WriteLine("Parse error: " + htmlParseError.Reason);
                }

                if(count > 0)
                {
                    throw new FileNotFoundException("File corrupt!");
                }
            }

            ArrayList newItems = Inventory.Items;

            HtmlNode itemNode = htmlDoc.GetElementbyId("item-list");
            Console.WriteLine(itemNode.OuterHtml);

            // string[] blockList = {"Bedrock", "Melon", "Grass Block", "Cobblestone", "Sand", "Dirt", "Leaves"};

            foreach(Block blockEntry in newItems){
                int count = Inventory.GetCount(blockEntry.BlockType);
                HtmlNode newNode = HtmlNode.CreateNode("<div class='box'><form action='./inventory.html' method='POST'><div class='block-row is-flex columns is-flex-direction-row is-desktop is-vcentered'><div class='block-image column is-2'><figure class='image is-96x96'><img src='img/"+blockEntry.Image+"' alt='block-image'></figure></div><div class='block-name column is-3'><h5 class='title is-5'>"+blockEntry.BlockType+"</h5></div><div class='block-hardness column'><p>"+blockEntry.Hardness+"</p></div><div class='block-quantity column'><input type='text' id='"+blockEntry.BlockType+"' name='"+blockEntry.BlockType+"' value='"+count+"' /></div><div class='column'><input type='submit' value='Update'></div></div></form></div>");
                itemNode.AppendChild(newNode);
            }

            HtmlNode craftablesNode = htmlDoc.GetElementbyId("craftables");

            foreach(Recipe curRecipe in RecipeBook.Recipes){
                if(curRecipe.IsViable()){
                    HtmlNode craftNode = HtmlNode.CreateNode("<div class='box'><form action='./inventory.html' method='POST'><div class='block-row is-flex columns is-flex-direction-row is-desktop is-vcentered'><div class='block-image column'><figure class='image is-96x96'><img src='img/"+curRecipe.Result.Image+"' alt='block-image'></figure></div><div class='block-name column'><h5 class='title is-5'>"+curRecipe.Result.BlockType+"</h5></div><div class='column'><input type='hidden' id='applyRecipe' name='recipe' value='"+curRecipe.Result.BlockType+"'><input type='submit' value='Craft'></div></div></form></div>");
                    craftablesNode.AppendChild(craftNode);
                }
            }

            // foreach(Recipe curRecipe in viableRecipes){
            //     HtmlNode newNode = HtmlNode.CreateNode("<div class='box'><div class='block-row'><div class='block-image'><img src='grass-block.png' alt='block-image'></div><div class='block-name'><h4 class='title is-4'>"+curRecipe.Result+"</h4></div></div></div>");
            // }
            
            return htmlDoc.DocumentNode.InnerHtml;
        }

        public static void CraftRecipe(string blockType){
            RecipeBook.ApplyRecipe(blockType);
        }

    }
}

//<div class="box"><div class='block-row'><div class='block-image'><img src='grass-block.png' alt='block-image'></div><div class='block-name'><h4 class='title is-4'>Grass Block</h4></div><div class='block-hardness'><p>0.5</p></div><div class='block-craftable'></div><div class='block-quantity'><p>1</p></div></div></div>

// "<tr><img src='/images/grass-block.png' alt='grass-block'></tr><tr><h3 class='title is-3'>"+blockEntry+"</h3></tr><tr><h4 class='title is-4'>0.6</h4></tr><tr><h4 class='title is-4'>Yes</h4></tr><tr><h4 class='title is-4'>1</h4></tr>"

// <div class="box">
//     <div class='block-row'>
//         <div class='block-image'>
//             <img src='grass-block.png' alt='block-image'>
//         </div>
//         <div class='block-name'>
//             <h4 class='title is-4'>Grass Block</h4>
//         </div>
//         <div class='block-hardness'>
//             <p>0.5</p>
//         </div>
//         <div class='block-craftable'>
//         </div
//         <div class='block-quantity'>
//             <p>1</p>
//         </div>
//     </div>
// </div>