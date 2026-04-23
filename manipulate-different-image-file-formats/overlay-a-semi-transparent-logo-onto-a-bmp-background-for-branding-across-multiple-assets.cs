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
            // Hardcoded input and output paths
            string backgroundPath = "background.bmp";
            string logoPath = "logo.png";
            string outputPath = "output.bmp";

            // Validate input files
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background and logo images
            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Overlay logo at (0,0) with 50% opacity (128 out of 255)
                background.Blend(new Point(0, 0), logo, 128);

                // Save the composited image as BMP
                BmpOptions bmpOptions = new BmpOptions() { Source = new FileCreateSource(outputPath, false) };
                background.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}