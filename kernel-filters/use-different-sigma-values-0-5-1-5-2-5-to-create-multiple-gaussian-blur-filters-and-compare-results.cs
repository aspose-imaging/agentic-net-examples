using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = @"c:\temp\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Sigma values to apply
        double[] sigmaValues = { 0.5, 1.5, 2.5 };

        try
        {
            foreach (double sigma in sigmaValues)
            {
                // Construct output path for each sigma
                string outputPath = $@"c:\temp\sample.GaussianBlur_{sigma}.png";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Gaussian blur with a kernel size of 5 and the current sigma
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, sigma));

                    // Save the filtered image
                    rasterImage.Save(outputPath);
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
 * 1. When a developer needs to generate PNG thumbnails with varying levels of softness for a photo‑gallery website, they can use this C# Aspose.Imaging code to apply Gaussian blur with sigma 0.5, 1.5, and 2.5 and compare the visual results.
 * 2. When preparing training data for a computer‑vision model, a developer can use the code to create multiple blurred versions of the same image to augment the dataset and test the model’s robustness to different blur intensities.
 * 3. When building a document‑scanning application that must reduce noise while preserving text edges, a developer can experiment with sigma 0.5, 1.5, and 2.5 using Aspose.Imaging’s GaussianBlurFilterOptions to find the optimal blur strength before saving the output as PNG.
 * 4. When implementing a visual‑effects pipeline for a Windows desktop app, a developer can run this code to compare how a 5‑pixel kernel with low, medium, and high sigma values affects the perceived smoothness of UI icons stored in PNG format.
 * 5. When creating a before‑and‑after comparison tool for marketing materials, a developer can use the sample to automatically generate three blurred copies of a source image, each with a different sigma, and save them to a folder for side‑by‑side review.
 */