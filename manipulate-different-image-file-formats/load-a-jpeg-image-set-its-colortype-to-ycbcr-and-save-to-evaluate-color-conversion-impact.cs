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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
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
                    ColorType = JpegCompressionColorMode.YCbCr,
                    Quality = 100 // optional: set high quality
                };

                // Save the image using the specified options
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
 * 1. When a developer needs to convert an RGB JPEG to the YCbCr color space to reduce file size while preserving visual quality for web delivery, they can use this code to load the image, set ColorType to YCbCr, and save it with high quality.
 * 2. When testing how different JPEG compression color modes affect downstream video encoding pipelines, a programmer can load a sample JPEG, apply the YCbCr color type, and save the result to compare color fidelity.
 * 3. When preparing images for printing workflows that require YCbCr color data for accurate color management, developers can employ this snippet to convert and save JPEGs in the required color mode.
 * 4. When benchmarking the performance impact of color space conversion in a C# image processing service, engineers can use the code to load JPEGs, switch to YCbCr, and measure save times.
 * 5. When validating that a third‑party viewer correctly interprets YCbCr JPEGs, a QA engineer can run this program to generate a YCbCr‑encoded JPEG from an existing file for compatibility testing.
 */