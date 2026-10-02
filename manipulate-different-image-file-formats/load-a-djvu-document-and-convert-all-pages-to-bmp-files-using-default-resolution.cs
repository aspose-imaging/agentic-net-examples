// HOW-TO: Convert DjVu Document to BMP Images Page by Page in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");
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
 * 1. When you need to extract each page of a DjVu file as a separate BMP for legacy Windows applications.
 * 2. When you want to batch‑convert scanned DjVu archives into BMP format for OCR preprocessing.
 * 3. When a printing workflow requires BMP files because the downstream printer driver does not support DjVu.
 * 4. When you are archiving documents and need BMP copies of every DjVu page to preserve pixel‑perfect fidelity.
 * 5. When you develop a document viewer that stores each DjVu page as a BMP thumbnail for quick preview.
 */
