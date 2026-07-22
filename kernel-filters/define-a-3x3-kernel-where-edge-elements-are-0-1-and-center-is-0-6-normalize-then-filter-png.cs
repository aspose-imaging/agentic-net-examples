using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

                // Define the 3x3 kernel with edge = 0.1 and center = 0.6
                double[,] kernel = new double[3, 3]
                {
                    { 0.1, 0.1, 0.1 },
                    { 0.1, 0.6, 0.1 },
                    { 0.1, 0.1, 0.1 }
                };

                // Normalize the kernel so that the sum equals 1
                double sum = 0;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        sum += kernel[i, j];

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        kernel[i, j] /= sum;

                // Create convolution filter options with the normalized kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Prepare PNG save options
                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the filtered image as PNG
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
 * 1. When a developer needs to apply a custom smoothing filter to a PNG image in a C# application using Aspose.Imaging for .NET, they can define a 3×3 kernel with edge values of 0.1 and a center value of 0.6, normalize it, and filter the image.
 * 2. When building an automated image preprocessing pipeline that prepares PNG files for OCR or machine‑learning models, the code can be used to reduce noise by applying a normalized convolution kernel via Aspose.Imaging’s Filter method.
 * 3. When creating a desktop photo‑editing tool that lets users adjust the blur intensity of PNG pictures, the developer can employ this C# snippet to implement a lightweight custom blur using a 3×3 kernel and Aspose.Imaging’s ConvolutionFilterOptions.
 * 4. When integrating image processing into a .NET web service that receives PNG uploads and must standardize visual quality before storage, the code provides a straightforward way to apply a normalized convolution filter with Aspose.Imaging.
 * 5. When performing batch processing of PNG assets for a game or UI skin where a subtle softening effect is required, the developer can reuse this example to loop through files, normalize the kernel, and apply the filter using Aspose.Imaging for .NET.
 */