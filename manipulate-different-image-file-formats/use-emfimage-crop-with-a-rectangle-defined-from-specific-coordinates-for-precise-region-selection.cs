using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output\cropped.png";

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
            // Cast to EmfImage to access EMF-specific methods
            EmfImage emfImage = (EmfImage)image;

            // Define the cropping rectangle with specific coordinates (left, top, width, height)
            Rectangle cropRect = new Rectangle(50, 50, 200, 150);

            // Perform the crop operation
            emfImage.Crop(cropRect);

            // Save the cropped image as PNG
            emfImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
        }
    }
}