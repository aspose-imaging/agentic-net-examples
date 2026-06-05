using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.wmf";
            string outputPath = "output\\resized.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to WmfImage to access WMF-specific methods
                var wmfImage = (WmfImage)image;

                // Resize to 800x800 pixels using nearest neighbour resampling
                wmfImage.Resize(800, 800, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                // Save the resized image as PNG
                wmfImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}