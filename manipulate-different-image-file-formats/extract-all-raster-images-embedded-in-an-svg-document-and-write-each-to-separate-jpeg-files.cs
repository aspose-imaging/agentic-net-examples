using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG file path
        string inputPath = "input.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for extracted images
        string outputDir = "extracted_images";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to VectorImage to access embedded images
            var vectorImage = (VectorImage)image;

            // Retrieve embedded raster images
            EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

            int index = 0;
            foreach (var embedded in embeddedImages)
            {
                // Ensure each embedded image is disposed properly
                using (embedded)
                {
                    // Build output file path (JPEG)
                    string outputPath = Path.Combine(outputDir, $"image{index++}.jpg");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the embedded image as JPEG
                    embedded.Image.Save(outputPath, new JpegOptions());
                }
            }
        }
    }
}