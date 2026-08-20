// HOW-TO: Batch Convert Raster Images to SVG with Original Filenames in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputImages";
            string outputFolder = @"C:\OutputSvgs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Define supported raster extensions
            string[] rasterExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".tiff", ".tif", ".gif" };

            // Enumerate files in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder))
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Process only supported raster files
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (Array.IndexOf(rasterExtensions, ext) < 0)
                {
                    continue;
                }

                // Build the output SVG path preserving the original filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare rasterization options based on the source image size
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save as SVG using the prepared options
                    image.Save(outputPath, new SvgOptions { VectorRasterizationOptions = vectorRasterizationOptions });
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
 * 1. When you need to automatically generate scalable SVG versions of a large set of product photos stored as PNG or JPEG for responsive web design.
 * 2. When a publishing workflow requires converting scanned TIFF documents to SVG to retain quality while keeping the original file names for indexing.
 * 3. When a graphics pipeline must batch‑process user‑uploaded BMP or GIF assets into vector SVGs for use in mobile apps without manual renaming.
 * 4. When you want to create a searchable archive of legacy raster images by converting them to SVG format while preserving their original naming conventions.
 * 5. When an automated build script must transform all raster images in a directory to SVGs using Aspose.Imaging in C# to prepare assets for print‑ready PDFs.
 */
