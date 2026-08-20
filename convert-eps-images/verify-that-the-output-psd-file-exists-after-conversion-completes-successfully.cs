// HOW-TO: Convert BMP to Grayscale PSD with RLE Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Grayscale
                };

                // Save the image as PSD
                image.Save(outputPath, psdOptions);
            }

            // Verify that the PSD file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("PSD file saved successfully.");
            }
            else
            {
                Console.Error.WriteLine("Failed to create PSD file.");
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
 * 1. When you need to generate a Photoshop PSD file from a bitmap image for further editing in Photoshop.
 * 2. When you want to verify that the converted PSD file was created successfully before continuing with downstream processing.
 * 3. When you require RLE compression and grayscale color mode to reduce the size of the resulting PSD file.
 * 4. When automating a batch workflow that converts multiple BMP images to PSD format using C#.
 * 5. When you must ensure the output directory exists and handle missing input files gracefully in an image conversion utility.
 */
