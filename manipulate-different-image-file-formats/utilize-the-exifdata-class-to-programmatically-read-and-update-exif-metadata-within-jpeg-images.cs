using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output.jpg";

        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            var exif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
            if (exif != null)
            {
                exif.Artist = "John Doe";
                exif.Copyright = "© 2026";
                exif.Software = "Aspose.Imaging";
                exif.Orientation = Aspose.Imaging.Exif.Orientation.TopLeft;
            }

            image.Save(outputPath);
        }
    }
}