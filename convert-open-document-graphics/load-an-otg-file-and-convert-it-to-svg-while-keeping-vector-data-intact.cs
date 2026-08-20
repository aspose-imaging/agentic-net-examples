// HOW-TO: Convert OTG File to SVG Preserving Vector Data in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output paths
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
                // Configure SVG export options
                var svgOptions = new SvgOptions();

                // Set vector rasterization options so that vector data is preserved
                var svgRasterization = new SvgRasterizationOptions
                {
                    PageSize = image.Size // preserve original page size
                };
                svgOptions.VectorRasterizationOptions = svgRasterization;

                // Save the image as SVG
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
 * 1. When you need to display or edit a CAD‑like OTG drawing on the web, converting it to SVG keeps the vector shapes editable in browsers.
 * 2. When generating printable graphics from OTG files for high‑resolution output, saving as SVG retains the original dimensions and vector quality.
 * 3. When integrating legacy OTG assets into a modern C# application that uses scalable vector graphics, this code enables seamless import and conversion.
 * 4. When creating responsive UI components that must scale without pixelation, converting OTG to SVG preserves vector data for smooth resizing.
 * 5. When automating a batch process that extracts vector artwork from OTG files for use in documentation or marketing materials, this routine provides reliable C# conversion while maintaining page size.
 */
