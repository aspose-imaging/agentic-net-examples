// HOW-TO: Extract Embedded Raster Images From SVG and Save As JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG file path
            string inputPath = @"C:\Images\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG (or any vector) image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage to access embedded images
                var vectorImage = (VectorImage)image;

                // Retrieve embedded raster images
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

                // Output folder for extracted JPEGs
                string outputFolder = @"C:\Images\Extracted";

                // Ensure the output folder exists (unconditional)
                Directory.CreateDirectory(outputFolder);

                int index = 0;
                foreach (var embedded in embeddedImages)
                {
                    // Build output file path
                    string outputPath = Path.Combine(outputFolder, $"image{index}.jpg");

                    // Ensure directory for this file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the embedded image as JPEG
                    using (embedded)
                    {
                        JpegOptions jpegOptions = new JpegOptions();
                        embedded.Image.Save(outputPath, jpegOptions);
                    }

                    index++;
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
 * 1. When you need to pull out raster graphics embedded in an SVG logo to generate separate JPEG thumbnails for a web catalog.
 * 2. When an automated build process must convert all embedded images inside vector icons to JPEG files for legacy systems that only support raster formats.
 * 3. When a content management system imports SVG files and you must extract the original photos to store them as individual JPEG assets for editing.
 * 4. When preparing print‑ready materials and you need to isolate each embedded bitmap from an SVG illustration to apply separate color corrections in JPEG.
 * 5. When migrating design assets from a vector‑based workflow to a raster‑only pipeline and you require a C# script to batch‑extract and save each embedded image as JPEG.
 */
