using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom 3x3 diagonal edge‑detection kernel
                double[,] kernel = new double[,]
                {
                    { -1, -1, 0 },
                    { -1,  0, 1 },
                    {  0,  1, 1 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to highlight diagonal edges in a PNG photograph for a computer‑vision preprocessing step, they can use this Aspose.Imaging C# code to apply a custom 3×3 convolution kernel.
 * 2. When building an automated quality‑control pipeline that flags defects along diagonal lines in scanned product images, the code can process each PNG file and output an edge‑enhanced version for further analysis.
 * 3. When creating a visual effect for a game asset where diagonal outlines must be emphasized, the developer can load the PNG sprite, run the custom diagonal edge‑detection filter, and save the result using Aspose.Imaging.
 * 4. When integrating image‑processing into a .NET web service that receives user‑uploaded PNGs and returns a version with highlighted edges for artistic filters, this code provides the necessary raster filtering and saving steps.
 * 5. When preparing training data for a machine‑learning model that requires edge maps of PNG images, a developer can use the sample to generate diagonal edge maps by applying the convolution filter before feeding the images to the model.
 */