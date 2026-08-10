// HOW-TO: Increase Contrast of CDR File and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string tempTiffPath = "temp.tif";
            string outputPath = "output.tif";

            // Check input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document and rasterize to a temporary TIFF
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                TiffOptions rasterizeOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                cdr.Save(tempTiffPath, rasterizeOptions);
            }

            // Load the rasterized TIFF, adjust contrast, and save the final TIFF
            using (RasterImage raster = (RasterImage)Image.Load(tempTiffPath))
            {
                raster.AdjustContrast(50f);
                raster.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When you need to improve the visual clarity of a CorelDRAW (CDR) illustration before archiving it as a high‑resolution TIFF file.
 * 2. When converting a multi‑page CDR document to a raster image and applying a contrast boost for better print quality.
 * 3. When automating a workflow that extracts vector graphics from CDR files, rasterizes them, and enhances contrast for downstream image analysis.
 * 4. When preparing CDR artwork for OCR or machine‑vision systems that require TIFF input with increased contrast.
 * 5. When building a C# application that batch processes CDR files, adjusts their contrast, and stores the results in a lossless TIFF format.
 */
