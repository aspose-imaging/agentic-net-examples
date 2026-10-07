// HOW-TO: Convert Multi‑Page DjVu to 32‑Bit BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\document.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        djvu.Pages[i].Save(outputPath, bmpOptions);
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
 * 1. When you need to extract each page of a DjVu document as a high‑color BMP file for legacy Windows applications.
 * 2. When a batch conversion tool must preserve the original page layout while generating 32‑bit BMPs for further image analysis.
 * 3. When integrating DjVu support into a .NET service that supplies BMP thumbnails to a document management system.
 * 4. When automating the preparation of DjVu pages for printing on devices that only accept BMP format with full color depth.
 * 5. When creating a migration pipeline that converts archived DjVu files into BMPs to store them in a file system that does not support DjVu.
 */
