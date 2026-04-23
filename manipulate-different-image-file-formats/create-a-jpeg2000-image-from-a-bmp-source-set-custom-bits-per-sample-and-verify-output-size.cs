using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.bmp";
        string outputPath = @"C:\Images\output.jp2";

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

            // Load BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Cast to RasterImage (required for Jpeg2000Image constructor)
                RasterImage raster = bmpImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image from BMP.");
                    return;
                }

                // Create JPEG2000 image with custom bits per pixel (e.g., 12 bits)
                int customBitsPerPixel = 12;
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(raster, customBitsPerPixel))
                {
                    // Optional: set JPEG2000 options (e.g., irreversible compression)
                    Jpeg2000Options options = new Jpeg2000Options
                    {
                        Irreversible = true,
                        Codec = Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Codec.J2K
                    };

                    // Save JPEG2000 image
                    jpeg2000Image.Save(outputPath, options);
                }
            }

            // Verify output file size
            long fileSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Output file size: {fileSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}