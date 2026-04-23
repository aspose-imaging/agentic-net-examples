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

        // Hardcoded directory where extracted JPEGs will be saved
        string outputDirectory = "extracted_images";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the SVG (or any vector) image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage to access embedded images
                var vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The provided file is not a vector image.");
                    return;
                }

                // Retrieve embedded raster images
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

                int index = 0;
                foreach (EmbeddedImage embedded in embeddedImages)
                {
                    // Build output file path for each extracted image
                    string outputPath = Path.Combine(outputDirectory, $"image{index++}.jpg");

                    // Ensure the directory for the output file exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the embedded raster image as JPEG
                    using (embedded)
                    {
                        embedded.Image.Save(outputPath, new JpegOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}