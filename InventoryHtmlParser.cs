using System;
using System.Text;
using System.IO;
using HtmlAgilityPack;

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

            HtmlNode itemNode = htmlDoc.GetElementbyId("table-body");
            Console.WriteLine(itemNode.OuterHtml);

            string[] blockList = {"bedrock", "melon", "grass-block"};

            foreach(string blockEntry in blockList){
                HtmlNode newNode = HtmlNode.CreateNode("<div class='block-row is-flex columns is-flex-direction-row'><div class='block-image column'><img src='images/grass-block.png' alt='block-image'></div><div class='block-name column'><h4 class='title is-4'>"+blockEntry+"</h4></div><div class='block-hardness column'><p>0.5</p></div><div class='block-craftable column'><p>No</p></div><div class='block-quantity column'><p>1</p></div></div>");
                itemNode.AppendChild(newNode);
            }
            
            return htmlDoc.DocumentNode.InnerHtml;
        }
    }
}

// "<div class='block-row'><div class='block-image'><img src='grass-block.png' alt='block-image'></div><div class='block-name'><h4 class='title is-4'>Grass Block</h4></div><div class='block-hardness'><p>0.5</p></div><div class='block-craftable'></div><div class='block-quantity'><p>1</p></div></div>"

// "<tr><img src='/images/grass-block.png' alt='grass-block'></tr><tr><h3 class='title is-3'>"+blockEntry+"</h3></tr><tr><h4 class='title is-4'>0.6</h4></tr><tr><h4 class='title is-4'>Yes</h4></tr><tr><h4 class='title is-4'>1</h4></tr>"