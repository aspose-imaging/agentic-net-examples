// HOW-TO: Batch Convert SVG Files to High‑Resolution JPEG with 95% Quality in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputJpegs";

            // List of SVG files to process (add or modify as needed)
            string[] svgFiles = new[]
            {
                "image1.svg",
                "image2.svg",
                "image3.svg"
            };

            foreach (var fileName in svgFiles)
            {
                // Build full paths
                string inputPath = Path.Combine(inputFolder, fileName);
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(fileName) + ".jpg");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare JPEG save options with high quality
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 95,
                        // Rasterize the vector SVG at its original size (high‑resolution)
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }
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
 * 1. When you need to generate web‑ready JPEG thumbnails from a set of SVG logos while preserving visual fidelity.
 * 2. When an e‑commerce platform must rasterize vector product illustrations into high‑resolution JPEGs for print catalogs.
 * 3. When a reporting tool requires converting SVG charts into JPEG images for inclusion in PDF documents.
 * 4. When a batch processing script must automate the conversion of design assets from SVG to JPEG with a specific quality setting.
 * 5. When a legacy system only accepts JPEG files, and you must programmatically transform SVG icons to JPEGs at 95% quality.
 */
