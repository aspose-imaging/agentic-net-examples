// HOW-TO: Crop EPS Canvas to Rectangle and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\Cropped\sample_cropped.png";

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

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Define the crop rectangle (x, y, width, height)
                // Adjust these values as needed for the desired canvas area
                var cropArea = new Aspose.Imaging.Rectangle(50, 50, 200, 200);

                // Perform cropping
                image.Crop(cropArea);

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
 * 1. When you need to extract a specific region from a vector EPS logo and deliver it as a PNG thumbnail for a web page.
 * 2. When preparing print‑ready artwork, you may want to remove unwanted margins from an EPS file before converting it to a raster PNG for proofing.
 * 3. When automating a workflow that generates product labels, you can crop the EPS template to the label size and save it as a PNG for downstream processing.
 * 4. When integrating legacy EPS diagrams into a mobile app, cropping the canvas and converting to PNG reduces file size and ensures compatibility.
 * 5. When batch‑processing design assets, you can programmatically crop each EPS file to a defined area and export the result as PNG for use in marketing materials.
 */
