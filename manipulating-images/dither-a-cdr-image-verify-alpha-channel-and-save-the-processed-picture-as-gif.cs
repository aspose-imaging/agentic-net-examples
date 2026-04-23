using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_processed.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Determine if the image has an alpha channel (if the property exists)
                bool hasAlpha = false;
                var alphaProp = image.GetType().GetProperty("HasAlpha");
                if (alphaProp != null && alphaProp.PropertyType == typeof(bool))
                {
                    hasAlpha = (bool)alphaProp.GetValue(image);
                }
                Console.WriteLine($"Alpha channel present: {hasAlpha}");

                // Apply dithering if the image supports it (RasterImage implements Dither)
                if (image is RasterImage rasterImage)
                {
                    rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                }

                // Save the processed image as GIF
                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}