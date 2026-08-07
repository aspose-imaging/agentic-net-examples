using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Align DPI for TIFF images using the built‑in helper
                if (image is TiffImage tiffImg)
                {
                    tiffImg.AlignResolutions();
                }
                // For other raster images, make horizontal and vertical DPI equal
                else if (image is RasterImage rasterImg)
                {
                    double hDpi = rasterImg.HorizontalResolution;
                    double vDpi = rasterImg.VerticalResolution;

                    if (Math.Abs(hDpi - vDpi) > 0.001)
                    {
                        double avgDpi = (hDpi + vDpi) / 2.0;
                        rasterImg.SetResolution(avgDpi, avgDpi);
                    }
                }

                // Example correction filter applied after DPI alignment
                if (image is RasterImage ri)
                {
                    ri.Grayscale();
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
 * 1. When converting scanned TIFF documents to a standardized PDF, a developer can align horizontal and vertical DPI before applying grayscale or other correction filters to ensure consistent scaling across all pages.
 * 2. When preparing satellite imagery in JPEG or PNG format for GIS analysis, aligning the DPI first guarantees accurate distance measurements after applying contrast‑enhancement filters.
 * 3. When building a batch‑processing tool that normalizes product photos for an e‑commerce site, the code can equalize DPI before resizing and applying color‑correction filters to keep every image the same physical size.
 * 4. When integrating a medical‑imaging workflow that receives DICOM‑converted TIFF scans, aligning resolutions before denoising filters ensures diagnostic measurements are not distorted.
 * 5. When creating an archival pipeline for historical photographs, setting matching horizontal and vertical DPI before applying restoration filters preserves the original aspect ratio and print dimensions.
 */