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

            

            RibbonPanel panel = app.CreateRibbonPanel(tabName, panelName);

            //2. Create Button Data 1-10
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







            return Result.Succeeded;
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
	}

        public byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); // You can change ImageFormat if needed.
                return memoryStream.ToArray();
            }
        }







    }

}

