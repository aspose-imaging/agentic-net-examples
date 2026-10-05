// HOW-TO: Batch Rotate TIFF Images 90 Degrees and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace TiffBatchProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "input";
                string outputDirectory = "output";

                var tiffFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.AllDirectories)
                    .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase));

                foreach (var inputPath in tiffFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string relativePath = Path.GetRelativePath(inputDirectory, inputPath);
                    string outputPath = Path.ChangeExtension(Path.Combine(outputDirectory, relativePath), ".png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var image = Image.Load(inputPath))
                    {
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically re‑orient a large collection of scanned TIFF documents and deliver them as web‑friendly PNG files.
 * 2. When a migration script must convert legacy multi‑page TIFF archives to single‑page PNG images while applying a 90° rotation for correct display.
 * 3. When an image‑processing pipeline has to process all TIFF files in nested folders, rotate them, and store the results in a separate output directory preserving the folder structure.
 * 4. When you want to use Aspose.Imaging in a C# application to batch‑convert medical imaging TIFFs to PNG after correcting orientation for downstream analysis.
 * 5. When a desktop utility must read TIFF files, apply a clockwise rotation, and save them as lossless PNGs for inclusion in a PDF report.
 */
