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
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG options with EXIF metadata
                JpegOptions jpegOptions = new JpegOptions();

                var exif = new Aspose.Imaging.Exif.JpegExifData
                {
                    Make = "MyCameraBrand",
                    Model = "ModelXYZ",
                    Software = "Aspose.Imaging"
                };
                jpegOptions.ExifData = exif;

                // Set vector rasterization options for EMF rendering
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };
                jpegOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as JPEG with embedded EXIF data
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}