// HOW-TO: Save PSD as PNG with High Quality Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            if (outputDir != null)
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.HighQuality,
                        TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a Photoshop PSD file to a PNG for web display while preserving smooth edges and text clarity.
 * 2. When generating thumbnails from layered PSD artwork and want high-quality anti-aliasing rendering in C#.
 * 3. When exporting design assets from PSD to PNG for print-ready PDFs and require vector rasterization with high smoothing.
 * 4. When building an automated pipeline that processes PSD files and saves them as PNGs with consistent visual fidelity across different devices.
 * 5. When creating a desktop application that loads PSD files and saves them as PNGs with high-quality smoothing to improve the appearance of UI icons.
 */
