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
        string outputPath = "output/preview.png";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify the EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Check for raster preview presence
                if (epsImage.HasRasterPreview)
                {
                    Console.WriteLine("Raster preview is present.");

                    // Retrieve the preview image (default format)
                    using (Image preview = epsImage.GetPreviewImage())
                    {
                        if (preview != null)
                        {
                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the preview image as PNG
                            var pngOptions = new PngOptions();
                            preview.Save(outputPath, pngOptions);
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
                    Console.WriteLine("No raster preview found in the EPS file.");
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
 * 1. When a desktop publishing application needs to display a thumbnail of an EPS vector file in a file explorer, it can use this code to check for and extract the raster preview image.
 * 2. When a web service converts uploaded EPS files to PNG thumbnails for preview in a browser, it can programmatically verify the presence of a preview before attempting extraction.
 * 3. When an automated batch‑processing script validates a large collection of EPS assets and skips those without embedded raster previews to avoid unnecessary processing.
 * 4. When a digital asset management system indexes EPS files and stores their preview images for quick search results, it can use this code to retrieve the preview only if it exists.
 * 5. When a print‑ready workflow extracts the low‑resolution preview from an EPS file to generate a proof image for client review before the high‑resolution vector is rendered.
 */