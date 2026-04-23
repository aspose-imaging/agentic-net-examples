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
                // Align horizontal and vertical DPI
                if (image is TiffImage tiffImg)
                {
                    // Align each frame in a TIFF image
                    foreach (TiffFrame frame in tiffImg.Frames)
                    {
                        frame.AlignResolutions();
                    }
                }
                else if (image is RasterImage rasterImg)
                {
                    // For non‑TIFF raster images, make DPI values equal
                    double hRes = rasterImg.HorizontalResolution;
                    double vRes = rasterImg.VerticalResolution;
                    if (Math.Abs(hRes - vRes) > 0.0001)
                    {
                        // Use the larger DPI to avoid shrinking the image
                        double targetDpi = Math.Max(hRes, vRes);
                        rasterImg.SetResolution(targetDpi, targetDpi);
                    }
                }

                // TODO: Apply correction filters here (e.g., AutoBrightnessContrast)

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