using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string overlayPath = "overlay.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image inputImage = Image.Load(inputStream))
            using (FileStream overlayStream = File.OpenRead(overlayPath))
            using (Image overlayImage = Image.Load(overlayStream))
            {
                RasterImage background = (RasterImage)inputImage;
                RasterImage overlay = (RasterImage)overlayImage;

                // Blend overlay onto background at (0,0) with 50% opacity
                background.Blend(new Point(0, 0), overlay, 128);

                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    PngOptions saveOptions = new PngOptions();
                    background.Save(outputStream, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}