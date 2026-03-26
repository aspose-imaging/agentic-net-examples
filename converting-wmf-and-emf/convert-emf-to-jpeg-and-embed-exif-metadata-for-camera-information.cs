using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_converted.jpg";

        // Verify that the source EMF file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Prepare JPEG save options
            var jpegOptions = new JpegOptions();

            // Create and populate EXIF data (camera information)
            var exif = new JpegExifData
            {
                Make = "Canon",               // Camera manufacturer
                Model = "EOS 5D Mark IV",     // Camera model
                // Additional optional tags can be set here, e.g.:
                // DateTimeOriginal = DateTime.Now,
                // FNumber = 2.8,
                // ExposureTime = 0.005,
                // ISO = 100
            };
            jpegOptions.ExifData = exif;

            // Configure rasterization of the vector EMF image
            jpegOptions.VectorRasterizationOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size, // Preserve original size
                BackgroundColor = Color.White // Optional background
            };

            // Save the rasterized image as JPEG with the EXIF metadata
            emfImage.Save(outputPath, jpegOptions);
        }
    }
}