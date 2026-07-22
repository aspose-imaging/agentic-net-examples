using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.djvu";
            string outputPath = "output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                Rectangle exportArea = new Rectangle(100, 100, 200, 200);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(0, exportArea);
                djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to extract a specific region of a scanned DjVu document (e.g., a signature block) and save it as a high‑resolution TIFF for archival or OCR processing.
 * 2. When a legal‑tech application must convert only the relevant page portion of a multi‑page DjVu file into a TIFF to reduce file size while preserving the required content.
 * 3. When a publishing workflow requires cropping a defined rectangle from a DjVu illustration and exporting it as a TIFF for inclusion in a print‑ready PDF.
 * 4. When a document‑management system needs to generate a TIFF thumbnail of a particular area within a DjVu file for quick preview in a web portal.
 * 5. When a medical imaging solution must isolate a region of interest from a DjVu scan and convert that area to a TIFF format for compatibility with legacy analysis tools.
 */