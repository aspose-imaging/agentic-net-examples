using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG options with default compression
                var pngOptions = new PngOptions
                {
                    // Preserve alpha channel
                    ColorType = PngColorType.TruecolorWithAlpha,
                    // Configure rasterization for vector source
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };

                // Remove background if the image is a vector type
                if (image is VectorImage vectorImage)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                // Save rasterized PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}