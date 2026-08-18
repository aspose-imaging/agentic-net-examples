// HOW-TO: Flip DjVu Pages Horizontally and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.djvu";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    page.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.tiff");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    page.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When you need to batch‑process scanned DjVu documents, flip each page for correct orientation and archive them as high‑quality TIFF files using C#.
 * 2. When preparing DjVu files for OCR engines that require left‑to‑right page layout, you can horizontally flip the pages before converting them to TIFF.
 * 3. When migrating legacy DjVu archives to a TIFF‑based workflow, this code lets you automatically correct mirrored pages during the conversion.
 * 4. When building a document‑viewing application that displays pages in TIFF format, you may need to flip DjVu pages to match the viewer’s coordinate system.
 * 5. When creating print‑ready TIFF images from DjVu sources that were originally scanned upside‑down, the code ensures each page is mirrored correctly before saving.
 */
