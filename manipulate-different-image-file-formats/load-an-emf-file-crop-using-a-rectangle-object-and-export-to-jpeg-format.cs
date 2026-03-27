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

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF-specific functionality
            EmfImage emfImage = (EmfImage)image;

            // Define the cropping rectangle (example values)
            // Adjust X, Y, Width, Height as needed
            int cropX = 50;
            int cropY = 50;
            int cropWidth = 200;
            int cropHeight = 150;
            Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Crop the image
            emfImage.Crop(cropRect);

            // Prepare JPEG save options
            JpegOptions jpegOptions = new JpegOptions();

            // Save the cropped image as JPEG
            emfImage.Save(outputPath, jpegOptions);
        }
    }
}