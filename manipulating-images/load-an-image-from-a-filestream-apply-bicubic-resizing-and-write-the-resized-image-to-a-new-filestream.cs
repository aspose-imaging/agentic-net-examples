// HOW-TO: Resize JPEG To PNG With Bicubic Interpolation Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the input file as a FileStream and load the image
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image image = Image.Load(inputStream))
            {
                // Example resize dimensions (half the original size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Apply bicubic (cubic convolution) resizing
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Open the output file as a FileStream and save the resized image
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    var pngOptions = new PngOptions(); // default PNG options
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

/*
 * Real-World Use Cases:
 * 1. When you need to shrink a high‑resolution JPEG for faster web loading while converting it to PNG format.
 * 2. When you must process images from a stream (e.g., uploaded files) and store the resized result without loading the whole file into memory.
 * 3. When you want to maintain image quality by using bicubic (cubic convolution) resizing before saving to a lossless format.
 * 4. When you are building a batch job that reads images from a folder, resizes them to half size, and writes the output to a different directory.
 * 5. When you need to ensure the output directory exists and handle file‑not‑found errors gracefully during image conversion.
 */
