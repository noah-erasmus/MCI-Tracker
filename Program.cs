using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Collections;

namespace MinecraftInventoryTracker
{
    class Program
    {

        public static HttpListener listener;

        public static string url = "http://localhost:8000/";

        public static int pageViews = 0;

        public static int requestCount = 0;

        public static async Task HandleIncomingConnections()
        {
            bool runServer = true;

            //Keep running while server is not shutdown
            while(runServer)
            {
                //Get request and response from connection
                HttpListenerContext ctx = await listener.GetContextAsync();
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                //Console log request info
                Console.WriteLine("Request #: {0}", ++requestCount);
                Console.WriteLine(req.Url.ToString());
                Console.WriteLine(req.HttpMethod);
                Console.WriteLine(req.UserHostName);
                Console.WriteLine(req.UserAgent);
                Console.WriteLine();

                string path = req.Url.AbsolutePath;

                //When shutdown is posted
                if((req.HttpMethod == "POST") && path == "/shutdown")
                {
                    path = "/index.html";
                    Console.WriteLine("Shutdown requested");
                    //Stop running server
                    runServer = false;
                }

                if(path != "/favicon.ico")
                {
                    pageViews += 1;
                }

                try
                {
                    //Instance of FileLoader
                    FileLoader myFileLoader = new FileLoader(path);
                    myFileLoader.ReadFile();

                    string disableSubmit = !runServer? "disabled" : "";

                    byte[] data;

                    //Mime type derived from page's extension
                    if(myFileLoader.mimeType.IndexOf("text/html") >= 0)
                    {
                        string input = Encoding.UTF8.GetString(myFileLoader.data);

                        if(path == "/index.html")
                        {
                            data = Encoding.UTF8.GetBytes(IndexHtmlParser.Process(input));
                        }
                        else if(path == "/inventory.html"){
                            data = Encoding.UTF8.GetBytes(InventoryHtmlParser.Process(input));
                        }
                        // else if(path == "/hello.html")
                        // {
                        //     data = Encoding.UTF8.GetBytes(HelloHtmlParser.Process(input));
                        // }
                        else
                        {
                            throw new FileNotFoundException("Not a page.");
                        }
                    }
                    else
                    {
                        data =  myFileLoader.data;
                    }
                        
                    resp.ContentType = myFileLoader.mimeType;
                    resp.ContentEncoding = Encoding.UTF8;
                    resp.ContentLength64 = data.LongLength;

                    await resp.OutputStream.WriteAsync(data, 0, data.Length);
                }
                catch
                {
                    byte[] data;
                    data = Encoding.UTF8.GetBytes(String.Format("<h2> A 404 error occured </h2>"));
                        
                    resp.ContentType = "text/html";
                    resp.ContentEncoding = Encoding.UTF8;
                    resp.ContentLength64 = data.LongLength;
                    resp.StatusCode = 404;

                    await resp.OutputStream.WriteAsync(data, 0, data.Length);
                }
                resp.Close();
            }
        }


        public static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            // ArrayList array = inventory.Items;
            RecipeBook.Populate();
            foreach(Recipe curRecipe in RecipeBook.Recipes){
                Console.WriteLine(curRecipe.Result.BlockType);
            }

            // Recipe woodAxeRecipe = new Recipe((Crafted)Inventory.GetClass("Wood Axe"), new Block[3,3]
            // {{Inventory.GetClass("Wood block"),Inventory.GetClass("Wood block"), null},
            // {Inventory.GetClass("Wood block"),Inventory.GetClass("Stick"), null},
            // {null,Inventory.GetClass("Stick"),null}});
            // RecipeBook.AddRecipe(woodAxeRecipe);

            // Recipe woodPickaxeRecipe = new Recipe((Crafted)Inventory.GetClass("Wood Pickaxe"), new Block[3,3]
            // {{Inventory.GetClass("Wood block"),Inventory.GetClass("Wood block"), Inventory.GetClass("Wood block")},
            // {null,Inventory.GetClass("Stick"), null},
            // {null,Inventory.GetClass("Stick"),null}});
            // RecipeBook.AddRecipe(woodPickaxeRecipe);

            // ArrayList newItems = Inventory.Items;
            // foreach (Block currentBlock in newItems){
            //     HtmlNode newNode = HtmlNode.CreateNode("<li>" + currentBlock.BlockType + "</li>");

            // }



            Inventory.GetClass("Wood Block").Count++;
            Console.WriteLine("woodblock " + Inventory.GetCount("Wood Block"));

            Console.WriteLine("Serve version " + Database.GetVersion());

            Console.WriteLine(Inventory.GetClass("Wood Block").BlockType);

            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();

            Console.WriteLine("Listening for connections on " + url);

            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();
            Console.WriteLine("after sync");

            listener.Close();
        }
    }
}