using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
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

            // Kernel providers (dependency injection simulation)
            Func<double[,]> predefinedKernelProvider = () => Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
            Func<double[,]> customKernelProvider = () =>
            {
                // Example custom 3x3 kernel
                return new double[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
            };

            // Choose provider at runtime
            bool usePredefined = true; // Set to false to use custom kernel
            Func<double[,]> selectedProvider = usePredefined ? predefinedKernelProvider : customKernelProvider;

            // Load image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Create convolution filter options with the selected kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(selectedProvider());

                // Apply filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image using PNG options
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a photo‑editing web service lets users pick either a standard emboss filter or a custom artistic emboss effect, developers can inject the appropriate kernel at runtime.
 * 2. When an automated batch‑processing pipeline applies a fast built‑in emboss kernel to most images but switches to a specially tuned kernel for high‑resolution satellite photos, the DI‑based selection provides the needed flexibility.
 * 3. When a desktop application offers a quick “preview” mode using the predefined emboss kernel and a high‑quality mode that applies a user‑defined kernel for print‑ready output, this pattern lets the app swap kernels without altering filter code.
 * 4. When a machine‑learning preprocessing step requires different edge‑enhancement kernels for training versus inference datasets, developers can configure the kernel provider via dependency injection to select the correct convolution matrix at runtime.
 * 5. When a digital asset management system generates thumbnails with a default emboss effect but applies a custom kernel for brand‑specific watermark styling, the code enables seamless runtime switching between the two kernels.
 */