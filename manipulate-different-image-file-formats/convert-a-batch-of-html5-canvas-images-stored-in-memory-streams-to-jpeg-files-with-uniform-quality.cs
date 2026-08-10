// HOW-TO: Convert Multiple HTML5 Canvas Files to JPEG with Fixed Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of input HTML5 Canvas files (stored as binary data)
            string[] inputPaths = new string[]
            {
                @"C:\Images\canvas1.html",
                @"C:\Images\canvas2.html",
                @"C:\Images\canvas3.html"
            };

            // Hard‑coded output directory
            string outputDir = @"C:\Images\Output";

            // Uniform JPEG quality (1‑100)
            int jpegQuality = 80;

            // Ensure the output directory exists (unconditional as required)
            Directory.CreateDirectory(outputDir);

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];

                // Verify input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the HTML5 Canvas file into a memory stream
                using (FileStream fileStream = File.OpenRead(inputPath))
                using (MemoryStream canvasStream = new MemoryStream())
                {
                    fileStream.CopyTo(canvasStream);
                    canvasStream.Position = 0; // reset for reading

                    // Load the image from the memory stream
                    using (Image image = Image.Load(canvasStream))
                    {
                        // Prepare JPEG save options with the desired quality
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = jpegQuality
                        };

                        // Build the output file path
                        string outputPath = Path.Combine(outputDir, $"canvas_{i + 1}.jpg");

                        // Ensure the output directory exists (unconditional)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the image as JPEG using the specified options
                        image.Save(outputPath, jpegOptions);
                    }
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
 * 1. When you need to generate JPEG thumbnails from a series of HTML5 canvas drawings stored on disk.
 * 2. When a web application exports canvas graphics as HTML files and you must batch‑convert them to JPEG for email attachments.
 * 3. When you want to archive canvas‑based artwork in a compressed, widely supported image format with consistent quality.
 * 4. When a reporting tool consumes JPEG images, so you must transform canvas output into JPEG before feeding the report.
 * 5. When you automate image processing pipelines that read canvas files from memory streams and output JPEGs for downstream systems.
 */
