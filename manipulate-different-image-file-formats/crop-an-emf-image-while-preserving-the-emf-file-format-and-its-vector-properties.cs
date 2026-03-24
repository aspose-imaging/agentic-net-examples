using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output_cropped.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image, crop, and save
        using (EmfImage emf = (EmfImage)Image.Load(inputPath))
        {
            // Define the crop rectangle (example: top-left quarter of the image)
            int cropX = 0;
            int cropY = 0;
            int cropWidth = emf.Width / 2;
            int cropHeight = emf.Height / 2;
            Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Perform cropping
            emf.Crop(cropRect);

            // Save the cropped EMF preserving vector properties
            emf.Save(outputPath);
        }
    }
}