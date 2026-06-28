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
            // Hard‑coded input SVG path
            string inputPath = "input.svg";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG (or any vector) image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage to access embedded raster images
                var vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a vector image.");
                    return;
                }

                // Retrieve embedded raster images
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

                int index = 0;
                foreach (var embedded in embeddedImages)
                {
                    // Build output JPEG file name
                    string outputPath = $"image{index}.jpg";

                    // Ensure the output directory exists (handles null for current directory)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                    // Save each embedded image as JPEG
                    using (embedded)
                    {
                        var jpegOptions = new JpegOptions();
                        embedded.Image.Save(outputPath, jpegOptions);
                    }

                    index++;
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to extract and convert raster graphics embedded in an SVG logo into separate JPEG files for use in email newsletters.
 * 2. When a desktop publishing tool must isolate bitmap images from a complex SVG illustration to generate low‑resolution previews for quick loading.
 * 3. When a mobile app processes SVG assets and requires each embedded PNG or BMP to be saved as JPEG to meet platform‑specific image format constraints.
 * 4. When an automated build pipeline extracts raster images from SVG icons to create thumbnail JPEGs for a product catalog.
 * 5. When a digital asset management system needs to catalog and store each raster component of an SVG file as an individual JPEG for easier searching and reuse.
 */