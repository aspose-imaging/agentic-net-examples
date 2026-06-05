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
            string inputPath = "input.otg";
            string outputPath = "output.png";

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
                // Cast to OtgImage to access OTG-specific methods
                OtgImage otgImage = image as OtgImage;
                if (otgImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an OTG image.");
                    return;
                }

                // Define the cropping rectangle (example: central half of the image)
                var cropRect = new Rectangle(
                    otgImage.Width / 4,
                    otgImage.Height / 4,
                    otgImage.Width / 2,
                    otgImage.Height / 2);

                // Crop the image
                otgImage.Crop(cropRect);

                // Save the cropped image as PNG
                var pngOptions = new PngOptions();
                otgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}