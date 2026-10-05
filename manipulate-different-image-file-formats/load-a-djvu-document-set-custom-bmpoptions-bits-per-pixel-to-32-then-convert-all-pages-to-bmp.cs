// HOW-TO: Convert DjVu Document Pages to 32‑Bit BMP Images in C# (Aspose.Imaging for .NET)
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
                    var page = djvu.Pages[i];
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        page.Save(outputPath, bmpOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑color‑depth BMP files for further editing in Windows graphics tools.
 * 2. When a legacy application only accepts BMP images, you can programmatically convert DjVu documents to 32‑bit BMPs before importing them.
 * 3. When automating a batch process that archives scanned documents, converting DjVu pages to BMP ensures compatibility with systems that do not support DjVu.
 * 4. When preparing DjVu content for printing on devices that require BMP format, you can generate per‑page BMP files with Aspose.Imaging in C#.
 * 5. When performing image analysis on individual DjVu pages, converting each page to BMP allows you to use standard .NET image libraries that work with BMP data.
 */
