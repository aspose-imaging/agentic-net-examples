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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure OTG rasterization options to preserve original page size
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up SVG save options and assign the vector rasterization options
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // Save the image as SVG, preserving vector layers and attributes
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
 * 1. When a GIS application needs to convert proprietary OTG map tiles into scalable SVG files for web display while preserving all vector layers and attributes using Aspose.Imaging for .NET.
 * 2. When an engineering firm wants to automate batch conversion of OTG CAD drawings to SVG for inclusion in interactive product documentation, keeping the original vector hierarchy intact.
 * 3. When a digital publishing platform must transform OTG illustrations into responsive SVG graphics for e‑books, ensuring that vector attributes and layer information are retained.
 * 4. When a data‑visualization tool requires converting OTG charts into SVG so that client‑side CSS styling and JavaScript manipulation can be applied without losing vector details.
 * 5. When a legacy archival system needs to migrate OTG assets to an open‑format SVG repository while preserving layer structure and metadata through C# image processing code.
 */