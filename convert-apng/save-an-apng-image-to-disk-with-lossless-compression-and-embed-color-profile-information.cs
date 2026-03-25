using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png; // for PngColorType
using Aspose.Imaging.Exif; // for ExifData

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "source.png";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG options for lossless compression and embed a simple color profile via EXIF
            ApngOptions apngOptions = new ApngOptions
            {
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha,
                PngCompressionLevel = 0, // lossless (no compression)
                ExifData = new ExifData() // placeholder for color profile information
            };

            // Create a new APNG image with the same dimensions as the source
            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add multiple frames (duplicate the source image for demonstration)
                int frameCount = 5;
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);
                }

                // Save the APNG to the specified output path
                apngImage.Save(outputPath);
            }
        }
    }
}