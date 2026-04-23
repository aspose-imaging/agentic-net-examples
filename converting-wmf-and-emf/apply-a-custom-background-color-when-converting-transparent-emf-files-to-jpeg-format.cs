using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output\\converted.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options with a custom background color
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                // Use the original image size as the page size
                PageSize = image.Size,
                // Set desired background color (e.g., LightGray)
                BackgroundColor = Aspose.Imaging.Color.LightGray
            };

            // Prepare JPEG save options and attach rasterization options
            JpegOptions jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as JPEG with the specified background
            image.Save(outputPath, jpegOptions);
        }
    }
}