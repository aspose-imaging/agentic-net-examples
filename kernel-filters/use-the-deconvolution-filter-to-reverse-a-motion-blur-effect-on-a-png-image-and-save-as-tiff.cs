using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.tif";

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

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply motion deblurring filter (deconvolution) to reverse motion blur
                // Parameters: length, smooth value, angle (example values)
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                // Save the processed image as TIFF
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
 * 1. When a developer needs to reverse motion blur in a PNG photograph taken from a moving camera and save the restored image as a high‑quality TIFF for archival purposes.
 * 2. When an application must preprocess scanned PNG documents that suffered motion blur during scanning, applying a deconvolution filter before converting them to TIFF for OCR processing.
 * 3. When a web service receives user‑uploaded PNG images with motion blur, uses Aspose.Imaging in C# to deblur them and returns the result as a TIFF for downstream printing workflows.
 * 4. When a medical imaging tool requires cleaning up motion‑blurred PNG scans of slides and storing the corrected images in TIFF format to preserve diagnostic detail.
 * 5. When a developer automates batch processing of PNG assets from a video game, removing motion blur with a Wiener filter and exporting them as TIFF files for texture atlasing.
 */