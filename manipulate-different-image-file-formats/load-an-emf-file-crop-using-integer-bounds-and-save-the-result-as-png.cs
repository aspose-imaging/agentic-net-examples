using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF-specific functionality
            EmfImage emfImage = (EmfImage)image;

            // Define the cropping rectangle (example values)
            int cropX = 50;      // left offset
            int cropY = 50;      // top offset
            int cropWidth = 200; // width of the cropped area
            int cropHeight = 150; // height of the cropped area
            Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Perform the crop operation
            emfImage.Crop(cropRect);

            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the cropped image as PNG
            emfImage.Save(outputPath, pngOptions);
        }
    }
}