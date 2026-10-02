// HOW-TO: Extract Second Page from Multipage TIFF to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\multipage.tif";
            string outputPath = "Output\\second_page.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (PngOptions options = new PngOptions())
            {
                options.MultiPageOptions = new MultiPageOptions(new IntRange(2, 1));
                image.Save(outputPath, options);
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
 * 1. When you need to generate a preview image of a specific page from a multi‑page scanned TIFF for display on a web page.
 * 2. When extracting a single page from a multi‑page medical imaging TIFF to a PNG for inclusion in a patient report.
 * 3. When converting the second page of a multi‑page fax TIFF into a lossless PNG to archive it separately.
 * 4. When processing a multi‑page TIFF of engineering drawings and you only require the second sheet as a PNG for a CAD review.
 * 5. When creating thumbnails for individual pages of a multi‑page TIFF and you want to isolate page two using Aspose.Imaging in a C# application.
 */
