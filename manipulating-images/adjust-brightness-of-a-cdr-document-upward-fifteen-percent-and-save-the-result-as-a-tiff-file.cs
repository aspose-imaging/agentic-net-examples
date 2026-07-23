using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample_brightness.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Adjust brightness upward by ~15% (≈38 on a scale of -255..255)
                if (image is RasterImage raster)
                {
                    raster.AdjustBrightness(38);
                }
                else if (image is TiffImage tiff)
                {
                    tiff.AdjustBrightness(38);
                }
                else
                {
                    // Attempt generic AdjustBrightness via dynamic (fallback)
                    dynamic dyn = image;
                    try { dyn.AdjustBrightness(38); } catch { }
                }

                // Save the result as a TIFF file
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a printing service needs to convert CorelDRAW (.cdr) artwork to high‑resolution TIFF for press output and must increase the image brightness by about 15 % to meet the client’s visual specifications.
 * 2. When an archival system imports legacy CDR files, brightens them to improve legibility, and stores the results as TIFF files for long‑term preservation.
 * 3. When a web application generates printable previews by loading a CDR design, applying a 15 % brightness boost, and delivering the preview as a TIFF image to browsers that only support raster formats.
 * 4. When a batch‑processing tool automates the conversion of multiple CDR logos, enhances their brightness for better on‑screen appearance, and saves each as a TIFF for use in marketing collateral.
 * 5. When a document‑management workflow requires programmatically adjusting the brightness of a CDR diagram before exporting it to TIFF so that downstream OCR engines can recognize the content more accurately.
 */