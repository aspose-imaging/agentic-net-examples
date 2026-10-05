// HOW-TO: Convert Multiple CDR Files to Dithered PNG and Merge into Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "Input/file1.cdr";
            string inputPath2 = "Input/file2.cdr";
            string inputPath3 = "Input/file3.cdr";
            string outputPath = "Output/combined.tif";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            var inputPaths = new[] { inputPath1, inputPath2, inputPath3 };
            var frames = new List<Image>();

            foreach (var inputPath in inputPaths)
            {
                using (var cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        }
                    };

                    using (var ms = new MemoryStream())
                    {
                        cdrImage.Save(ms, pngOptions);
                        ms.Position = 0;
                        var rasterImage = Image.Load(ms);
                        frames.Add(rasterImage);
                    }
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var multipageImage = Image.Create(frames.ToArray(), true))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                multipageImage.Save(outputPath, tiffOptions);
            }

            foreach (var img in frames)
            {
                img.Dispose();
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
 * 1. When a developer needs to batch‑process CorelDRAW (CDR) drawings, apply dithering, and generate a single multi‑page TIFF for printing or archival.
 * 2. When an application must convert vector CDR artwork to raster PNG images with a white background before combining them into a TIFF document.
 * 3. When a document management system requires merging several CDR‑derived images into one multipage TIFF to reduce file count and simplify storage.
 * 4. When a reporting tool has to embed multiple vector graphics into a TIFF report while preserving image quality through dithering.
 * 5. When a migration script must transform legacy CDR files into a TIFF format compatible with downstream .NET image‑processing pipelines.
 */
