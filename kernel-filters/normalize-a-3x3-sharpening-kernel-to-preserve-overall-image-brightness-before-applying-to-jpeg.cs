using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Retrieve the built‑in 3×3 sharpen kernel
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3;

                // Create convolution filter options with the kernel
                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the sharpen filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, convOptions);

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Save the processed image
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to enhance the detail of a JPEG photo in a C# application without changing its overall brightness, they can apply the normalized 3×3 sharpening kernel using Aspose.Imaging’s convolution filter.
 * 2. When building an automated image‑processing pipeline that receives raw JPEG uploads and must improve sharpness before storage, this code demonstrates how to load, filter, and save the image with Aspose.Imaging in .NET.
 * 3. When creating a desktop utility that lets users batch‑sharpen JPEG images while preserving exposure levels, the example shows the necessary file‑validation, raster conversion, and JPEG save options.
 * 4. When integrating image enhancement into a web service that processes user‑submitted JPEGs, developers can use this snippet to apply a 3×3 sharpen filter and return the processed image without altering its brightness.
 * 5. When troubleshooting visual quality issues in a C# photo‑editing tool, the code provides a clear way to test the effect of a normalized sharpening kernel on JPEG files using Aspose.Imaging’s filter API.
 */