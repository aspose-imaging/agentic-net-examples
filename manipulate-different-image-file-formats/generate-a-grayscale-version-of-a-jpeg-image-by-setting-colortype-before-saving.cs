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
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_grayscale.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with grayscale color type
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Grayscale
                };

                // Save the image as a grayscale JPEG
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
 * 1. When a photo‑sharing website wants to create low‑bandwidth preview thumbnails by converting user‑uploaded color JPEGs to grayscale, a developer can load the image with Aspose.Imaging and save it using JpegOptions.ColorType = Grayscale.
 * 2. When an archival system requires all scanned documents to be stored as grayscale JPEGs to preserve text clarity while minimizing file size, this C# code can read the original image and re‑save it with the grayscale color mode.
 * 3. When a medical imaging application needs to standardize input X‑ray images to a single channel before analysis, a developer can use Aspose.Imaging to load the JPEG and output a grayscale version with the specified JpegCompressionColorMode.
 * 4. When an e‑commerce platform generates product catalog PDFs and wants the background images in grayscale to reduce printing costs, the code demonstrates how to convert each JPEG to grayscale using C# and Aspose.Imaging.
 * 5. When a desktop utility offers batch conversion of color photographs to grayscale for artistic effect, this snippet shows how to verify file paths, load each JPEG, set JpegOptions.ColorType to Grayscale, and save the result.
 */