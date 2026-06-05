using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG file path
            string inputPath = "input.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage to access embedded images
                VectorImage vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a vector image.");
                    return;
                }

                // Retrieve embedded raster images
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                int index = 0;

                foreach (EmbeddedImage embedded in embeddedImages)
                {
                    // Prepare output file path for each extracted image
                    string outputDir = "output";
                    string outputPath = Path.Combine(outputDir, $"image{index}.jpg");

                    // Ensure the output directory exists
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
 * 1. When a web application needs to extract and convert embedded PNG or JPEG assets from an uploaded SVG logo into separate JPEG files for thumbnail generation.
 * 2. When a digital asset management system must isolate raster images embedded in SVG illustrations to store them as standalone JPEGs for faster preview loading.
 * 3. When a reporting tool processes SVG charts that contain raster backgrounds and must export those backgrounds as JPEG images for inclusion in PDF reports.
 * 4. When a migration script moves legacy SVG files to a new platform and needs to extract all embedded raster graphics, saving them as JPEGs to preserve visual fidelity.
 * 5. When an e‑learning platform parses SVG diagrams with embedded photos and converts each photo to JPEG to comply with a content delivery network’s image format requirements.
 */