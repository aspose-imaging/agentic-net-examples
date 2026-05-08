using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\cropped.png";

        try
        {
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
                // Cast to OdgImage to access ODG-specific functionality
                OdgImage odgImage = (OdgImage)image;

                // Define the cropping rectangle (example values)
                int left = 50;
                int top = 50;
                int width = 200;
                int height = 200;
                Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, width, height);

                // Crop the image
                odgImage.Crop(cropArea);

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the cropped image as PNG
                odgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}