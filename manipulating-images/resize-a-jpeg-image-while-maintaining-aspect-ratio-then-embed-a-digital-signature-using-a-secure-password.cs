using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Desired maximum dimensions while preserving aspect ratio
            int maxWidth = 800;
            int maxHeight = 600;

            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Resize only if dimensions change
            if (newWidth > 0 && newHeight > 0 && (newWidth != image.Width || newHeight != image.Height))
            {
                image.Resize(newWidth, newHeight);
            }

            // Embed digital signature with a secure password
            string password = "securePassword123";
            image.EmbedDigitalSignature(password);

            // Save the processed image with JPEG options
            JpegOptions saveOptions = new JpegOptions
            {
                Quality = 90
            };
            image.Save(outputPath, saveOptions);
        }
    }
}