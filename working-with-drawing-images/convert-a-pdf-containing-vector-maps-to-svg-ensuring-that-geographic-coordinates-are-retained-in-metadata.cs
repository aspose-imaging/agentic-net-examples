// HOW-TO: Convert PDF Vector Map to SVG While Preserving Geographic Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\map.pdf";
            string outputPath = "Output\\map.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var svgOptions = new SvgOptions
                {
                    KeepMetadata = true,
                    VectorRasterizationOptions = vectorOptions
                };

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
 * 1. When you need to display a PDF‑based map on a web page as scalable SVG while keeping the original latitude/longitude data in the file.
 * 2. When a GIS application requires converting vector map PDFs into SVG for interactive editing but must retain coordinate metadata for later georeferencing.
 * 3. When generating printable vector graphics from PDF maps for responsive design and you want the coordinate information to remain accessible for analytics.
 * 4. When integrating map PDFs into a mobile app that uses SVG rendering, and you must preserve the embedded geographic coordinates for location‑based features.
 * 5. When automating a batch process that transforms multiple PDF maps into SVG files while ensuring the metadata needed for spatial queries is not lost.
 */
