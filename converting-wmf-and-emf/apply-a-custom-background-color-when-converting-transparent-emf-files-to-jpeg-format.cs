using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.jpg";

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
            // Cast to EmfImage to access EMF-specific properties
            EmfImage emfImage = (EmfImage)image;

            // Configure rasterization options with a custom background color
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.LightGray // custom background
            };

            // Configure JPEG save options and attach rasterization options
            JpegOptions jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as JPEG with the specified background color
            emfImage.Save(outputPath, jpegOptions);
        }
    }
}