using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\source.bmp";
            string outputPath = @"C:\Temp\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image as a raster image
            using (Image loadedImage = Image.Load(inputPath))
            {
                // Cast to RasterImage (BMP is a raster format)
                using (RasterImage raster = (RasterImage)loadedImage)
                {
                    // Create JPEG2000 image from the raster image with custom bits per pixel (e.g., 12)
                    int customBitsPerPixel = 12;
                    using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(raster, customBitsPerPixel))
                    {
                        // Save the JPEG2000 image using default options
                        jpeg2000Image.Save(outputPath);
                    }
                }
            }

            // Verify output file size
            FileInfo info = new FileInfo(outputPath);
            Console.WriteLine($"Output file size: {info.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy BMP assets to JPEG2000 for web delivery while preserving high color fidelity by setting a custom 12‑bit per sample depth.
 * 2. When an application must generate JPEG2000 files from raster images on the fly and verify the resulting file size to ensure it meets storage or bandwidth constraints.
 * 3. When a medical imaging system requires converting 12‑bit grayscale BMP scans to JPEG2000 to take advantage of lossless compression and maintain diagnostic quality.
 * 4. When a batch processing tool has to read BMP files from a known folder, create JPEG2000 versions with a specific bits‑per‑sample setting, and automatically create the output directory if it does not exist.
 * 5. When a developer wants to catch and log errors while loading a BMP, converting it to a Jpeg2000Image object, and saving it, ensuring the process is robust for production environments.
 */