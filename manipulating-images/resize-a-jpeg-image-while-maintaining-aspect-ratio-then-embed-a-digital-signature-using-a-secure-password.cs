using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for resizing and digital signature
                RasterImage raster = (RasterImage)image;

                // Maintain aspect ratio with a maximum width of 800 pixels
                int maxWidth = 800;
                int newWidth = raster.Width;
                int newHeight = raster.Height;

                if (raster.Width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)((double)raster.Height * maxWidth / raster.Width);
                }

                // Resize the image
                raster.Resize(newWidth, newHeight);

                // Embed digital signature using a secure password (>=4 characters)
                raster.EmbedDigitalSignature("secure123");

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
                raster.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}