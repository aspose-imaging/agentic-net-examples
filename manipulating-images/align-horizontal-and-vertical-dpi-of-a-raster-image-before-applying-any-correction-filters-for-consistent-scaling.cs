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
                // Cast to TiffImage (a RasterImage derivative)
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Align horizontal and vertical DPI if they differ
                double hDpi = tiffImage.HorizontalResolution;
                double vDpi = tiffImage.VerticalResolution;

                if (Math.Abs(hDpi - vDpi) > 0.001)
                {
                    // Use the SetResolution method to make both DPI values equal.
                    // Here we choose the larger of the two to preserve detail.
                    double targetDpi = Math.Max(hDpi, vDpi);
                    tiffImage.SetResolution(targetDpi, targetDpi);
                }

                // Example placeholder for any correction filters that might be applied
                // (e.g., tiffImage.SomeFilter();)

                // Save the processed image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}