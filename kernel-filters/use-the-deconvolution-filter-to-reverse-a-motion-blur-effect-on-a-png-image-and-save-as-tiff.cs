// HOW-TO: Remove Motion Blur From PNG Using Deconvolution And Save As TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.tif";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Create output directory unconditionally
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener deconvolution filter to reverse motion blur
                // Parameters: length, smooth, angle (example values)
                var motionWienerOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
                rasterImage.Filter(rasterImage.Bounds, motionWienerOptions);

                // Save the result as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                rasterImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to clean up a scanned PNG that suffered camera shake before archiving it as a high‑quality TIFF.
 * 2. When a web service receives motion‑blurred PNG uploads and must output deblurred TIFF files for printing.
 * 3. When a forensic analyst wants to reverse motion blur in evidence images and store the results in a lossless TIFF format using C#.
 * 4. When an automated batch job processes PNG screenshots from video frames, removes blur with a Wiener filter, and saves them as TIFF for further analysis.
 * 5. When a medical imaging workflow requires converting blurred PNG scans to TIFF after applying deconvolution to improve diagnostic clarity.
 */
