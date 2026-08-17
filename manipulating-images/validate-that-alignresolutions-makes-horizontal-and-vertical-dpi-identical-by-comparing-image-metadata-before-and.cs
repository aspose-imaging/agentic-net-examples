// HOW-TO: Align Horizontal and Vertical DPI of a TIFF Image in C# (Aspose.Imaging for .NET)
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
        string outputPath = @"C:\Images\aligned_sample.tif";

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
                Console.WriteLine($"Before AlignResolutions: Horizontal DPI = {horizBefore}, Vertical DPI = {vertBefore}");

                // Align horizontal and vertical resolutions
                tiffImage.AlignResolutions();

                // Capture resolutions after alignment
                double horizAfter = tiffImage.HorizontalResolution;
                double vertAfter = tiffImage.VerticalResolution;
                Console.WriteLine($"After AlignResolutions: Horizontal DPI = {horizAfter}, Vertical DPI = {vertAfter}");

                // Validate that both DPI values are now identical
                if (Math.Abs(horizAfter - vertAfter) < 0.0001)
                {
                    Console.WriteLine("Validation passed: Horizontal and vertical DPI are identical.");
                }
                else
                {
                    Console.WriteLine("Validation failed: DPI values differ after alignment.");
                }

                // Save the aligned image
                tiffImage.Save(outputPath);
                Console.WriteLine($"Aligned image saved to: {outputPath}");
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
 * 1. When you need to ensure a scanned TIFF document has consistent DPI for accurate printing.
 * 2. When converting multi‑resolution TIFF files to a single resolution before archiving.
 * 3. When preparing TIFF images for OCR engines that require matching horizontal and vertical DPI.
 * 4. When normalizing image metadata to avoid distortion in GIS or CAD applications.
 * 5. When validating that image processing pipelines preserve resolution integrity after manipulation.
 */
