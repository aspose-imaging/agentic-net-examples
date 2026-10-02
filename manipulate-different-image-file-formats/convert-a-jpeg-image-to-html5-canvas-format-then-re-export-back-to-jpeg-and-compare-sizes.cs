// HOW-TO: Convert JPEG To HTML5 Canvas And Back To JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string htmlPath = "temp.html";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(htmlPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Convert JPEG to HTML5 Canvas format
            using (Image jpegImage = Image.Load(inputPath))
            {
                Html5CanvasOptions htmlOptions = new Html5CanvasOptions
                {
                    Source = new FileCreateSource(htmlPath, false)
                };
                jpegImage.Save(htmlPath, htmlOptions);
            }

            // Convert HTML5 Canvas back to JPEG
            using (Image htmlImage = Image.Load(htmlPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    Quality = 90
                };
                htmlImage.Save(outputPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long finalSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Final size: {finalSize} bytes");
            Console.WriteLine($"Difference: {finalSize - originalSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed a JPEG image into a web page using an HTML5 canvas and later regenerate the JPEG for storage or further processing.
 * 2. When you want to compare the file size impact of converting a JPEG to canvas markup and back, to evaluate compression loss.
 * 3. When you are building a C# service that transforms images to HTML5 canvas format for client‑side editing and then restores them to JPEG.
 * 4. When you need to verify that round‑tripping an image through HTML5 canvas does not significantly alter its dimensions or quality.
 * 5. When you are automating batch processing to generate temporary HTML5 canvas files from JPEGs before applying additional canvas‑based manipulations.
 */
