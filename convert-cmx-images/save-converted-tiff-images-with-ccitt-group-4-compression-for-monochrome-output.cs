// HOW-TO: Convert TIFF to Monochrome CCITT Group 4 TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\input.tif";
            string outputPath = "Output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterCachedImage raster = (RasterCachedImage)image;
                if (!raster.IsCached) raster.CacheData();
                raster.BinarizeOtsu();

                using (TiffOptions options = new TiffOptions(TiffExpectedFormat.Default))
                {
                    options.Compression = TiffCompressions.CcittFax4;
                    options.Photometric = TiffPhotometrics.MinIsWhite;
                    raster.Save(outputPath, options);
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
 * 1. When you need to generate a black‑and‑white fax‑compatible TIFF from a scanned document for archival or transmission.
 * 2. When you must reduce the file size of high‑resolution scanned pages by applying CCITT Group 4 compression while preserving monochrome quality.
 * 3. When you are building a document‑processing pipeline that requires automatic binarization (Otsu) before saving images as printable TIFFs.
 * 4. When you need to ensure the output TIFF uses the MinIsWhite photometric setting for compatibility with legacy imaging systems.
 * 5. When you want to programmatically convert multi‑page or colored TIFFs to a single‑channel, compressed format for OCR preprocessing.
 */
