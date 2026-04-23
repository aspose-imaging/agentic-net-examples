using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\source.tif";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Save as PNG using default options
                var pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
            }

            // Load the generated PNG image
            using (Image pngImg = Image.Load(outputPath))
            {
                // Cast to PngImage to access HasAlpha property
                var pngImage = (PngImage)pngImg;
                bool hasAlpha = pngImage.HasAlpha;

                // Log transparency status
                Console.WriteLine($"PNG image has alpha channel: {hasAlpha}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}