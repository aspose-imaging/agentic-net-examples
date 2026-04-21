using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\SvgInput";
            string outputDirectory = @"C:\SvgOutput";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string svgPath in svgFiles)
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
                    // Cast to VectorImage to access embedded images
                    if (image is VectorImage vectorImage)
                    {
                        // Retrieve embedded raster images
                        EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

                        for (int i = 0; i < embeddedImages.Length; i++)
                        {
                            using (EmbeddedImage embedded = embeddedImages[i])
                            {
                                // Create a thumbnail by resizing the embedded image
                                // Desired thumbnail size (e.g., 150x150) while preserving aspect ratio
                                int thumbSize = 150;
                                int originalWidth = embedded.Image.Width;
                                int originalHeight = embedded.Image.Height;

                                // Calculate new dimensions preserving aspect ratio
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

                                // Resize the image
                                embedded.Image.Resize(newWidth, newHeight);

                                // Prepare output file path
                                string baseName = Path.GetFileNameWithoutExtension(svgPath);
                                string outputFileName = $"{baseName}_image{i}.png";
                                string outputPath = Path.Combine(outputDirectory, outputFileName);

                                // Ensure the directory for the output file exists
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                                // Save the thumbnail as PNG
                                PngOptions pngOptions = new PngOptions();
                                embedded.Image.Save(outputPath, pngOptions);
                            }
                        }
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