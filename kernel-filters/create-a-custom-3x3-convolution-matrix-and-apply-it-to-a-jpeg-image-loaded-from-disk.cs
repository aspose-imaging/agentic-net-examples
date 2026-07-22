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
            string inputPath = "input.jpg";
            string outputPath = "output\\output.jpg";

            // Verify input file exists
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
                RasterImage rasterImage = (RasterImage)image;

                // Define a custom 3x3 convolution kernel (edge detection example)
                double[,] kernel = new double[3, 3]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply the custom convolution filter to the entire image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Save the processed image as JPEG
                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a developer needs to detect edges in a JPEG photograph by applying a custom 3x3 convolution matrix for computer‑vision preprocessing.
 * 2. When an application must enhance the contrast of scanned documents by running an edge‑detection filter on raster images loaded from disk.
 * 3. When a photo‑editing tool requires applying a user‑defined convolution kernel to batch‑process JPEG files and save the results with specific JpegOptions.
 * 4. When a C# service processes incoming image uploads and needs to perform real‑time edge detection before storing the processed JPEG in a server folder.
 * 5. When a developer wants to experiment with custom image filters in Aspose.Imaging by loading a JPEG, applying a 3x3 kernel, and saving the transformed image to a new directory.
 */