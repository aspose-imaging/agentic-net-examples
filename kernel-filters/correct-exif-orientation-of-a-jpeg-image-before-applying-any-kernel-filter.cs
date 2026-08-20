// HOW-TO: Auto‑Rotate JPEG and Apply Sharpen Filter in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output\\output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Correct orientation based on EXIF metadata
                image.AutoRotate();

                // Apply a sharpen filter to the entire image
                image.Filter(
                    image.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image with JPEG options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When uploading user‑taken photos to a web service, you need to fix the EXIF orientation before enhancing the image with a sharpen filter.
 * 2. When preparing product images for an e‑commerce catalog, you must correct rotated JPEGs and improve their clarity programmatically in C#.
 * 3. When batch‑processing scanned documents, you want to auto‑rotate each JPEG based on metadata and apply a sharpening effect to improve readability.
 * 4. When generating thumbnails for a mobile app, you need to ensure the source JPEG is correctly oriented and sharpened to maintain visual quality.
 * 5. When integrating a photo‑editing feature into a Windows application, you must automatically correct orientation and apply a custom sharpen filter using Aspose.Imaging.
 */
