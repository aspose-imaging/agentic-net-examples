using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\Aligned\sample_aligned.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access AlignResolutions
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Capture resolutions before alignment
                double horizBefore = tiffImage.HorizontalResolution;
                double vertBefore = tiffImage.VerticalResolution;

                // Align horizontal and vertical resolutions
                tiffImage.AlignResolutions();

                // Capture resolutions after alignment
                double horizAfter = tiffImage.HorizontalResolution;
                double vertAfter = tiffImage.VerticalResolution;

                // Validate that resolutions are now identical
                bool isAligned = Math.Abs(horizAfter - vertAfter) < 0.0001;

                Console.WriteLine($"Before AlignResolutions: Horizontal={horizBefore}, Vertical={vertBefore}");
                Console.WriteLine($"After AlignResolutions:  Horizontal={horizAfter}, Vertical={vertAfter}");
                Console.WriteLine(isAligned
                    ? "Success: Horizontal and vertical DPI are now identical."
                    : "Failure: DPI values are still different.");

                // Save the aligned image
                tiffImage.Save(outputPath);
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
 * 1. When importing scanned TIFF files with differing horizontal and vertical DPI, a developer can use AlignResolutions to standardize the resolution before performing OCR or image analysis.
 * 2. When preparing multi‑page TIFF documents for printing, a developer can align the DPI values to avoid distortion caused by mismatched pixel density.
 * 3. When converting TIFF images to PDF or other formats, a developer can call AlignResolutions to ensure the output maintains consistent scaling across axes.
 * 4. When integrating TIFF images into a GIS or mapping application, a developer can align resolutions so that geographic coordinates are applied uniformly in both directions.
 * 5. When validating image metadata in a quality‑control pipeline, a developer can compare pre‑ and post‑AlignResolutions DPI values to confirm that the image meets required resolution standards.
 */