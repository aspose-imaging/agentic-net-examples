using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";
        string createdImagePath = @"C:\temp\newImage.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(createdImagePath));

        // Load an existing image, perform a simple operation, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Example operation: rotate the image 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the processed image using PNG options
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }

        // Create a new BMP image from scratch and save it
        var bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(createdImagePath, false)
        };

        using (Image newImage = Image.Create(bmpOptions, 200, 200))
        {
            // No additional processing; just save the newly created image
            newImage.Save();
        }
    }
}