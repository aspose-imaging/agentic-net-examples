using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the JPEG image
        string imagePath = @"c:\temp\sample.jpg";

        // Load the image using the standard load rule
        using (Image image = Image.Load(imagePath))
        {
            // Cast to JpegImage to access JPEG-specific options
            JpegImage jpegImage = image as JpegImage;
            if (jpegImage != null)
            {
                // Retrieve the compression quality level from the JPEG options
                int quality = jpegImage.JpegOptions.Quality;

                // Output the quality value for analysis
                Console.WriteLine($"JPEG compression quality: {quality}");
            }
            else
            {
                Console.WriteLine("The loaded image is not a JPEG image.");
            }
        }
    }
}