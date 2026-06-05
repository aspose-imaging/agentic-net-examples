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
            string backgroundPath = "background.png";
            string overlayPath = "overlay.png";
            string outputPath = "result.png";

            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Blend overlay onto background with full opacity (255)
                background.Blend(new Point(0, 0), overlay, 255);

                // Save blended image as PNG
                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);
                background.Save(outputPath, options);
            }

            Console.WriteLine("Blending completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}