using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace RVTBootcamp_Module04_Challenge
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            // write your ribbon code here

         
            string tabName = "Martins Add-in";
            string panelName = "Martins Panel";

            app.CreateRibbonTab(tabName);

            try
            {
                app.CreateRibbonTab(tabName);

            }
            catch (Exception error)
            {
                Debug.Print("Tab already exist. Using existing panel.");
                Debug.Print(error.Message);
            }

            RibbonPanel panel = app.CreateRibbonPanel(tabName, panelName);

            
            PushButtonData buttonData1 = new PushButtonData("cmd1", "Tool 1", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd1");
            PushButtonData buttonData2 = new PushButtonData("cmd2", "Tool 2", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd2");
            PushButtonData buttonData3 = new PushButtonData("cmd3", "Tool 3", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd3");
            PushButtonData buttonData4 = new PushButtonData("cmd4", "Tool 4", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd4");
            PushButtonData buttonData5 = new PushButtonData("cmd5", "Tool 5", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd5");
            PushButtonData buttonData6 = new PushButtonData("cmd6", "Tool 6", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd6");
            PushButtonData buttonData7 = new PushButtonData("cmd7", "Tool 7", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd7");
            PushButtonData buttonData8 = new PushButtonData("cmd8", "Tool 8", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd8");
            PushButtonData buttonData9 = new PushButtonData("cmd9", "Tool 9", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd9");
            PushButtonData buttonData10 = new PushButtonData("cmd10", "Tool 10", Assembly.GetExecutingAssembly().Location, "RVTBootcamp_Module04_Challenge.cmd10");

            //Bitmap myBitmap = Properties.Resources.Green_32; // loading a Bitmap from resources
            ////byte[] byteArray = ConvertBitmapToByteArray(myBitmap);

            //Bitmap myBitmap2 = Properties.Resources.Green_16; 
            ////byte[] byteArray2 = ConvertBitmapToByteArray(myBitmap2);

            //Bitmap myBitmap3 = Properties.Resources.Blue_32; 
            ////byte[] byteArray3 = ConvertBitmapToByteArray(myBitmap3);

            //Bitmap myBitmap4 = Properties.Resources.Blue_16; 
            ////byte[] byteArray4 = ConvertBitmapToByteArray(myBitmap4);

            

            PushButton button1 = panel.AddItem(buttonData1) as PushButton;
            PushButton button2 = panel.AddItem(buttonData2) as PushButton;

            
            panel.AddStackedItems(buttonData3, buttonData4, buttonData5);

            
            SplitButtonData splitButtonData = new SplitButtonData("SplitButton", "Split\rButton");
            SplitButton splitButton = panel.AddItem(splitButtonData) as SplitButton;
            splitButton.AddPushButton(buttonData6);
            splitButton.AddPushButton(buttonData7);

            panel.AddSeparator();
            panel.AddSlideOut();
            PulldownButtonData pulldownButtonData = new PulldownButtonData("pulldownButton", "Pulldown\rButton");
//            pulldownButtonData.LargeImage = ConvertToImageSource(byteArray);

            PulldownButton pulldownButton = panel.AddItem(pulldownButtonData) as PulldownButton;
            pulldownButton.AddPushButton(buttonData8);
            pulldownButton.AddPushButton(buttonData9);
            pulldownButton.AddPushButton(buttonData10);



            return Result.Succeeded;
        }

        private RibbonPanel CreateGetPanel(UIControlledApplication app, string tabName, string panelName1)
        {
            //look for panel in tab
            foreach (RibbonPanel panel in app.GetRibbonPanels(tabName))
            {
                if (panel.Name == panelName1)
                {
                    return panel;
                }
            }

            ////Panel not found, Create it
            //RibbonPanel returnPanel = app.CreateRibbonPanel(tabName, panelName1);
            //return returnPanel;

            return app.CreateRibbonPanel(tabName, panelName1);

        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        public BitmapImage ConvertToImageSource(byte[] imageData)
        {
            using (MemoryStream mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = mem;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();

                return image;
            }
        }
	

        public byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); //change ImageFormat if needed.
                return memoryStream.ToArray();
            }
        }

    }

}

