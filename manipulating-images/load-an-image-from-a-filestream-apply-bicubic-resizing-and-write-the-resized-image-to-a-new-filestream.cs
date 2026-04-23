using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
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
                // Example resize dimensions (half the original size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Apply bicubic (cubic convolution) resizing
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Save resized image to a new FileStream
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputStream, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}