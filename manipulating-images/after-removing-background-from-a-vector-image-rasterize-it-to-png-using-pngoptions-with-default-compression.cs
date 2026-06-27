using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            // Validate input file existence
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
                // Cast to VectorImage and remove background if possible
                VectorImage vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                // Configure PNG options with default compression and transparent background
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };

                // Save the rasterized PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert SVG logos with unwanted white backgrounds into transparent PNG icons for responsive web design.
 * 2. When an e‑commerce platform must generate product thumbnails by stripping the background from vector illustrations and rasterizing them to PNG with default compression for fast page loads.
 * 3. When a mobile app creates custom stickers by removing the background from user‑uploaded SVG drawings and saving them as PNG files with alpha channel support.
 * 4. When a reporting tool automatically prepares high‑resolution charts by eliminating the vector background and exporting them as PNG images for inclusion in PDF documents.
 * 5. When a game engine pipeline processes vector UI assets, removes their backgrounds, and rasterizes them to PNG using Aspose.Imaging for seamless integration into the texture atlas.
 */