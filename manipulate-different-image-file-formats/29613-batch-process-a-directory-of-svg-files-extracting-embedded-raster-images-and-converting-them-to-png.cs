using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputSvgs";
            string outputDirectory = "Thumbnails";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    VectorImage vectorImage = (VectorImage)image;
                    EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

                    for (int i = 0; i < embeddedImages.Length; i++)
                    {
                        EmbeddedImage embedded = embeddedImages[i];
                        using (embedded)
                        {
                            using (RasterImage raster = (RasterImage)embedded.Image)
                            {
                                const int maxSize = 150;
                                int newWidth = raster.Width;
                                int newHeight = raster.Height;

                                if (raster.Width > raster.Height)
                                {
                                    if (raster.Width > maxSize)
                                    {
                                        newWidth = maxSize;
                                        newHeight = raster.Height * maxSize / raster.Width;
                                    }
                                }
                                else
                                {
                                    if (raster.Height > maxSize)
                                    {
                                        newHeight = maxSize;
                                        newWidth = raster.Width * maxSize / raster.Height;
                                    }
                                }

                                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                                string baseName = Path.GetFileNameWithoutExtension(inputPath) + $"_thumb_{i}.png";
                                string outputPath = Path.Combine(outputDirectory, baseName);
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                                raster.Save(outputPath);
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

/*
 * Real-World Use Cases:
 * 1. When a web designer wants to generate preview thumbnails for all SVG icons that contain embedded PNG or JPEG images, they can run this C# batch process to extract those raster assets and create 150‑pixel PNG previews for a style guide.
 * 2. When a digital asset management system needs to index and display small preview images for SVG files that embed photographs, the code can scan the assets folder, pull out the embedded raster layers, and store them as uniform PNG thumbnails.
 * 3. When an e‑learning platform imports course illustrations stored as SVGs with embedded bitmap diagrams, the developer can use this routine to automatically extract the diagrams and generate lightweight PNG thumbnails for the course catalog.
 * 4. When a mobile app prepares offline content and must reduce SVG file size by separating embedded raster images into separate PNG assets, this script extracts the images and resizes them to a maximum of 150 px for faster loading.
 * 5. When a CI/CD pipeline validates visual assets and needs to verify that every SVG in a repository contains correctly sized raster thumbnails, the batch code can pull the embedded images, resize them, and save PNG previews for automated comparison.
 */