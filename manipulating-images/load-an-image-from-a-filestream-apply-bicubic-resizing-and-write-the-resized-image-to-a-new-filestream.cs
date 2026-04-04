using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image from a FileStream
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (Image image = Image.Load(inputStream))
        {
            // Desired dimensions (example: half size)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using bicubic interpolation (CubicConvolution)
            image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            // Save resized image to a FileStream with PNG format
            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions();
                image.Save(outputStream, pngOptions);
            }
        }
    }
}