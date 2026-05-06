using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base64-encoded PNG image (1x1 pixel)
            string base64String = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XG6cAAAAASUVORK5CYII=";
            // Decode the base64 string to a byte array
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Output JPEG file path (hardcoded)
            string outputPath = "output.jpg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image from the memory stream
            using (MemoryStream ms = new MemoryStream(imageBytes))
            using (RasterImage raster = (RasterImage)Image.Load(ms))
            {
                // Create default JPEG options
                JpegOptions jpegOptions = new JpegOptions();

                // Save the image as JPEG with default settings
                raster.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}