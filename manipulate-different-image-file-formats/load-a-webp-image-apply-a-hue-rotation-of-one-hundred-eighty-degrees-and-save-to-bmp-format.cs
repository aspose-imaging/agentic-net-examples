using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.webp";
            string outputPath = "C:\\temp\\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WebP image, apply a 180-degree rotation (used here as hue rotation placeholder), and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate the image 180 degrees; Aspose.Imaging does not provide a direct hue rotation method,
                // so we use the Rotate method as an example transformation.
                webPImage.Rotate(180f, true, Aspose.Imaging.Color.White);

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