// HOW-TO: Blend Two Images with 50% Opacity Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string overlayPath = "overlay.png";
            string outputPath = "output.png";

            // Validate input files
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background image from memory stream
            using (FileStream inputFileStream = File.OpenRead(inputPath))
            using (MemoryStream inputMemoryStream = new MemoryStream())
            {
                inputFileStream.CopyTo(inputMemoryStream);
                inputMemoryStream.Position = 0;

                using (RasterImage background = (RasterImage)Image.Load(inputMemoryStream))
                {
                    // Load overlay image from memory stream
                    using (FileStream overlayFileStream = File.OpenRead(overlayPath))
                    using (MemoryStream overlayMemoryStream = new MemoryStream())
                    {
                        overlayFileStream.CopyTo(overlayMemoryStream);
                        overlayMemoryStream.Position = 0;

                        using (RasterImage overlay = (RasterImage)Image.Load(overlayMemoryStream))
                        {
                            // Apply alpha blending (50% opacity)
                            background.Blend(new Point(0, 0), overlay, 128);
                        }
                    }

                    // Save blended image to output memory stream
                    using (MemoryStream outputMemoryStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.Source = new StreamSource(outputMemoryStream, true);
                        background.Save(outputMemoryStream, pngOptions);

                        // Write memory stream to file
                        outputMemoryStream.Position = 0;
                        using (FileStream outputFileStream = new FileStream(outputPath, FileMode.Create))
                        {
                            outputMemoryStream.CopyTo(outputFileStream);
                        }
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
 * 1. When you need to overlay a transparent PNG logo onto a JPEG photograph in a web service without writing temporary files.
 * 2. When generating dynamic watermarks for PDF thumbnails by blending a semi‑transparent image onto the source image in memory.
 * 3. When creating composite product images for an e‑commerce catalog by merging background and foreground images with 50 % opacity using C#.
 * 4. When processing user‑uploaded images in an ASP.NET API and applying an alpha‑blended filter before saving the result as PNG.
 * 5. When building a batch image‑processing tool that reads images from streams, blends them, and streams the combined PNG to another system.
 */
