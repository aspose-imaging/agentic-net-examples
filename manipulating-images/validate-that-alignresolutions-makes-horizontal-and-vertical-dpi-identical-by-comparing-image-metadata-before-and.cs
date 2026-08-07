using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\aligned_sample.tif";

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
                // Cast to RasterImage to access resolution properties
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Record resolutions before alignment
                double beforeH = raster.HorizontalResolution;
                double beforeV = raster.VerticalResolution;
                Console.WriteLine($"Before AlignResolutions: Horizontal DPI = {beforeH}, Vertical DPI = {beforeV}");

                // Call AlignResolutions if the type provides it
                if (image is TiffImage tiffImg)
                {
                    tiffImg.AlignResolutions();
                }
                else if (image is TiffFrame tiffFrame)
                {
                    tiffFrame.AlignResolutions();
                }
                else
                {
                    // Fallback: make resolutions equal using SetResolution
                    raster.SetResolution(beforeH, beforeH);
                }

                // Record resolutions after alignment
                double afterH = raster.HorizontalResolution;
                double afterV = raster.VerticalResolution;
                Console.WriteLine($"After AlignResolutions: Horizontal DPI = {afterH}, Vertical DPI = {afterV}");

                // Validate that horizontal and vertical DPI are now identical (within a tiny tolerance)
                bool aligned = Math.Abs(afterH - afterV) < 0.0001;
                Console.WriteLine($"Resolutions aligned: {aligned}");

                // Save the possibly modified image
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
 * 1. When converting scanned documents stored as multi‑page TIFF files to a PDF, a developer can use AlignResolutions to ensure the horizontal and vertical DPI are identical, preventing distortion in the final PDF layout.
 * 2. When preparing high‑resolution satellite imagery for GIS applications, aligning the DPI values guarantees that spatial measurements derived from the image are accurate across both axes.
 * 3. When integrating a C# image‑processing pipeline that resizes or rotates TIFF images, calling AlignResolutions before the transformation avoids unexpected scaling artifacts caused by mismatched DPI.
 * 4. When archiving medical DICOM images exported as TIFF, a developer can use AlignResolutions to standardize the resolution metadata, ensuring consistent display on different diagnostic workstations.
 * 5. When building a batch‑processing tool that normalizes printer‑ready TIFF files, AlignResolutions helps maintain uniform print quality by making the horizontal and vertical DPI identical before sending the files to the printer.
 */