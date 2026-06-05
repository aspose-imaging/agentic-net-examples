using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\filtered.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the input image into a memory stream
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (MemoryStream inputMemory = new MemoryStream())
            {
                fileStream.CopyTo(inputMemory);
                inputMemory.Position = 0;

                // Load image from the memory stream
                using (Image image = Image.Load(inputMemory))
                {
                    RasterImage raster = (RasterImage)image;

                    // Apply a Gaussian blur filter using ConvolutionFilter
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image to another memory stream
                    using (MemoryStream outputMemory = new MemoryStream())
                    {
                        raster.Save(outputMemory, new PngOptions());
                        // Write the memory stream to the output file
                        File.WriteAllBytes(outputPath, outputMemory.ToArray());
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
 * 1. When a web API receives a PNG upload and must apply a Gaussian blur filter before returning the image, developers can stream the data through a MemoryStream with Aspose.Imaging to avoid creating temporary files on the server.
 * 2. When a background Windows service processes scanned documents in bulk, it can load each image into memory, apply convolution-based sharpening or blurring, and save the result directly to another stream for fast disk I/O.
 * 3. When an Azure Function needs to resize and filter user‑submitted images on the fly, using MemoryStream with the ConvolutionFilter lets the function stay stateless and eliminates file‑system dependencies.
 * 4. When a desktop application lets users preview real‑time filter effects on PNG files without cluttering the temp folder, the code streams the original image, applies the filter, and writes the output back to memory for immediate display.
 * 5. When a CI/CD pipeline validates image assets by programmatically applying a Gaussian blur to detect artifacts, streaming the input and output images keeps the build environment clean and speeds up processing.
 */