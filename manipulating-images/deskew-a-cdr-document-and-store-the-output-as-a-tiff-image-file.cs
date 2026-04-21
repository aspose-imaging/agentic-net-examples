using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.cdr";
            string outputPath = @"C:\output\deskewed.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize the CDR to a PNG in memory
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    // Save CDR as PNG (default rasterization options)
                    cdrImage.Save(rasterStream, new PngOptions());

                    // Reset stream position for reading
                    rasterStream.Position = 0;

                    // Load the rasterized image as RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Deskew the image (do not resize, use LightGray background)
                        rasterImage.NormalizeAngle(false, Color.LightGray);

                        // Prepare TIFF save options
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                        // Save the deskewed image as TIFF
                        rasterImage.Save(outputPath, tiffOptions);
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