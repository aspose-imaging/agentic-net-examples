using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string sourcePath = @"c:\temp\source.bmp";

        // Path where the JPEG will be saved
        string jpegPath = @"c:\temp\output.jpg";

        // Load the source image using the standard load rule
        using (Image srcImage = Image.Load(sourcePath))
        {
            // Configure JPEG save options (compression quality = 80)
            JpegOptions saveOptions = new JpegOptions
            {
                // Quality is a value between 1 and 100
                Quality = 80,
                // Optional: set progressive compression
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                // Optional: keep default bits per channel (8)
                BitsPerChannel = 8
            };

            // Save the image as JPEG using the save rule
            srcImage.Save(jpegPath, saveOptions);
        }

        // Load the saved JPEG image to inspect its compression quality
        using (JpegImage jpegImage = (JpegImage)Image.Load(jpegPath))
        {
            // Access the JPEG options used during loading/creation
            JpegOptions loadedOptions = jpegImage.JpegOptions;

            // Output the quality value that was applied
            Console.WriteLine($"Applied JPEG compression quality: {loadedOptions.Quality}");
        }
    }
}