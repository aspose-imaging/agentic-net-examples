using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a zero‑sum edge detection kernel (simple vertical edge detector)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    {  0,  0,  0 },
                    {  1,  1,  1 }
                };

                // Apply convolution filter with the kernel
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Verify that the background is black and edges are highlighted
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                bool edgeFound = pixels.Any(p => p != unchecked((int)0xFF000000)); // ARGB black = 0xFF000000

                if (edgeFound)
                {
                    Console.WriteLine("Edges detected: background is black with highlighted edges.");
                }
                else
                {
                    Console.WriteLine("No edges detected: image appears uniformly black.");
                }

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to extract structural outlines from a scanned PNG blueprint for further vectorization, they can apply a zero‑sum edge detection kernel to highlight edges against a black background.
 * 2. When building a C# desktop application that automatically detects product defects in PNG photos of manufactured parts, the code can be used to emphasize edge anomalies before analysis.
 * 3. When creating a preprocessing step for a machine‑learning pipeline that classifies handwritten PNG signatures, applying the convolution filter isolates stroke edges while turning the rest of the image black.
 * 4. When generating visual previews for a web service that shows only the contours of PNG logos, the zero‑sum kernel produces a high‑contrast edge map that can be stored as a lightweight PNG.
 * 5. When validating that a PNG image has been correctly processed by an image‑processing workflow, the code verifies that the background is uniformly black and that edge pixels are highlighted, ensuring the convolution filter worked as intended.
 */