using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string[] inputPaths = {
            @"C:\Images\scanned_noisy_1.png",
            @"C:\Images\scanned_noisy_2.png"
        };

        string[] outputPaths = {
            @"C:\Images\processed\scanned_noisy_1_emboss.png",
            @"C:\Images\processed\scanned_noisy_2_emboss.png"
        };

        try
        {
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply the 5x5 Emboss convolution filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                    // Save the filtered image
                    rasterImage.Save(outputPath);
                }

                // -----------------------------------------------------------------
                // Placeholder: Run OCR on both the original and filtered images,
                // compare the recognized text with ground‑truth data, and compute
                // accuracy metrics (e.g., character error rate). Store or display
                // the results as needed.
                // -----------------------------------------------------------------
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}