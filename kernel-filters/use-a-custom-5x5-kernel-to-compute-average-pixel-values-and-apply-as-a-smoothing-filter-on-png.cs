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

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Create a 5x5 averaging kernel (each element = 1/25)
                double[,] kernel = new double[5, 5];
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        kernel[y, x] = 1.0 / 25.0;
                    }
                }

                // Apply the custom convolution filter (smoothing)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Prepare PNG save options
                PngOptions options = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    BitDepth = 8,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to reduce noise in a PNG photograph by applying a 5x5 averaging convolution filter in C# using Aspose.Imaging.
 * 2. When a web application must preprocess user‑uploaded PNG avatars to smooth edges before storing them on the server.
 * 3. When a batch job processes scanned PNG documents to create a uniform, softened appearance for better OCR accuracy.
 * 4. When a game developer wants to generate a blurred background texture from a PNG asset by applying a custom kernel with Aspose.Imaging.
 * 5. When an image‑analysis pipeline requires a simple smoothing step on PNG images to normalize pixel values before further processing.
 */