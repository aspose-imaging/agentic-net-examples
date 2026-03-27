using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Base64 string representing an HTML5 Canvas image (example PNG data)
        string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUA" +
                        "AAAFCAYAAACNbyblAAAAHElEQVQI12P4" +
                        "//8/w38GIAXDIBKE0DHxgljNBAAO" +
                        "9TXL0Y4OHwAAAABJRU5ErkJggg==";

        // Decode the Base64 string to a byte array
        byte[] imageBytes = Convert.FromBase64String(base64);

        // Load the image from the byte array using a memory stream
        using (MemoryStream ms = new MemoryStream(imageBytes))
        {
            using (RasterImage raster = (RasterImage)Image.Load(ms))
            {
                // Define the output JPEG file path (hard‑coded)
                string outputPath = @"C:\Temp\output.jpg";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create JPEG options with default settings
                JpegOptions jpegOptions = new JpegOptions();

                // Save the raster image as JPEG using the options
                raster.Save(outputPath, jpegOptions);
            }
        }
    }
}