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
            string inputPath = "input.emf";
            string outputPath = "output\\converted.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare JPEG options with EXIF metadata
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.Quality = 90;

            var exif = new Aspose.Imaging.Exif.JpegExifData();
            exif.Make = "MyCameraMaker";
            exif.Model = "MyCameraModel";
            jpegOptions.ExifData = exif;

            // Load EMF image and save as JPEG with EXIF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}