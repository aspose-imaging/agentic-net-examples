// HOW-TO: Crop a Specific Area from ODG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample_cropped.png";

            // Verify input file exists
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
                // Cast to OdgImage to access ODG-specific methods
                OdgImage odgImage = (OdgImage)image;

                // Define the crop rectangle (example: central half of the image)
                int cropX = odgImage.Width / 4;
                int cropY = odgImage.Height / 4;
                int cropWidth = odgImage.Width / 2;
                int cropHeight = odgImage.Height / 2;
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Crop the image
                odgImage.Crop(cropRect);

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
 * 1. When a developer needs to extract a central portion of an OpenDocument graphic for use in a web thumbnail, they can load the .odg file, crop it, and export it as a PNG.
 * 2. When integrating legacy ODG assets into a modern .NET application, cropping unwanted margins before converting to PNG ensures consistent layout and reduced file size.
 * 3. When generating printable assets from a design created in OpenDocument, developers can programmatically crop the required region and save it as a high‑quality PNG for downstream workflows.
 * 4. When automating batch processing of ODG diagrams, the code can isolate each diagram’s key area, crop it, and store the result as PNG for inclusion in reports or presentations.
 * 5. When a user uploads an ODG file to a C# web service and only a specific region is needed for a preview, the service can crop that region and return a PNG image instantly.
 */
