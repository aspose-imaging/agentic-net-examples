using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.png";
        string outputPath = @"C:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the bitmap source image
        using (Image srcImage = Image.Load(inputPath))
        {
            // Cast to RasterImage for conversion
            RasterImage raster = srcImage as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Source image is not a raster image.");
                return;
            }

            // Create JPEG2000 image from the raster source
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(raster))
            {
                // Configure lossless compression (Irreversible = false)
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false
                };

                // Save the JPEG2000 image with the specified options
                jpeg2000Image.Save(outputPath, options);
            }
        }
    }
}