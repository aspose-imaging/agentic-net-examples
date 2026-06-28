using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load SVG image and ensure proper disposal
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Create SVG options and ensure disposal
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    // Set vector rasterization options (page size based on source image)
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Save the SVG image with the specified options
                    svgImage.Save(outputPath, svgOptions);
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
 * 1. When a C# application must batch‑process SVG files to standardize their page dimensions before publishing them to a web portal, this code loads each SVG, sets the rasterization page size to match the original image, and saves the updated file while guaranteeing proper disposal of image and option objects.
 * 2. When a server‑side service generates dynamic SVG charts and needs to ensure that temporary image resources are released promptly to avoid memory leaks, the using blocks around SvgImage and SvgOptions provide deterministic cleanup.
 * 3. When a desktop utility converts user‑uploaded SVG assets into a consistent size for inclusion in a printable PDF catalog, the code reads the SVG, applies vector rasterization options based on the source size, and writes the adjusted SVG back to disk.
 * 4. When an automated build pipeline validates SVG assets by re‑saving them with explicit rasterization settings to catch corrupted metadata, the try‑catch with using statements ensures errors are logged and resources are freed after each file.
 * 5. When a Windows service monitors a folder for new SVG drawings and needs to copy them to an archive folder with the same dimensions while preventing file handle contention, this pattern loads, configures, and saves the SVG safely using disposable objects.
 */