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
                    VectorImage vectorImage = image as VectorImage;
                    if (vectorImage == null)
                    {
                        Console.Error.WriteLine($"Not a vector image: {inputPath}");
                        continue;
                    }

                    // Retrieve embedded images
                    EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                    int index = 0;

                    foreach (EmbeddedImage embedded in embeddedImages)
                    {
                        using (embedded)
                        {
                            // Create a thumbnail (max 150x150 while preserving aspect ratio)
                            const int maxThumbSize = 150;
                            int originalWidth = embedded.Image.Width;
                            int originalHeight = embedded.Image.Height;
                            double scale = Math.Min((double)maxThumbSize / originalWidth, (double)maxThumbSize / originalHeight);
                            int thumbWidth = (int)(originalWidth * scale);
                            int thumbHeight = (int)(originalHeight * scale);

                            // Resize the embedded image to thumbnail size
                            embedded.Image.Resize(thumbWidth, thumbHeight);

                            // Build output file path
                            string baseName = Path.GetFileNameWithoutExtension(inputPath);
                            string outFile = Path.Combine(outputDir, $"{baseName}_image{index}.png");

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outFile));

                            // Save the thumbnail as PNG
                            PngOptions pngOptions = new PngOptions();
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

/*
 * Real-World Use Cases:
 * 1. When a web‑app needs to generate preview thumbnails for all SVG icons that contain embedded raster images, this batch processor can extract those images and create 150 × 150 PNG thumbnails for fast UI rendering.
 * 2. When a design team migrates a library of SVG assets to a mobile app that only supports PNG, the code can automatically pull out embedded bitmap graphics from each SVG and convert them to PNG thumbnails for inclusion in the app bundle.
 * 3. When an e‑commerce platform wants to display low‑resolution previews of product diagrams stored as SVG files with embedded photos, the script can scan the directory, extract the photos, and produce PNG thumbnails for catalog pages.
 * 4. When a CI/CD pipeline must validate that all SVG files in a repository contain correctly sized raster assets, the batch routine can extract each embedded image and generate PNG thumbnails to be compared against size standards.
 * 5. When a content management system needs to index visual assets by generating thumbnail previews of embedded images inside SVG files, this C# code can process the folder, extract the raster parts, and save them as PNG thumbnails for search indexing.
 */