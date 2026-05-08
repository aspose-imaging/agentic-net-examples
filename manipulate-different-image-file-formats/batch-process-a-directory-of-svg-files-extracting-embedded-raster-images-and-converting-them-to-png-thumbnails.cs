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
            // Hardcoded input and output directories
            string inputDir = @"C:\SvgInput";
            string outputDir = @"C:\SvgOutput";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each SVG file in the input directory
            foreach (string svgPath in Directory.GetFiles(inputDir, "*.svg"))
            {
                // Verify the SVG file exists
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }

                // Load the SVG image
                using (Image image = Image.Load(svgPath))
                {
                    // Cast to VectorImage to access embedded resources
                    var vectorImage = image as VectorImage;
                    if (vectorImage == null)
                    {
                        Console.Error.WriteLine($"Not a vector image: {svgPath}");
                        continue;
                    }

                    // Retrieve embedded raster images
                    EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                    int index = 0;

                    foreach (EmbeddedImage embedded in embeddedImages)
                    {
                        using (embedded)
                        {
                            // The actual raster image
                            Image raster = embedded.Image;

                            // Create a thumbnail (max width 150px, preserve aspect ratio)
                            const int thumbWidth = 150;
                            int thumbHeight = (int)(raster.Height * (thumbWidth / (double)raster.Width));
                            raster.Resize(thumbWidth, thumbHeight);

                            // Build output file path
                            string outFileName = Path.Combine(
                                outputDir,
                                $"{Path.GetFileNameWithoutExtension(svgPath)}_img{index}.png");

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outFileName));

                            // Save the thumbnail as PNG
                            var pngOptions = new PngOptions();
                            raster.Save(outFileName, pngOptions);
                        }

                        index++;
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