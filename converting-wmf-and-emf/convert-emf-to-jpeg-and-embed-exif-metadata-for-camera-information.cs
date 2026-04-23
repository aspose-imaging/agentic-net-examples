using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare JPEG options with EXIF metadata
        JpegOptions jpegOptions = new JpegOptions();

        // Create and set EXIF data (camera make and model as example)
        Aspose.Imaging.Exif.JpegExifData exifData = new Aspose.Imaging.Exif.JpegExifData();
        exifData.Make = "ExampleCameraMake";
        exifData.Model = "ExampleCameraModel";
        jpegOptions.ExifData = exifData;

        // Configure vector rasterization for EMF to JPEG conversion
        using (Image image = Image.Load(inputPath))
        {
            VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };
            jpegOptions.VectorRasterizationOptions = vectorOptions;

            image.Save(outputPath, jpegOptions);
        }
    }
}