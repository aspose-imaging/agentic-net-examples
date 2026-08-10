// HOW-TO: Convert ODG to SVG with Correct ViewBox Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.svg";

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

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options with page size to set proper viewBox
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = odgImage.Size // ensures viewBox matches image dimensions
                };

                // Configure SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as SVG
                odgImage.Save(outputPath, svgOptions);
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
 * 1. When you need to display an OpenDocument graphics file on a web page, you can convert the .odg to scalable .svg while preserving the correct viewBox dimensions.
 * 2. When integrating a document processing pipeline that receives ODG drawings and must output vector graphics for a responsive UI, this code automates the conversion in C#.
 * 3. When migrating legacy design assets stored as ODG into an SVG‑based asset library, the snippet ensures the resulting files retain proper scaling information.
 * 4. When generating printable PDFs from SVG files that originated as ODG, setting the viewBox correctly avoids distortion during further conversions.
 * 5. When building a cross‑platform reporting tool that embeds ODG diagrams as SVG icons, the code provides a reliable way to convert and embed them with accurate size metadata.
 */
