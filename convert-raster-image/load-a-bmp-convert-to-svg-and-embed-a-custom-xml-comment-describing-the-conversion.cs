// HOW-TO: Convert BMP to SVG and Add XML Comment in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample_converted.svg";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options matching the source size
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Embed a custom XML comment describing the conversion
            string comment = $"<!-- Converted from BMP to SVG using Aspose.Imaging on {DateTime.Now:u} -->{Environment.NewLine}";
            string svgContent = File.ReadAllText(outputPath);
            File.WriteAllText(outputPath, comment + svgContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to transform legacy BMP graphics into scalable SVG files for web display while preserving the original dimensions.
 * 2. When you want to programmatically embed a timestamped XML comment into an SVG to document the conversion process for audit purposes.
 * 3. When an automated build pipeline must convert a batch of BMP assets to SVG format and include conversion metadata for downstream tools.
 * 4. When integrating image conversion into a C# desktop application that requires raster‑to‑vector conversion and custom documentation inside the SVG.
 * 5. When generating SVG assets from BMP sources for responsive design and need to include conversion details for future maintenance.
 */
