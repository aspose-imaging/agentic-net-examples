// HOW-TO: Convert BMP Image to PDF and Stream to HTTP Response in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Simulated HTTP response stream (replace with actual response stream in real scenario)
                using (Stream responseStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    // Save image as PDF directly to the response stream
                    image.Save(responseStream, new PdfOptions());
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
 * 1. When you need to serve a dynamically generated PDF version of a BMP picture directly to a web browser without creating a temporary file.
 * 2. When an ASP.NET application must convert uploaded BMP scans into PDF documents for download or email attachment on the fly.
 * 3. When a web service provides on‑the‑fly image format conversion, turning BMP assets into PDF for compliance or printing purposes.
 * 4. When you want to embed BMP graphics into a PDF report and send it as part of an HTTP response in a REST API.
 * 5. When a server‑side process must convert legacy BMP files to PDF and stream them to clients to reduce disk I/O and improve performance.
 */
