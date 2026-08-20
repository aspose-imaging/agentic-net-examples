// HOW-TO: Convert OTG to SVG and Strip Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
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
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Remove metadata to reduce unnecessary elements
                    KeepMetadata = false,
                    // Configure rasterization (page size matches source)
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
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
 * 1. When you need to embed an OTG diagram into a web page, converting it to lightweight SVG while removing metadata reduces file size and improves load times.
 * 2. When automating a batch process that extracts vector graphics from legacy OTG files for use in modern design tools, this code generates clean SVG files ready for editing.
 * 3. When creating printable PDFs from OTG assets, converting to SVG first ensures resolution‑independent graphics and the stripped metadata avoids unnecessary PDF bloat.
 * 4. When integrating OTG images into a mobile app, converting to SVG with Aspose.Imaging in C# provides scalable icons that consume less memory on the device.
 * 5. When preparing OTG artwork for SEO‑friendly web publishing, exporting to SVG and removing group elements simplifies the markup, making it easier for search engines to index.
 */
