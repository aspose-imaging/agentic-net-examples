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
                var vectorImage = image as VectorImage;
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
                    // Construct output JPEG file name
                    string outputFileName = $"image{index}.jpg";

                    // Ensure the output directory exists
                    string outputDir = Path.GetDirectoryName(outputFileName);
                    Directory.CreateDirectory(outputDir ?? string.Empty);

                    // Save the embedded image as JPEG
                    using (embedded)
                    {
                        var jpegOptions = new JpegOptions();
                        embedded.Image.Save(outputFileName, jpegOptions);
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
 * 1. When a developer needs to extract raster images embedded in an SVG file and save each as a separate JPEG for use in web galleries or thumbnails.
 * 2. When converting vector‑based SVG assets that contain logos or photos into individual JPEG files for inclusion in email newsletters or marketing materials.
 * 3. When processing SVG icons that embed raster graphics and the application must generate high‑resolution JPEG previews for a content management system.
 * 4. When migrating legacy design files that store embedded PNG or BMP images inside SVGs and the developer must separate them into standalone JPEG files for archival.
 * 5. When building an automated pipeline that scans SVG documents, extracts any embedded raster images, and stores them as JPEGs for downstream image analysis or machine‑learning models.
 */