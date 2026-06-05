using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the source image via a FileStream
            using (FileStream inputStream = File.OpenRead(inputPath))
            // Load the image from the stream
            using (Image image = Image.Load(inputStream))
            {
                // Determine new dimensions (example: half the original size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Apply bicubic (cubic convolution) resizing
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Prepare the output stream
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    // Save the resized image as PNG
                    var pngOptions = new PngOptions();
                    image.Save(outputStream, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}