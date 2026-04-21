using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define relative input and output paths
            string inputPath = "Input\\photo.dng";
            string outputPath = "Output\\photo.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG raw image
            using (Image dngImage = Image.Load(inputPath))
            {
                // Create a JPEG2000 image from the loaded raster (DNG) image
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image((RasterImage)dngImage))
                {
                    // Configure JPEG2000 options for lossless compression
                    using (Jpeg2000Options options = new Jpeg2000Options())
                    {
                        options.Irreversible = false; // lossless mode
                        // Save the result
                        jpeg2000Image.Save(outputPath, options);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}