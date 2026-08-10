// HOW-TO: Convert Large Multi‑Page CMX to PNG with Low Memory in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputDir = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the CMX image with a limited buffer size to reduce memory consumption
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 10 }))
            {
                int pageIndex = 0;
                foreach (Image page in cmx.Pages)
                {
                    pageIndex++;
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");

                    // Ensure the directory for the current output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as PNG
                    using (page)
                    {
                        page.Save(outputPath, new PngOptions());
                    }

                    // Release resources after each page to keep memory usage low
                    GC.Collect();
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
 * 1. When a .NET application must extract each page of a huge multi‑page CMX drawing and save them as PNGs without exhausting system memory.
 * 2. When processing batch conversions of legacy CorelDRAW CMX files on a server that has limited RAM, requiring page‑by‑page streaming.
 * 3. When generating thumbnails for individual pages of a large CMX document in a web service while keeping the process lightweight.
 * 4. When integrating Aspose.Imaging into a document‑management workflow that needs to archive each CMX page as a separate PNG file with minimal resource usage.
 * 5. When developing a desktop tool that allows users to preview CMX pages one at a time, converting them on demand to PNG to avoid loading the entire file into memory.
 */
