// HOW-TO: Convert JPEG to CMYK JPEG in C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output.cmyk.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Set up save options to convert to CMYK
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk
                };

                // Save the image with CMYK color type
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to prepare a JPEG for professional printing that requires CMYK color space.
 * 2. When converting images from screen RGB to CMYK to ensure color consistency across print workflows.
 * 3. When a web service must receive a JPEG, change its color mode to CMYK, and return the modified file.
 * 4. When validating that a JPEG’s color profile has been correctly changed before sending it to a publisher.
 * 5. When automating batch processing of photos to meet a printer’s CMYK JPEG specifications using C#.
 */
