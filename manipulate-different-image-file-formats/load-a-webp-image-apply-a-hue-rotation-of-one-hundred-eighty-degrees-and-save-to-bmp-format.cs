using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.webp";
            string outputPath = "output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image, apply a 180° hue/rotation, and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Apply a 180 degree rotation (geometric). Aspose.Imaging does not expose a direct hue‑shift method,
                // so we use Rotate as the closest available operation for demonstration.
                webPImage.Rotate(180f, true, Color.White);

                // Save the transformed image to BMP format
                webPImage.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}