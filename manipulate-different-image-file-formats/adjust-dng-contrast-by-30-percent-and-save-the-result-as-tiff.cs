// HOW-TO: Adjust DNG Contrast by 30 Percent and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)dng;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustContrast(0.3f);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When a photographer needs to increase the contrast of a raw DNG file before archiving it as a high‑resolution TIFF for print production.
 * 2. When a scientific imaging application must enhance the visibility of details in a DNG capture and store the result in a lossless TIFF for downstream analysis.
 * 3. When a mobile app backend processes raw camera uploads, applies a 30 % contrast boost, and converts them to TIFF for compatibility with legacy image pipelines.
 * 4. When a digital asset management system requires automated conversion of raw DNG assets to TIFF while standardizing contrast across the collection.
 * 5. When a developer builds a batch‑processing tool that reads DNG files, adjusts their contrast using Aspose.Imaging, and saves the edited images as TIFF for archival storage.
 */
