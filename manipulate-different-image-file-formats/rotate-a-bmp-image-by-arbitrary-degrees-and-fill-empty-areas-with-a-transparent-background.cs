using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output_rotated.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access the Rotate overload with background color
                RasterImage raster = (RasterImage)image;

                // Define rotation parameters
                float angle = 45f;                     // arbitrary rotation angle
                bool resizeProportionally = true;      // resize canvas to fit rotated image
                Color backgroundColor = Color.Transparent; // fill empty areas with transparency

                // Perform rotation
                raster.Rotate(angle, resizeProportionally, backgroundColor);

                // Save the rotated image as BMP with transparency support (Bitfields compression)
                var bmpOptions = new BmpOptions
                {
                    Compression = BitmapCompression.Bitfields
                };
                raster.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}