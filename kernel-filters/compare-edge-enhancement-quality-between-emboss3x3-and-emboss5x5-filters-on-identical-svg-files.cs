using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath3x3 = @"C:\Images\Result\sample_emboss3x3.png";
        string outputPath5x5 = @"C:\Images\Result\sample_emboss5x5.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3x3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5x5));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize the SVG to a raster image
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Apply 3x3 emboss filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save result of 3x3 emboss
                    rasterImage.Save(outputPath3x3);
                }
            }

            // Reload the original SVG for the second filter to avoid cumulative effects
            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Apply 5x5 emboss filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                    // Save result of 5x5 emboss
                    rasterImage.Save(outputPath5x5);
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
 * 1. When a web designer wants to preview how different emboss filters affect the visual depth of SVG icons before publishing them on a responsive website.
 * 2. When a GIS analyst needs to generate side‑by‑side rasterized PNG maps from SVG layers to evaluate which convolution filter (Emboss3x3 vs Emboss5x5) best highlights terrain edges for printed reports.
 * 3. When a mobile app developer is creating an asset pipeline that converts SVG assets to PNG textures and must compare edge‑enhancement quality to choose the optimal filter for low‑resolution game graphics.
 * 4. When a branding team requires automated batch processing of SVG logos to produce embossed PNG versions and wants to test whether the 3×3 or 5×5 kernel preserves fine line details for marketing materials.
 * 5. When a machine‑learning engineer prepares training data by applying different convolution filters to identical SVG drawings and needs to assess which filter yields clearer edge features for image classification models.
 */