// HOW-TO: Extract EPS Preview Image to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.eps";
            string outputPath = "preview.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Get the default preview image
                using (var preview = epsImage.GetPreviewImage())
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No preview image found in the EPS file.");
                        return;
                    }

                    // Save the preview image to the output path
                    preview.Save(outputPath);
                }
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
 * 1. When you need to generate a thumbnail PNG from an EPS file for display in a web gallery or document management system.
 * 2. When a desktop application must show a quick preview of vector EPS artwork without rendering the full vector data.
 * 3. When you are batch‑processing a collection of EPS files to create preview images for a product catalog or e‑commerce site.
 * 4. When you want to validate that an EPS file contains an embedded preview by extracting and saving it before further processing.
 * 5. When you need to convert the EPS preview into a raster format for inclusion in PDF reports or email attachments.
 */
