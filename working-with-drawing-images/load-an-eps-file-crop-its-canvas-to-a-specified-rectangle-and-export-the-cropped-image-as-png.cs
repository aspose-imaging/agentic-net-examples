using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.eps";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Define the crop rectangle (x, y, width, height)
                var cropRect = new Aspose.Imaging.Rectangle(100, 100, 400, 300);

                // Crop the image to the specified rectangle
                image.Crop(cropRect);

                // Save the cropped image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a designer needs to extract a specific portion of a vector EPS logo and deliver it as a PNG thumbnail for a website.
 * 2. When an e‑commerce platform automatically generates product preview images by cropping the central area of EPS artwork and saving it as PNG for faster loading.
 * 3. When a publishing workflow converts EPS page elements into PNG snippets to embed in HTML newsletters, requiring precise canvas cropping.
 * 4. When a GIS application isolates a region of an EPS map file and exports the cropped area as a PNG overlay for analysis.
 * 5. When a batch‑processing tool prepares EPS‑based certificates by cropping the signature block and saving it as a PNG image for digital signing.
 */