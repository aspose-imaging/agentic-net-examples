// HOW-TO: Convert BMP to SVG with Inverted Colors Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg; // Required for SVG handling

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Apply a simple custom color filter (invert colors)
                if (image is RasterImage raster)
                {
                    for (int y = 0; y < raster.Height; y++)
                    {
                        for (int x = 0; x < raster.Width; x++)
                        {
                            // Get the current pixel
                            Color original = raster.GetPixel(x, y);

                            // Invert RGB channels while preserving alpha
                            Color filtered = Color.FromArgb(
                                original.A,
                                (byte)(255 - original.R),
                                (byte)(255 - original.G),
                                (byte)(255 - original.B));

                            // Set the new pixel value
                            raster.SetPixel(x, y, filtered);
                        }
                    }
                }

                // Export the filtered image as SVG with default options
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate scalable vector graphics from legacy BMP assets while applying a color inversion for a dark‑mode UI.
 * 2. When you want to programmatically recolor a bitmap image and export it as SVG for responsive web design.
 * 3. When you must batch‑process scanned BMP files, apply a custom filter, and store the results in a resolution‑independent format.
 * 4. When you are building a C# tool that converts user‑uploaded BMP icons into SVG icons with a specific color scheme.
 * 5. When you require an automated way to transform raster images into vector format with custom pixel‑level color adjustments for printing pipelines.
 */
