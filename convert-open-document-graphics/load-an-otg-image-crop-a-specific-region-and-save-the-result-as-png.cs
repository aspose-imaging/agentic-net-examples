using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output\cropped.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OtgImage to access specific functionality
                OtgImage otgImage = image as OtgImage;
                if (otgImage == null)
                {
                    Console.Error.WriteLine("Failed to cast loaded image to OtgImage.");
                    return;
                }

                // Define the crop rectangle (example: top-left corner (50,50) with size 200x200)
                Rectangle cropArea = new Rectangle(50, 50, 200, 200);

                // Crop the image
                otgImage.Crop(cropArea);

                // Save the cropped image as PNG
                otgImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}