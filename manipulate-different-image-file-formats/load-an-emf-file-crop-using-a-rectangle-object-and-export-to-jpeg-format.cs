using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image, crop it, and save as JPEG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF-specific functionality
            EmfImage emfImage = (EmfImage)image;

            // Define the cropping rectangle (example: top-left 100,100 with size 400x300)
            var cropRect = new Rectangle(100, 100, 400, 300);

            // Perform the crop operation
            emfImage.Crop(cropRect);

            // Set JPEG save options (default quality)
            var jpegOptions = new JpegOptions();

            // Save the cropped image as JPEG
            emfImage.Save(outputPath, jpegOptions);
        }
    }
}