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
            string inputPath = "Input\\sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageNumber = 1;
                foreach (Image page in djvuImage.Pages)
                {
                    string outputPath = $"Output\\page_{pageNumber}.tif";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb))
                    {
                        page.Save(outputPath, tiffOptions);
                    }

                    pageNumber++;
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
 * 1. When a developer needs to archive scanned documents originally stored as DjVu files by converting each page to lossless TIFF with Deflate compression for long‑term storage.
 * 2. When a digital library system must provide TIFF downloads of DjVu manuscripts to users who require a widely supported format for printing or further processing.
 * 3. When an image‑processing pipeline has to extract individual pages from a multi‑page DjVu file and save them as compressed TIFF files for use in OCR engines.
 * 4. When a medical records application must transform DjVu‑based patient charts into TIFF images with Deflate compression to meet regulatory file‑format standards.
 * 5. When a batch‑conversion utility is required to read DjVu documents, convert each page to TIFF, and compress them to reduce disk space while preserving image quality.
 */