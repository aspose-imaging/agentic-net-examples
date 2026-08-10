// HOW-TO: Convert OTG File to SVG with Embedded CSS Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\sample.otg";
        string outputPath = @"C:\Output\sample.svg";

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
                // Configure rasterization options for OTG
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size,
                    // Optional: set background color if needed
                    // BackgroundColor = Color.White
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    // Keep text as text so CSS can style it
                    TextAsShapes = false,
                    // Assign the OTG rasterization options
                    VectorRasterizationOptions = otgRasterOptions,
                    // Optional: disable compression to keep SVG readable
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
 * 1. When you need to display vector graphics from an OTG design on the web without losing text editability.
 * 2. When you want to generate SVG files from OTG images for responsive UI scaling in a C# application.
 * 3. When you need to preserve original page dimensions while converting OTG to SVG for print‑ready output.
 * 4. When you require CSS‑styleable text in the resulting SVG to match corporate branding across browsers.
 * 5. When you automate batch conversion of OTG files to readable SVG files in a .NET backend service.
 */
