using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.odg";
            string outputPath = "C:\\temp\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage for ODG-specific operations
                OdgImage odgImage = image as OdgImage;

                // NOTE: Aspose.Imaging does not expose a direct method to set an ICC profile on ODG images.
                // If needed, ICC handling would be performed via metadata or conversion steps.
                // Here we proceed to save the image as PNG using default color handling.

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG
                odgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}