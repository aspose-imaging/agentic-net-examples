using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of EPS files to process
            string[] inputPaths = { "sample1.eps", "sample2.eps" };
            // Hardcoded output directory
            string outputDir = "converted";

            var report = new StringBuilder();
            report.AppendLine("EPS Conversion Report");
            report.AppendLine("----------------------");

            foreach (var inputPath in inputPaths)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Extract useful metadata
                    string creator = image.Creator ?? "N/A";
                    DateTime creationDate = image.CreationDate;
                    string title = image.Title ?? "N/A";
                    int width = image.Width;
                    int height = image.Height;

                    // Determine output PNG path
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure rasterization options for EPS to PNG conversion
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new EpsRasterizationOptions
                        {
                            PageWidth = width,
                            PageHeight = height
                        }
                    };

                    // Save the image as PNG
                    image.Save(outputPath, pngOptions);

                    // Append details to the report
                    report.AppendLine($"Input: {inputPath}");
                    report.AppendLine($"  Creator: {creator}");
                    report.AppendLine($"  CreationDate: {creationDate}");
                    report.AppendLine($"  Title: {title}");
                    report.AppendLine($"  Dimensions: {width}x{height}");
                    report.AppendLine($"  Output: {outputPath}");
                    report.AppendLine();
                }
            }

            // Output the conversion report
            Console.WriteLine(report.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert company EPS logos into PNGs for a website while capturing creator and creation date information for an audit report.
 * 2. When an e‑commerce platform must transform EPS product illustrations into PNG thumbnails and log each file’s title, dimensions, and source metadata for inventory tracking.
 * 3. When a publishing workflow requires converting EPS artwork to PNG for print‑to‑digital pipelines and generating a summary that records the original page size and author details.
 * 4. When a mobile app team wants to rasterize EPS icons to PNG assets at their native resolution and produce a conversion log to verify that all expected files were processed.
 * 5. When a document management system needs to archive EPS diagrams as PNG previews and store a concise report containing file paths, image dimensions, and metadata for future retrieval.
 */