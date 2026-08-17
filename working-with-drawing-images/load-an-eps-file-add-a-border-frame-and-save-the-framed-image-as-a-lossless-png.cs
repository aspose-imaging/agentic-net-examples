// HOW-TO: Add Border to EPS and Save as Lossless PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure rasterization options with a border frame
                var rasterOptions = new EpsRasterizationOptions
                {
                    BorderX = 10,                     // Horizontal border thickness
                    BorderY = 10,                     // Vertical border thickness
                    PageWidth = epsImage.Width,       // Preserve original width
                    PageHeight = epsImage.Height,     // Preserve original height
                    BackgroundColor = Color.White    // Optional background color
                };

                // Set PNG options to use the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the framed image as a lossless PNG
                epsImage.Save(outputPath, pngOptions);
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
 * 1. When you need to convert vector EPS artwork into a raster PNG with a white margin for web publishing.
 * 2. When you must preserve the original dimensions of an EPS file while adding a uniform border before archiving.
 * 3. When a printing workflow requires EPS files to be rasterized with a consistent frame for preview generation.
 * 4. When generating thumbnails of EPS drawings for a catalog and you want a lossless PNG output with added padding.
 * 5. When integrating Aspose.Imaging into a C# application to batch‑process EPS files and automatically add a border for consistent layout.
 */
