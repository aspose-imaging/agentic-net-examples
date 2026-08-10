// HOW-TO: Align Horizontal and Vertical DPI of TIFF and Raster Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Align DPI for TIFF images using the built‑in helper
                if (image is TiffImage tiffImage)
                {
                    tiffImage.AlignResolutions();
                }
                // Align DPI for other raster images
                else if (image is RasterImage rasterImage)
                {
                    double hDpi = rasterImage.HorizontalResolution;
                    double vDpi = rasterImage.VerticalResolution;

                    if (hDpi != vDpi)
                    {
                        // Use the larger DPI to avoid down‑scaling
                        double targetDpi = Math.Max(hDpi, vDpi);
                        rasterImage.SetResolution(targetDpi, targetDpi);
                    }
                }

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When you need to ensure a scanned TIFF document prints at the correct size by making its X and Y DPI identical before further processing.
 * 2. When a batch job must normalize the resolution of mixed‑format raster images (PNG, JPEG, BMP) so that scaling operations produce consistent results.
 * 3. When a medical imaging workflow requires matching horizontal and vertical DPI of DICOM‑converted TIFF files to avoid distortion during analysis.
 * 4. When preparing images for a GIS application that expects square pixels, you align DPI to prevent geographic coordinate errors.
 * 5. When applying correction filters (sharpen, de‑noise) you first align DPI to prevent uneven filter strength caused by differing pixel densities.
 */
