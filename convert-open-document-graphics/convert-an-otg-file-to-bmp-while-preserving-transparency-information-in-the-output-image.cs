// HOW-TO: Convert OTG to BMP with Transparency Preservation in C# (Aspose.Imaging for .NET)
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
        string outputPath = @"C:\Images\output.bmp";

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
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for OTG conversion
                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = otgImage.Size
                };

                // Set up BMP save options (default compression preserves transparency)
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterizationOptions
                };

                // Save as BMP
                otgImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to display vector OTG graphics in a Windows application that only supports BMP files while keeping the original transparent background.
 * 2. When converting batch OTG assets from a design system into BMPs for legacy printing pipelines that require raster images with an alpha channel.
 * 3. When exporting OTG diagrams from a CAD tool to BMP format for embedding in reports where the transparency must remain intact.
 * 4. When integrating Aspose.Imaging in a C# service that receives OTG uploads and must store them as BMPs for compatibility with third‑party image viewers.
 * 5. When automating image preprocessing to transform OTG icons into BMP thumbnails without losing their transparent edges.
 */
