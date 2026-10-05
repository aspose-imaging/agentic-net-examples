// HOW-TO: Extract a 300x300 Region from DjVu and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                Aspose.Imaging.Rectangle area = new Aspose.Imaging.Rectangle(50, 50, 300, 300);
                int pageIndex = 0;

                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pageIndex, area);
                PngOptions pngOptions = new PngOptions
                {
                    MultiPageOptions = multiPageOptions
                };

                djvu.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a thumbnail of a specific area of a DjVu document for a web preview.
 * 2. When extracting a diagram or figure from a multi‑page DjVu file to embed it in a report as a PNG image.
 * 3. When processing scanned legal documents and you only require a particular page region for OCR preprocessing.
 * 4. When creating a preview of a selected portion of a DjVu slide for a presentation without converting the whole file.
 * 5. When building a batch tool that crops and converts DjVu pages to PNGs for archival or publishing workflows.
 */
