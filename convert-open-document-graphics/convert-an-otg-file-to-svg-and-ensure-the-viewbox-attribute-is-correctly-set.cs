// HOW-TO: Convert OTG to SVG with Correct ViewBox in C# (Aspose.Imaging for .NET)
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
        string outputPath = @"C:\Images\sample.svg";

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
                // Prepare SVG options with proper viewBox (PageSize)
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size // Sets the viewBox to match the source dimensions
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
 * 1. When a developer needs to display legacy OTG graphics on a web page, they can convert the file to SVG and preserve the original dimensions using the viewBox attribute.
 * 2. When integrating a document processing pipeline that receives OTG files, converting them to scalable SVG ensures the images remain crisp at any resolution.
 * 3. When creating a batch job that prepares assets for responsive design, the code can automatically set the SVG viewBox to match the source size for proper scaling.
 * 4. When migrating an old CAD or vector drawing library to modern formats, converting OTG to SVG with Aspose.Imaging simplifies the transition while keeping accurate geometry.
 * 5. When building a C# application that generates printable PDFs from vector sources, converting OTG to SVG with a correctly set viewBox allows seamless embedding into PDF pages.
 */
