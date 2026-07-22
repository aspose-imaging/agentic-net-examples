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
            string outputPath = "output\\output_ycbcr.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with YCbCr color type
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
 * 1. When a developer needs to convert an RGB JPEG to YCbCr before uploading it to a web service that requires YCbCr color space for optimal compression.
 * 2. When a developer wants to ensure a JPEG image complies with broadcast standards that mandate YCbCr color encoding for television transmission.
 * 3. When a developer is preparing a batch of product photos for an e‑commerce platform that mandates YCbCr JPEGs to reduce file size while preserving visual quality.
 * 4. When a developer is testing the impact of YCbCr color conversion on image quality by saving a JPEG with Aspose.Imaging’s JpegOptions in a C# application.
 * 5. When a developer needs to generate YCbCr‑encoded JPEG thumbnails for a digital asset management system that stores images in the YCbCr color space for faster rendering.
 */