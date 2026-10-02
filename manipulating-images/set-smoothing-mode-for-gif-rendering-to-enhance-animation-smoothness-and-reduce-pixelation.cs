// HOW-TO: How To Apply Anti-Alias Smoothing To GIFs In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using System.Drawing.Drawing2D;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var saveOptions = new GifOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

                image.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce pixelation in animated GIFs generated from vector graphics by applying anti‑alias smoothing during saving with Aspose.Imaging in C#.
 * 2. When creating a web‑ready GIF slideshow and want smoother transitions between frames without manually editing each image.
 * 3. When converting high‑resolution vector drawings to GIF format and require the output to retain visual quality on low‑resolution displays.
 * 4. When optimizing GIF assets for mobile apps where anti‑aliased rendering improves perceived animation smoothness.
 * 5. When automating a batch process that re‑saves existing GIF files with enhanced smoothing to meet branding guidelines for crisp visuals.
 */
