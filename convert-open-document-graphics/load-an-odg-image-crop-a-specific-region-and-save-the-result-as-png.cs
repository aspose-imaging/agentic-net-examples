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
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\cropped.png";

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
                // Cast to OdgImage to access vector-specific methods
                OdgImage odgImage = (OdgImage)image;

                // Define the crop rectangle (example: top-left corner 50x50, width 200, height 150)
                var cropArea = new Rectangle(50, 50, 200, 150);

                // Perform cropping
                odgImage.Crop(cropArea);

                // Save the cropped image as PNG
                var pngOptions = new PngOptions();
                odgImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract a specific diagram region from an OpenDocument Graphic (ODG) file and deliver it as a PNG thumbnail for a web preview.
 * 2. When an application must generate a cropped PNG snapshot of a vector illustration stored in ODG format for inclusion in a PDF report.
 * 3. When a content management system requires converting a selected area of an ODG drawing into a PNG image to display on mobile devices.
 * 4. When an automated batch process has to trim unnecessary margins from ODG assets and save the result as PNG files for faster loading in a UI.
 * 5. When a designer tool wants to let users select a portion of an ODG canvas and export that selection as a PNG for use in presentations.
 */