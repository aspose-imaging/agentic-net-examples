// HOW-TO: Batch Crop Images To 16:9 Aspect Ratio And Convert To SVG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
            string inputDir = "input";
            string outputDir = "output";

            string[] files = Directory.GetFiles(inputDir);
            foreach (string inputFile in files)
            {
                if (!File.Exists(inputFile))
                {
                    Console.Error.WriteLine($"File not found: {inputFile}");
                    return;
                }

                using (Image img = Image.Load(inputFile))
                {
                    RasterImage raster = img as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputFile}");
                        return;
                    }

                    int width = raster.Width;
                    int height = raster.Height;
                    double targetAspect = 16.0 / 9.0;
                    double currentAspect = (double)width / height;

                    int cropX = 0, cropY = 0, cropWidth = width, cropHeight = height;

                    if (currentAspect > targetAspect)
                    {
                        // Image is too wide, crop width
                        cropWidth = (int)(height * targetAspect);
                        cropX = (width - cropWidth) / 2;
                    }
                    else if (currentAspect < targetAspect)
                    {
                        // Image is too tall, crop height
                        cropHeight = (int)(width / targetAspect);
                        cropY = (height - cropHeight) / 2;
                    }

                    if (cropWidth != width || cropHeight != height)
                    {
                        raster.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));
                    }

                    string outputFile = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputFile) + ".svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                    raster.Save(outputFile, new SvgOptions());
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
 * 1. When you need to automatically resize a large collection of photos to a widescreen 16:9 format before generating scalable SVG graphics for a web gallery.
 * 2. When a marketing team requires all product images to be uniformly cropped to 16:9 and exported as SVG files for responsive design in a C# application.
 * 3. When you are preparing screenshots for a presentation and must batch‑process them to a consistent 16:9 aspect and convert them to vector SVG for lossless scaling.
 * 4. When an e‑learning platform stores lesson illustrations as raster files and you need to crop them to 16:9 and convert them to SVG to reduce file size and improve rendering speed.
 * 5. When a desktop utility must scan an input folder, crop each image to a 16:9 frame, and save the result as SVG using Aspose.Imaging in .NET.
 */
