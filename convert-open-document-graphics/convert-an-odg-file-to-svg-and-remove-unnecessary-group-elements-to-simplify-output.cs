// HOW-TO: Convert ODG to SVG and Remove Metadata with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.odg";
            string outputPath = @"C:\Temp\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Remove metadata to simplify the SVG
                    KeepMetadata = false,
                    // Configure rasterization options required for vector conversion
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
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
 * 1. When you need to embed an OpenDocument graphics (ODG) illustration into a web page that only supports SVG, you can convert it using Aspose.Imaging in C#.
 * 2. When you want to reduce the size of an exported SVG by stripping metadata and unnecessary group elements after converting from ODG.
 * 3. When automating a batch job that transforms a library of ODG design assets into scalable SVG files for UI or printing workflows.
 * 4. When building a C# backend service that receives ODG uploads and must generate clean SVG output for downstream vector editing tools.
 * 5. When preparing ODG diagrams for inclusion in PDF reports that require vector graphics, you first convert them to SVG with Aspose.Imaging.
 */
