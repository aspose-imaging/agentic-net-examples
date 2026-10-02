// HOW-TO: Convert DjVu Document to Multipage TIFF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
        string inputPath = "input.djvu";
        string outputPath = "output\\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                djvu.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive scanned DjVu files as a single multipage TIFF for compatibility with legacy document management systems.
 * 2. When a printing workflow requires converting DjVu ebooks into TIFF format to preserve each page in one file for batch processing.
 * 3. When you want to generate a multipage TIFF from a DjVu document to embed it into a PDF or Word report that only supports TIFF images.
 * 4. When an image analysis tool only accepts TIFF input, you can convert DjVu pages to a multipage TIFF before running the analysis.
 * 5. When migrating a digital library from DjVu to a format supported by Windows imaging components, you can batch convert each DjVu file to a multipage TIFF.
 */
