// HOW-TO: Convert OTG Vector Image to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up default rasterization options
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };

                // Configure PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save the image as PNG
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
 * 1. When you need to display an OTG vector graphic on a web page that only supports PNG raster images.
 * 2. When you are generating thumbnails of OTG files for a gallery application that stores images as PNG.
 * 3. When you must preserve the original dimensions of an OTG drawing while converting it to a lossless PNG for archival.
 * 4. When you integrate Aspose.Imaging into a C# service that receives OTG uploads and returns PNG previews to clients.
 * 5. When you automate a workflow that converts engineering diagrams saved as OTG into PNG files for inclusion in PDF reports.
 */
