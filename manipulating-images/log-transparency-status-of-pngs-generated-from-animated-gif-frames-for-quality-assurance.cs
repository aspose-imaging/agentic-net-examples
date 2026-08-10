// HOW-TO: Check Transparency of PNGs Extracted from Animated GIF Frames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameCount = gif.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    // Activate current frame
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    bool gifHasTransparent = gif.HasTransparentColor;

                    string outputPath = Path.Combine(outputDir, $"frame_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare PNG options with bound source
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    // Create PNG image canvas
                    using (RasterImage png = (RasterImage)Image.Create(pngOptions, gif.Width, gif.Height))
                    {
                        // Copy pixel data from GIF frame to PNG
                        int[] pixels = ((RasterImage)gif).LoadArgb32Pixels(gif.Bounds);
                        png.SaveArgb32Pixels(gif.Bounds, pixels);

                        // Save the PNG (source already bound)
                        png.Save();

                        bool pngHasAlpha = png.HasAlpha;

                        Console.WriteLine($"Frame {i}: GIF Transparent={gifHasTransparent}, PNG HasAlpha={pngHasAlpha}");
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
 * 1. When you need to verify that each frame extracted from an animated GIF retains its original transparency after conversion to PNG for quality assurance.
 * 2. When building an automated pipeline that converts GIF animations to individual PNG images and must log whether the resulting PNGs contain an alpha channel.
 * 3. When performing regression testing on image processing code to ensure that transparent pixels are not lost during GIF‑to‑PNG frame extraction in a .NET application.
 * 4. When generating assets for web or mobile apps and you need to confirm that transparent backgrounds are preserved after splitting an animated GIF into separate PNG files.
 * 5. When creating a reporting tool that audits a batch of GIF animations, extracts each frame as PNG, and records the transparency status for compliance or documentation purposes.
 */
