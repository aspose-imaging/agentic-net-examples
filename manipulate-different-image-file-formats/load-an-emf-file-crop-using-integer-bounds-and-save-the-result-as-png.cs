using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image, crop it, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access cropping functionality
            EmfImage emfImage = (EmfImage)image;

            // Define the cropping rectangle (example values)
            // Rectangle(x, y, width, height)
            var cropRect = new Aspose.Imaging.Rectangle(50, 50, 200, 150);

            // Perform the crop operation
            emfImage.Crop(cropRect);

            // Prepare PNG save options
            var pngOptions = new PngOptions();

            // Save the cropped image as PNG
            emfImage.Save(outputPath, pngOptions);
        }
    }
}