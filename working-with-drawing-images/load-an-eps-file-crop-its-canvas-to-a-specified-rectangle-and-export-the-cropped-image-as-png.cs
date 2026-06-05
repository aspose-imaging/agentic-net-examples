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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Define the crop rectangle (x, y, width, height)
                var cropRect = new Aspose.Imaging.Rectangle(50, 50, 300, 300);

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
 * 1. When a developer needs to extract a specific region from a vector EPS logo and deliver it as a raster PNG for web display.
 * 2. When an automated workflow must convert printed‑ready EPS artwork into a cropped PNG thumbnail for a product catalog.
 * 3. When a C# application has to isolate a portion of an EPS diagram (e.g., a chart area) and save it as a PNG for inclusion in a report.
 * 4. When a batch process must validate that an EPS file contains the required content by cropping a known rectangle and checking the resulting PNG.
 * 5. When a developer wants to integrate Aspose.Imaging into a .NET service that receives EPS files, crops them to a predefined canvas size, and returns PNG images to client applications.
 */