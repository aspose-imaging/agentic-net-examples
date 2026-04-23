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
            string inputPath = @"C:\Images\sample.tif";
            string outputPath = @"C:\Images\output\aligned_sample.tif";

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
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Capture DPI values before alignment
                double hBefore = tiff.HorizontalResolution;
                double vBefore = tiff.VerticalResolution;
                Console.WriteLine($"Before AlignResolutions: Horizontal DPI = {hBefore}, Vertical DPI = {vBefore}");

                // Align horizontal and vertical resolutions
                tiff.AlignResolutions();

                // Capture DPI values after alignment
                double hAfter = tiff.HorizontalResolution;
                double vAfter = tiff.VerticalResolution;
                Console.WriteLine($"After AlignResolutions: Horizontal DPI = {hAfter}, Vertical DPI = {vAfter}");

                // Validate that DPI values are now identical
                if (Math.Abs(hAfter - vAfter) < 0.0001)
                {
                    Console.WriteLine("Validation passed: Horizontal and vertical DPI are identical after alignment.");
                }
                else
                {
                    Console.WriteLine("Validation failed: DPI values are still different after alignment.");
                }

                // Save the modified image
                tiff.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}