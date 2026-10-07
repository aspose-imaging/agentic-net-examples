// HOW-TO: Batch Crop Images to 16:9 Aspect Ratio and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputDirectory = "input";
        string outputDirectory = "output";

        try
        {
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string filePath in files)
            {
                string inputPath = filePath;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    int width = image.Width;
                    int height = image.Height;
                    double targetAspect = 16.0 / 9.0;
                    double currentAspect = (double)width / height;

                    int left = 0, right = 0, top = 0, bottom = 0;

                    if (currentAspect > targetAspect)
                    {
                        // Image is too wide, crop left and right
                        int newWidth = (int)(height * targetAspect);
                        int excess = width - newWidth;
                        left = excess / 2;
                        right = excess - left;
                    }
                    else if (currentAspect < targetAspect)
                    {
                        // Image is too tall, crop top and bottom
                        int newHeight = (int)(width / targetAspect);
                        int excess = height - newHeight;
                        top = excess / 2;
                        bottom = excess - top;
                    }
                    // If aspect is already 16:9, no cropping needed (all zeros)

                    if (left != 0 || right != 0 || top != 0 || bottom != 0)
                    {
                        image.Crop(left, right, top, bottom);
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var svgOptions = new SvgOptions();
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to prepare a large set of photos for a web video gallery that requires every thumbnail to be 16:9 and delivered as scalable SVG files.
 * 2. When an e‑learning platform must automatically trim uploaded screenshots to a widescreen format before converting them to SVG for resolution‑independent rendering.
 * 3. When a marketing team wants to batch‑process product images so they fit a 16:9 banner layout and can be edited in vector graphics tools.
 * 4. When a mobile app generates screenshots that must be cropped to a consistent aspect ratio and saved as SVG to reduce file size on low‑bandwidth connections.
 * 5. When a digital signage system needs to convert a folder of raster images into 16:9 SVG assets for seamless scaling on various display sizes.
 */
