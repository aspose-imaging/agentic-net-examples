// HOW-TO: Check for and Extract EPS Raster Preview Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "preview.png";

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

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Determine if a raster preview is present
                bool hasPreview = image.HasRasterPreview;

                Console.WriteLine($"Has raster preview: {hasPreview}");

                if (hasPreview)
                {
                    // Retrieve the preview image (default format)
                    using (var preview = image.GetPreviewImage())
                    {
                        if (preview != null)
                        {
                            // Save the preview image to the specified output path
                            preview.Save(outputPath, new PngOptions());
                            Console.WriteLine($"Preview image saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("Preview image could not be retrieved.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No raster preview available in the EPS file.");
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
 * 1. When you need to verify whether an EPS file contains an embedded raster preview before generating a thumbnail.
 * 2. When processing a batch of EPS graphics and you want to extract any available preview images to PNG for quick web display.
 * 3. When integrating a print workflow that must detect EPS preview images to decide if a fallback rasterization step is required.
 * 4. When building a document conversion tool that should only extract preview images from EPS files that actually include them, avoiding runtime errors.
 * 5. When automating quality control for incoming EPS assets and you need to confirm the presence of a preview image before further processing.
 */
