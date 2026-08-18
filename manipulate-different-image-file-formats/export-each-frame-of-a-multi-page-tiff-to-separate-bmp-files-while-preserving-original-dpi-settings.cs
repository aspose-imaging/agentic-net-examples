// HOW-TO: Export Each Frame of Multi‑Page TIFF to Separate BMP Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\multipage.tif";
            string outputDir = @"C:\Images\Frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                for (int i = 0; i < tiff.Frames.Length; i++)
                {
                    tiff.ActiveFrame = tiff.Frames[i];
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions bmpOptions = new BmpOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    tiff.Save(outputPath, bmpOptions);
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
 * 1. When you need to split a scanned multi‑page document saved as TIFF into individual BMP images for legacy Windows applications that only accept BMP format.
 * 2. When preserving the original DPI of each page is required for accurate printing or measurement after converting a multi‑page TIFF into separate bitmap files.
 * 3. When automating a batch process that extracts every frame from a multi‑page TIFF archive and stores them as BMP files for further analysis in a .NET image‑processing pipeline.
 * 4. When integrating Aspose.Imaging in a C# service that converts medical imaging TIFF stacks into BMP frames while keeping the resolution metadata intact.
 * 5. When creating thumbnails or rasterized copies of each page in a multi‑page TIFF for a document management system that stores images as BMP to ensure compatibility with older viewers.
 */
