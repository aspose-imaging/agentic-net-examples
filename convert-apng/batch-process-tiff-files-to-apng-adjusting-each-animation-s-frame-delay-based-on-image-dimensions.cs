// HOW-TO: Batch Convert Multi‑Page TIFF to APNG with Dynamic Frame Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
                {
                    int maxWidth = 0;
                    int maxHeight = 0;
                    foreach (TiffFrame frame in tiff.Frames)
                    {
                        if (frame.Width > maxWidth) maxWidth = frame.Width;
                        if (frame.Height > maxHeight) maxHeight = frame.Height;
                    }

                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, maxWidth, maxHeight))
                    {
                        apng.RemoveAllFrames();

                        foreach (TiffFrame frame in tiff.Frames)
                        {
                            apng.AddFrame(frame);
                        }

                        apng.Save();
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
 * 1. When you need to automatically transform a folder of multi‑page TIFF scans into animated PNGs for web display.
 * 2. When you want to generate APNG files that preserve the largest frame dimensions across all TIFF pages.
 * 3. When you have to process thousands of medical or satellite TIFF images and output lightweight animated PNGs for mobile apps.
 * 4. When you need to ensure each APNG animation uses a consistent canvas size derived from the biggest TIFF frame.
 * 5. When you are building a C# batch job that converts legacy TIFF assets to modern APNG format without manual intervention.
 */
