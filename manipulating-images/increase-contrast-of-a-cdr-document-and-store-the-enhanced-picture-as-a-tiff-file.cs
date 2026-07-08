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
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_contrast.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (CDR)
            using (Image image = Image.Load(inputPath))
            {
                // Adjust contrast depending on the actual image type
                if (image is RasterImage rasterImage)
                {
                    // Contrast value in range [-100, 100]
                    rasterImage.AdjustContrast(50f);
                }
                else if (image is TiffImage tiffImage)
                {
                    tiffImage.AdjustContrast(50f);
                }
                else
                {
                    // Fallback: try casting to RasterImage
                    ((RasterImage)image).AdjustContrast(50f);
                }

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the enhanced image as TIFF
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
 * 1. When a graphic designer needs to batch‑process CorelDRAW (.cdr) files to improve visual clarity before sending them to a print shop that requires high‑contrast TIFF images.
 * 2. When an archival system converts legacy CDR drawings into lossless TIFF format while enhancing contrast to ensure details are preserved for long‑term storage.
 * 3. When a document management workflow automatically adjusts the contrast of scanned CDR schematics so that the resulting TIFF files are easier to read on low‑resolution monitors.
 * 4. When a web service generates preview thumbnails of CDR artwork, increasing contrast and exporting them as TIFF to meet client specifications for image quality.
 * 5. When a quality‑control application validates CDR logos by boosting contrast and saving them as TIFF to compare against reference images in automated testing.
 */