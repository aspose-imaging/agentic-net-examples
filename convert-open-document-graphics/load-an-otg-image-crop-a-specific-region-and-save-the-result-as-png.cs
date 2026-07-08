using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample_cropped.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OtgImage to access cropping functionality
                OtgImage otgImage = (OtgImage)image;

                // Define the crop rectangle (example: top-left corner 100x100, size 200x200)
                int cropX = 100;
                int cropY = 100;
                int cropWidth = 200;
                int cropHeight = 200;
                Rectangle cropArea = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Perform cropping
                otgImage.Crop(cropArea);

                // Save the cropped image as PNG
                PngOptions pngOptions = new PngOptions();
                otgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must extract a specific portion of an OpenDocument Graphic (OTG) file to create a thumbnail PNG for a web gallery.
 * 2. When a document management system needs to programmatically crop a logo from an OTG diagram and store it as a high‑resolution PNG for branding assets.
 * 3. When a reporting tool generates charts in OTG format and requires cropping the chart area before embedding the result as a PNG image in PDF reports.
 * 4. When a batch‑processing script has to convert selected regions of multiple OTG files into PNGs for use in mobile app UI components.
 * 5. When an automated workflow must validate the dimensions of a cropped section of an OTG image and save it as a PNG to be consumed by downstream image‑analysis services.
 */