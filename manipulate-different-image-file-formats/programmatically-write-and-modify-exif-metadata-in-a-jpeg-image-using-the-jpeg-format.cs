using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            var exifData = jpegImage.ExifData ?? new Aspose.Imaging.Exif.JpegExifData();

            exifData.Make = "MyCamera";
            exifData.Model = "ModelX";
            exifData.Artist = "John Doe";
            exifData.Copyright = "©2026";

            jpegImage.ExifData = exifData;

            JpegOptions saveOptions = new JpegOptions
            {
                Quality = 90,
                Source = new FileCreateSource(outputPath, false)
            };

            jpegImage.Save(outputPath, saveOptions);
        }
    }
}