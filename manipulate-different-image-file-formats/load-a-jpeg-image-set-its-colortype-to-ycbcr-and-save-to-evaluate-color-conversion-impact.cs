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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_ycbcr.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with YCbCr color type
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.YCbCr
                };

                // Save the image with the specified options
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
 * 1. When a developer needs to convert an RGB JPEG to YCbCr to match the color space used by most digital cameras and evaluate compression quality differences.
 * 2. When a web application must generate JPEGs in YCbCr color mode to ensure consistent rendering across browsers that expect YCbCr‑encoded images.
 * 3. When performing batch image preprocessing for a machine‑learning pipeline, a developer may load JPEGs, set ColorType to YCbCr, and save them to standardize the input color format.
 * 4. When testing the impact of color space conversion on file size, a developer can load a JPEG, apply the YCbCr color type with Aspose.Imaging, and compare the resulting output file.
 * 5. When integrating with a legacy printing system that only accepts YCbCr‑encoded JPEGs, a developer can use this code to convert and save images in the required color mode.
 */