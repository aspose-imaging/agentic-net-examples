using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Adjust brightness
                if (image is Aspose.Imaging.RasterImage raster)
                {
                    raster.AdjustBrightness(50); // increase brightness by 50
                }

                // Set smoothing mode
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                // Export to PNG
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}