using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Align DPI for raster images
                if (image is RasterImage raster)
                {
                    // If horizontal and vertical DPI differ, make them equal
                    if (raster.HorizontalResolution != raster.VerticalResolution)
                    {
                        // Use the current horizontal DPI for both axes (could also use average)
                        double dpi = raster.HorizontalResolution;
                        raster.SetResolution(dpi, dpi);
                    }
                }

                // For TIFF-specific images, also call AlignResolutions if available
                if (image is TiffImage tiffImage)
                {
                    tiffImage.AlignResolutions();
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
 * 1. When a C# application processes scanned TIFF documents and must ensure that the horizontal and vertical DPI are identical before applying sharpening or noise‑reduction filters so the output prints at the correct size.
 * 2. When a batch image conversion tool uses Aspose.Imaging to normalize resolution of mixed‑resolution JPEG or PNG files before resizing them for a web gallery, preventing distortion caused by mismatched DPI.
 * 3. When a medical imaging system imports raster DICOM images converted to TIFF and needs to align DPI values to maintain accurate scaling for diagnostic measurements prior to applying contrast enhancement.
 * 4. When a desktop publishing workflow receives raster images from various sources and must synchronize DPI across the image before applying color correction filters to guarantee consistent layout dimensions in the final PDF.
 * 5. When an automated archival script processes legacy TIFF files with inconsistent DPI metadata and aligns the resolutions before running de‑skew or despeckle filters to preserve the original aspect ratio during long‑term storage.
 */