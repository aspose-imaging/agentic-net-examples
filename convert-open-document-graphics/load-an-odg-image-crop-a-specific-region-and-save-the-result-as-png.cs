using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\cropped.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to access ODG-specific functionality
                OdgImage odgImage = (OdgImage)image;

                // Define the cropping rectangle (x, y, width, height)
                // Adjust these values as needed for the specific region
                Rectangle cropRect = new Rectangle(100, 100, 200, 200);

                // Perform the crop operation
                odgImage.Crop(cropRect);

                // Save the cropped image as PNG
                PngOptions pngOptions = new PngOptions();
                odgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}