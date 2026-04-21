using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.png";
            string outputPath = "output\\result.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG image as a raster image
            using (Image srcImage = Image.Load(inputPath))
            {
                RasterImage rasterSrc = (RasterImage)srcImage;

                // Define kernel size (e.g., 5x5)
                int kernelSize = 5;

                // Create a temporary PNG canvas to draw brush strokes
                using (PngImage kernelImg = new PngImage(kernelSize, kernelSize))
                {
                    // Draw a simple brush stroke (filled black circle) on white background
                    Graphics graphics = new Graphics(kernelImg);
                    graphics.Clear(Color.White);
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        graphics.FillEllipse(brush, new Rectangle(0, 0, kernelSize, kernelSize));
                    }

                    // Extract ARGB pixel data from the brush stroke canvas
                    int[] argbPixels = kernelImg.LoadArgb32Pixels(kernelImg.Bounds);

                    // Convert pixel data to a double[,] kernel (grayscale intensity normalized to 0‑1)
                    double[,] customKernel = new double[kernelSize, kernelSize];
                    for (int y = 0; y < kernelSize; y++)
                    {
                        for (int x = 0; x < kernelSize; x++)
                        {
                            int pixel = argbPixels[y * kernelSize + x];
                            // Extract RGB components
                            double r = (pixel >> 16) & 0xFF;
                            double g = (pixel >> 8) & 0xFF;
                            double b = pixel & 0xFF;
                            // Convert to luminance (simple average) and normalize
                            double intensity = (r + g + b) / (3.0 * 255.0);
                            customKernel[y, x] = intensity;
                        }
                    }

                    // Apply the custom convolution kernel to the source image
                    rasterSrc.Filter(rasterSrc.Bounds, new ConvolutionFilterOptions(customKernel));

                    // Save the processed image as PNG
                    PngOptions saveOptions = new PngOptions();
                    rasterSrc.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}