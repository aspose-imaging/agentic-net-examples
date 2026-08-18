// HOW-TO: Convert BMP Image to JPEG with Quality 85 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_converted.jpg";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality 85
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Save the image as JPEG, preserving original dimensions
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the file size of a BMP photo for web upload while keeping its original dimensions.
 * 2. When a legacy system provides images in BMP format and you must convert them to JPEG for compatibility with modern browsers.
 * 3. When generating thumbnails for a gallery and you want to store them as JPEG with a specific quality setting of 85.
 * 4. When automating a batch process that reads BMP files from a folder and saves them as JPEG to meet storage constraints.
 * 5. When integrating image conversion into a C# application that must handle missing files gracefully and ensure the output directory exists.
 */
