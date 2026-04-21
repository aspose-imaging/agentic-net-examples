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
            string inputPath = "sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage (SvgImage derives from VectorImage)
                var vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a vector image.");
                    return;
                }

                // Retrieve embedded raster images
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

                int i = 0;
                foreach (var embedded in embeddedImages)
                {
                    // Prepare output JPEG file name
                    string outputPath = $"image{i}.jpg";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                    // Save the embedded image as JPEG
                    using (embedded)
                    {
                        var jpegOptions = new JpegOptions();
                        embedded.Image.Save(outputPath, jpegOptions);
                    }

                    i++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}