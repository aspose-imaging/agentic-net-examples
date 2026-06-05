using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_grayscale.jpg";

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

            // Load the source JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options to produce a grayscale image
                JpegOptions saveOptions = new JpegOptions
                {
                    // Convert to grayscale during save
                    ColorType = JpegCompressionColorMode.Grayscale,
                    // Optional: set quality (1-100)
                    Quality = 100
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
 * 1. When a developer needs to create a grayscale version of a user‑uploaded JPEG for a web gallery that only supports black‑and‑white thumbnails, they can load the image with Aspose.Imaging and set JpegOptions.ColorType to Grayscale before saving.
 * 2. When an e‑commerce platform wants to generate low‑cost product catalog PDFs that use grayscale JPEGs to meet printing guidelines, the code can convert the original color images to grayscale using C# and Aspose.Imaging.
 * 3. When a medical imaging application must store diagnostic photos as grayscale JPEGs to comply with storage constraints, developers can apply the JpegCompressionColorMode.Grayscale setting during save.
 * 4. When a mobile app needs to reduce file size for bandwidth‑limited uploads by stripping color data from JPEGs, the developer can use the provided code to convert the image to grayscale while preserving quality.
 * 5. When an archival system requires all incoming photographs to be saved in a uniform grayscale JPEG format for consistent indexing, the code demonstrates how to enforce the grayscale ColorType with Aspose.Imaging in C#.
 */