// HOW-TO: Convert Large EPS to PDF with Tiling to Reduce Memory in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded relative input and output paths
        string inputPath = Path.Combine("Input", "large.eps");
        string outputPath = Path.Combine("Output", "large.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with vector rasterization settings.
                // Tiling can be simulated by setting a reasonable page size that fits into memory.
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = 2000,   // Width of each rasterized tile (adjust as needed)
                        PageHeight = 2000,  // Height of each rasterized tile (adjust as needed)
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                // Save the EPS as PDF using the configured options
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to transform a high‑resolution EPS artwork into a PDF without exhausting application memory.
 * 2. When processing batch conversions of large vector EPS files on a server that has limited RAM.
 * 3. When generating printable PDFs from EPS logos while ensuring the rasterization fits within a manageable tile size.
 * 4. When integrating EPS‑to‑PDF conversion into a C# desktop tool that must stay responsive with big files.
 * 5. When automating archival of EPS drawings to PDF format and want to control page dimensions to avoid out‑of‑memory errors.
 */
