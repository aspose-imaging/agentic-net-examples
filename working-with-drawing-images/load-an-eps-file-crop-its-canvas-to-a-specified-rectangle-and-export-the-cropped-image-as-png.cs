using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\cropped.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image
        using (EpsImage image = (EpsImage)Image.Load(inputPath))
        {
            // Define the rectangle to crop (x, y, width, height)
            // Adjust these values as needed for the desired crop area
            Rectangle cropRect = new Rectangle(100, 100, 400, 300);

            // Crop the image to the specified rectangle
            image.Crop(cropRect);

            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the cropped image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}