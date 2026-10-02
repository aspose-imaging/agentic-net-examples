// HOW-TO: Batch Dither TIFF Images to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in files)
            {
                string ext = Path.GetExtension(filePath).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                string inputPath = filePath;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage raster)
                    {
                        raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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

/*
 * Real-World Use Cases:
 * 1. When you need to convert a collection of high‑resolution TIFF scans into web‑friendly PNGs while applying Floyd‑Steinberg dithering to preserve visual detail.
 * 2. When an automated workflow must process all TIFF files in a directory and output dithered PNGs for archival or publishing pipelines.
 * 3. When you want to reduce file size of TIFF images by dithering them to an 8‑bit palette before saving as PNG in a .NET application.
 * 4. When a desktop utility has to batch‑process scanned documents, applying raster dithering and converting them to PNG for compatibility with browsers.
 * 5. When integrating Aspose.Imaging into a C# service that monitors a folder, converts each new TIFF to a dithered PNG, and stores the results in an output directory.
 */
