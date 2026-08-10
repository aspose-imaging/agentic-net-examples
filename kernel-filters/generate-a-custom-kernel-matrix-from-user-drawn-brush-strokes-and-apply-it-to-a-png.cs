// HOW-TO: Apply Custom Sharpen Convolution Kernel to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

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

            // Load the source PNG as a raster image
            using (Image inputImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)inputImage;

                // Define a custom convolution kernel (e.g., sharpen)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Prepare PNG save options
                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
                raster.Save();
                // Since the image was created from a file source, use Canvas.Save()
                // (Image.Create with FileCreateSource binds the output file)
                // Here we loaded from a file, so we can use Save with options
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
 * 1. When you need to enhance the edges of a PNG photograph programmatically in a .NET application.
 * 2. When you want to implement a custom image filter, such as sharpening, using a user‑defined kernel with Aspose.Imaging.
 * 3. When you must process large batches of PNG files on a server and apply the same convolution effect automatically.
 * 4. When you are building a graphics editor that lets users draw brush strokes to define a filter matrix and then apply it to an image.
 * 5. When you need to improve the visual clarity of scanned PNG documents before saving them to disk.
 */
