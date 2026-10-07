// HOW-TO: Extract All Frames From Multi‑Page TIFF And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.tif";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int frameCount = tiffImage.Frames.Count();
                for (int i = 0; i < frameCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        tiffImage.Frames[i].Save(outputPath, bmpOptions);
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
 * 1. When you need to convert each page of a multi‑page TIFF document into separate BMP files for legacy Windows applications.
 * 2. When you must extract individual frames from a scanned TIFF file to process them separately in a .NET image‑processing pipeline.
 * 3. When a reporting system requires BMP images for high‑quality printing and you have source images stored as multi‑page TIFFs.
 * 4. When you are building a batch conversion tool that archives each TIFF page as an uncompressed BMP for archival compliance.
 * 5. When you need to programmatically split a multi‑frame medical image (TIFF) into BMP slices for analysis with third‑party diagnostic software.
 */
