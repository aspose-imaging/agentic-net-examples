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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (Image image = Image.Load(inputPath))
                {
                    VectorImage vectorImage = image as VectorImage;
                    if (vectorImage == null)
                        continue;

                    EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                    int index = 0;
                    foreach (EmbeddedImage embedded in embeddedImages)
                    {
                        using (embedded)
                        {
                            RasterImage raster = embedded.Image as RasterImage;
                            if (raster == null)
                                continue;

                            const int thumbSize = 100;
                            if (raster.Width > raster.Height)
                            {
                                int newWidth = thumbSize;
                                int newHeight = (int)((float)thumbSize * raster.Height / raster.Width);
                                raster.Resize(newWidth, newHeight);
                            }
                            else
                            {
                                int newHeight = thumbSize;
                                int newWidth = (int)((float)thumbSize * raster.Width / raster.Height);
                                raster.Resize(newWidth, newHeight);
                            }

                            string baseName = Path.GetFileNameWithoutExtension(inputPath);
                            string outputPath = Path.Combine(outputDirectory, $"{baseName}_{index}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            PngOptions pngOptions = new PngOptions();
                            raster.Save(outputPath, pngOptions);
                            index++;
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

/*
 * Real-World Use Cases:
 * 1. When a web designer needs to generate preview thumbnails for all raster images embedded in a collection of SVG icons stored in a folder, they can use this code to extract the images and save them as small PNG files.
 * 2. When a content management system must index visual assets by creating low‑resolution PNG previews of embedded photos inside SVG diagrams, the batch process automates extraction and thumbnail creation.
 * 3. When an e‑learning platform wants to display quick previews of embedded screenshots within SVG lesson illustrations, the code can scan the SVG directory, pull out the raster images, and output 100‑pixel PNG thumbnails for faster loading.
 * 4. When a digital asset manager needs to audit a repository of SVG marketing assets by extracting all embedded raster graphics and storing them as PNG thumbnails for quality checks, this C# routine provides an efficient solution.
 * 5. When a mobile app development team prepares asset bundles and requires small PNG previews of embedded raster images inside SVG UI assets for documentation purposes, the batch processing script fulfills that need.
 */