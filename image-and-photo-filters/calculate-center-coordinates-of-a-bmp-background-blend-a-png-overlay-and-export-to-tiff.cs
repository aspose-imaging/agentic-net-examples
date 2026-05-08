using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string bmpPath = "background.bmp";
            string pngPath = "overlay.png";
            string outputPath = "result.tif";

            // Validate input files
            if (!File.Exists(bmpPath))
            {
                Console.Error.WriteLine($"File not found: {bmpPath}");
                return;
            }
            if (!File.Exists(pngPath))
            {
                Console.Error.WriteLine($"File not found: {pngPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background BMP and overlay PNG
            using (RasterImage background = (RasterImage)Image.Load(bmpPath))
            using (RasterImage overlay = (RasterImage)Image.Load(pngPath))
            {
                // Calculate top‑left corner to center the overlay
                int offsetX = (background.Width - overlay.Width) / 2;
                int offsetY = (background.Height - overlay.Height) / 2;

                // Blend overlay onto background
                Rectangle destRect = new Rectangle(offsetX, offsetY, overlay.Width, overlay.Height);
                background.SaveArgb32Pixels(destRect, overlay.LoadArgb32Pixels(overlay.Bounds));

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the blended image as TIFF
                background.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}