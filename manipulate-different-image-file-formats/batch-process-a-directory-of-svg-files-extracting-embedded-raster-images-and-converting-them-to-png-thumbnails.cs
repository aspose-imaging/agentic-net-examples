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

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to VectorImage to access embedded raster images
                    var vectorImage = image as VectorImage;
                    if (vectorImage == null)
                        continue;

                    // Retrieve embedded images
                    EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                    int index = 0;

                    foreach (var embedded in embeddedImages)
                    {
                        using (embedded)
                        {
                            // Create a thumbnail of size 150 (preserving aspect ratio)
                            const int thumbSize = 150;
                            int originalWidth = embedded.Image.Width;
                            int originalHeight = embedded.Image.Height;
                            int newWidth, newHeight;

                            if (originalWidth >= originalHeight)
                            {
                                newWidth = thumbSize;
                                newHeight = (int)(originalHeight * (thumbSize / (float)originalWidth));
                            }
                            else
                            {
                                newHeight = thumbSize;
                                newWidth = (int)(originalWidth * (thumbSize / (float)originalHeight));
                            }

                            // Resize the embedded raster image
                            embedded.Image.Resize(newWidth, newHeight);

                            // Build output file path
                            string baseName = Path.GetFileNameWithoutExtension(inputPath);
                            string outFile = Path.Combine(outputDir, $"{baseName}_image{index}.png");

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outFile));

                            // Save the thumbnail as PNG
                            var pngOptions = new PngOptions();
                            embedded.Image.Save(outFile, pngOptions);
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