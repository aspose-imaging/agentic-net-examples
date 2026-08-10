// HOW-TO: How to Rasterize OTG to JPEG with 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.jpg";

            // Validate input file existence
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
                // Configure JPEG save options with 300 DPI
                var jpegOptions = new JpegOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Set up OTG rasterization options
                var otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                jpegOptions.VectorRasterizationOptions = otgOptions;

                // Save as JPEG with the specified options
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to generate print‑ready JPEGs from vector OTG drawings at 300 DPI for high‑quality brochures.
 * 2. When an application must convert OTG files to JPEG thumbnails while preserving a specific resolution for consistent display on web galleries.
 * 3. When a reporting tool requires embedding OTG diagrams into PDF reports as high‑resolution JPEG images with exact DPI settings.
 * 4. When a CAD system exports designs to JPEG for archival purposes and must ensure the output meets a 300 DPI standard for regulatory compliance.
 * 5. When an e‑commerce platform processes OTG product illustrations into JPEGs for catalog printing, needing precise DPI to match printer specifications.
 */
