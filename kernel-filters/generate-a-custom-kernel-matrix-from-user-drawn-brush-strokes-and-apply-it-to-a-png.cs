// HOW-TO: Create Custom Convolution Kernel from Brush Strokes and Apply to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG as a raster image
            using (Aspose.Imaging.Image inputImage = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)inputImage;

                // Create a small temporary image to capture brush strokes (5x5)
                using (PngImage kernelImg = new PngImage(5, 5))
                {
                    // Draw a simple diagonal stroke
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(kernelImg);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1);
                    graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(4, 4));

                    // Extract ARGB pixels and convert to a grayscale kernel matrix
                    int[] argbPixels = kernelImg.LoadArgb32Pixels(kernelImg.Bounds);
                    double[,] kernel = new double[5, 5];
                    for (int y = 0; y < 5; y++)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            int pixel = argbPixels[y * 5 + x];
                            // Compute luminance using Rec. 601 coefficients
                            double r = (pixel >> 16) & 0xFF;
                            double g = (pixel >> 8) & 0xFF;
                            double b = pixel & 0xFF;
                            double lum = 0.299 * r + 0.587 * g + 0.114 * b;
                            // Normalize to range [-1,1] for convolution kernel
                            kernel[y, x] = (lum / 255.0) * 2.0 - 1.0;
                        }
                    }

                    // Apply the custom convolution filter to the original image
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
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
 * 1. When you need to simulate a hand‑drawn filter effect by converting a user’s brush stroke into a convolution matrix for a PNG image.
 * 2. When you want to generate a custom sharpening or edge‑detect filter based on a small sketch and apply it to photographs in a .NET application.
 * 3. When building an image‑editing tool that lets users draw their own kernels and instantly see the result on uploaded PNG files.
 * 4. When automating batch processing of PNG assets with dynamically created filters derived from designer‑provided stroke patterns.
 * 5. When creating artistic effects such as motion blur or emboss by converting simple line drawings into grayscale kernels for raster image manipulation.
 */
