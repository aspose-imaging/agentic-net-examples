// HOW-TO: Convert JPEG to HTML5 Canvas and Back to JPEG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputPath = @"C:\temp\input.jpg";
            string htmlPath = @"C:\temp\output.html";
            string reExportPath = @"C:\temp\reexport.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(htmlPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reExportPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save as HTML5 Canvas
                var htmlOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = true,
                    CanvasTagId = "canvas1"
                };
                image.Save(htmlPath, htmlOptions);
            }

            // Re‑export back to JPEG (using the original image as source)
            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 100
                };
                image.Save(reExportPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long reExportSize = new FileInfo(reExportPath).Length;
            Console.WriteLine($"Original JPEG size: {originalSize} bytes");
            Console.WriteLine($"Re‑exported JPEG size: {reExportSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate an HTML5 canvas preview of a JPEG for web display while preserving the original image data.
 * 2. When you want to embed a JPEG into a full HTML page using Aspose.Imaging and later re‑export it to JPEG for storage or further processing.
 * 3. When you must compare the file size of the original JPEG with a re‑exported version to assess any size changes caused by conversion.
 * 4. When building a C# application that converts uploaded JPEGs to canvas‑based HTML for client‑side editing and then saves the edited result back as JPEG.
 * 5. When testing the fidelity and compression impact of round‑tripping a JPEG through HTML5 canvas format using Aspose.Imaging in .NET.
 */
