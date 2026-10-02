// HOW-TO: Crop a 200x200 Area from a TIFF Image and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.tif";
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = "output/output.tif";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    Rectangle cropRect = new Rectangle(0, 0, 200, 200);
                    raster.Crop(cropRect);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a specific 200 × 200 pixel region from a multi‑page TIFF for thumbnail generation in a C# web service.
 * 2. When a desktop application must trim the edges of scanned documents stored as TIFF files before archiving them.
 * 3. When an automated batch job processes incoming TIFF scans, crops a fixed area, and saves the result for downstream OCR analysis.
 * 4. When a cloud function receives a TIFF stream, removes unwanted margins by cropping, and returns the cropped image as a new TIFF.
 * 5. When a reporting tool requires a small, uniformly sized TIFF snippet to embed in PDF reports generated with .NET.
 */
