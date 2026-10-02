// HOW-TO: Extract DjVu Pages to Separate LZW Compressed TIFF Files in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\document.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = $"Output\\page_{i + 1}.tif";
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                    {
                        djvu.Pages[i].Save(outputPath, tiffOptions);
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
 * 1. When a digital archive needs to convert each page of a DjVu manuscript into high‑quality TIFF images for long‑term preservation.
 * 2. When a printing workflow requires individual LZW‑compressed TIFF files extracted from a multi‑page DjVu file to feed a raster image processor.
 * 3. When a document management system must split a DjVu e‑book into separate TIFF pages for OCR processing or indexing.
 * 4. When a legal firm wants to generate page‑by‑page TIFF copies of scanned contracts stored as DjVu for courtroom presentation.
 * 5. When a GIS application needs to transform DjVu map sheets into lossless TIFF tiles with LZW compression for further spatial analysis.
 */
