using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Prepare JPEG options with EXIF metadata
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90,
                // Set EXIF data (camera make and model as example)
                ExifData = new Aspose.Imaging.Exif.JpegExifData
                {
                    Make = "MyCameraBrand",
                    Model = "MyCameraModel"
                }
            };

            // Configure vector rasterization for EMF to raster conversion
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White
            };
            jpegOptions.VectorRasterizationOptions = rasterOptions;

            // Save as JPEG with embedded EXIF
            emfImage.Save(outputPath, jpegOptions);
        }
    }
}