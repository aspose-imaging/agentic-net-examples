// HOW-TO: Extract Embedded Images From SVG And Create PNG Thumbnails In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
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

                // Load the SVG (or any vector image) using Aspose.Imaging
                using (Image image = Image.Load(svgPath))
                {
                    // Cast to VectorImage to access embedded raster images
                    VectorImage vectorImage = image as VectorImage;
                    if (vectorImage == null)
                    {
                        // Not a vector image; skip
                        continue;
                    }

                    // Retrieve embedded images
                    EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                    int index = 0;

                    foreach (EmbeddedImage embedded in embeddedImages)
                    {
                        using (embedded)
                        {
                            // The EmbeddedImage provides an Image instance
                            using (Image embeddedImg = embedded.Image)
                            {
                                // Create a thumbnail (e.g., 100x100) while preserving aspect ratio
                                const int thumbSize = 100;
                                int originalWidth = embeddedImg.Width;
                                int originalHeight = embeddedImg.Height;

                                // Determine scaling factor
                                double scale = Math.Min((double)thumbSize / originalWidth, (double)thumbSize / originalHeight);
                                int thumbWidth = (int)(originalWidth * scale);
                                int thumbHeight = (int)(originalHeight * scale);

                                // Resize to thumbnail dimensions
                                embeddedImg.Resize(thumbWidth, thumbHeight);

                                // Build output file path
                                string baseName = Path.GetFileNameWithoutExtension(svgPath);
                                string outFileName = $"{baseName}_img{index}.png";
                                string outPath = Path.Combine(outputDirectory, outFileName);

                                // Ensure the directory for the output file exists
                                Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                                // Save the thumbnail as PNG
                                embeddedImg.Save(outPath, new PngOptions());
                            }
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
 * 1. When a web application needs to generate preview thumbnails for all raster graphics embedded inside a collection of SVG icons stored on a server.
 * 2. When a design workflow requires extracting high‑resolution bitmap assets from SVG logos to reuse them in print or mobile assets.
 * 3. When an automated build process must convert embedded images in SVG diagrams to PNG files for compatibility with legacy systems that cannot render SVG.
 * 4. When a content management system needs to batch‑process uploaded SVG files and store their embedded pictures as separate PNG thumbnails for faster loading in galleries.
 * 5. When a data‑migration script has to harvest raster images from SVG files and save them as PNGs to archive or index them in a digital asset database.
 */
