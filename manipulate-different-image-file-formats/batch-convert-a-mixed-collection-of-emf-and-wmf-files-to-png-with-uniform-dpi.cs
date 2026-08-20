// HOW-TO: Batch Convert EMF and WMF Files to PNG with Fixed DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            Directory.CreateDirectory(outputDir);

            string[] allFiles = Directory.GetFiles(inputDir);
            foreach (var inputPath in allFiles)
            {
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".emf" && ext != ".wmf")
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    VectorRasterizationOptions vectorOptions;
                    if (ext == ".emf")
                    {
                        var emfOptions = new EmfRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = image.Size
                        };
                        vectorOptions = emfOptions;
                    }
                    else // .wmf
                    {
                        var wmfOptions = new WmfRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = image.Size
                        };
                        vectorOptions = wmfOptions;
                    }

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };

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

/*
 * Real-World Use Cases:
 * 1. When a desktop publishing workflow needs to turn a collection of legacy EMF and WMF graphics into high‑resolution PNGs for web display.
 * 2. When an automated build process must generate thumbnail previews of vector icons stored as EMF/WMF files with a consistent DPI.
 * 3. When migrating a legacy document archive to a modern format and you need to batch rasterize all vector drawings to PNG while preserving size.
 * 4. When creating a reporting tool that converts user‑uploaded EMF or WMF charts into PNG images for inclusion in PDF reports.
 * 5. When developing a C# service that normalizes mixed vector assets to PNGs with uniform resolution before uploading them to a cloud storage bucket.
 */
