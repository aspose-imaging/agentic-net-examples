using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.svg";

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

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for OTG to SVG conversion
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };

                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = otgRasterOptions,
                    // Remove metadata and avoid extra whitespace to keep the SVG small
                    KeepMetadata = false,
                    // Do not compress to .svgz; the SVG will be saved as plain XML (already minimal)
                    Compress = false
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy OTG vector drawings into web‑ready SVG files while stripping metadata to keep the XML lightweight for faster page loads.
 * 2. When an automated build script must generate scalable graphics from OTG assets for a responsive UI and ensure the resulting SVG files are as small as possible to reduce bandwidth usage.
 * 3. When a desktop application has to export user‑created OTG diagrams to SVG for inclusion in PDF reports, and the code must minimize the SVG size to keep the final document compact.
 * 4. When integrating Aspose.Imaging into a C# service that receives OTG files via an API and returns minified SVG responses for mobile clients with limited data plans.
 * 5. When a developer is preparing OTG artwork for email newsletters and wants to convert it to SVG and remove unnecessary metadata to stay within attachment size limits.
 */