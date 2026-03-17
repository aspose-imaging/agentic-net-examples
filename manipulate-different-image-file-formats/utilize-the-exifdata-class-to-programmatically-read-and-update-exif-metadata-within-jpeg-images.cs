using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    public static void Main(string[] args)
    {
        // Define input and output JPEG file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image using Aspose.Imaging
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Access the EXIF data container; cast to JpegExifData for JPEG-specific tags
            Aspose.Imaging.Exif.JpegExifData exif = jpegImage.ExifData as Aspose.Imaging.Exif.JpegExifData;

            if (exif != null)
            {
                // Display some existing EXIF values
                Console.WriteLine($"Original Artist: {exif.Artist}");
                Console.WriteLine($"Original Copyright: {exif.Copyright}");
                Console.WriteLine($"Original Image Description: {exif.ImageDescription}");

                // Update EXIF metadata
                exif.Artist = "John Doe";
                exif.Copyright = "© 2026 John Doe";
                exif.ImageDescription = "Updated description";

                // Example: change orientation and auto-rotate if needed
                // exif.Orientation = Aspose.Imaging.Exif.Orientation.TopLeft;
                // jpegImage.AutoRotate();
            }

            // Save the modified image to the output path
            jpegImage.Save(outputPath);
        }
    }
}