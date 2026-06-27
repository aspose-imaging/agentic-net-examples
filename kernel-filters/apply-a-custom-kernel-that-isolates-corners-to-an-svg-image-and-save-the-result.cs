using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Create rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };

                // Save the rasterized SVG to a temporary PNG file
                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                var pngSaveOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPngPath, pngSaveOptions);

                // Load the rasterized PNG for filtering
                using (Image rasterImg = Image.Load(tempPngPath))
                {
                    var raster = (RasterImage)rasterImg;

                    // Define a custom kernel that isolates corners (edge detection)
                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Apply convolution filter with the custom kernel
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                    // Save the filtered image to the final output path
                    raster.Save(outputPath, new PngOptions());
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When a developer needs to extract and highlight the corner features of a vector logo stored as an SVG for use in a thumbnail preview, they can rasterize the SVG, apply a corner‑detecting kernel, and save the result as a PNG.
 * 2. When creating a printable brochure that requires sharp corner emphasis on SVG icons, a C# routine can isolate those corners with a custom convolution filter before exporting to a high‑resolution PNG.
 * 3. When building an automated quality‑control tool that flags poorly defined corners in SVG diagrams, the code can rasterize each file, run the corner‑isolation kernel, and store the processed image for visual inspection.
 * 4. When generating stylized map markers where only the corner outlines of SVG shapes should be visible, developers can apply the custom kernel to isolate corners and output the markers as PNG assets.
 * 5. When developing a web service that converts user‑uploaded SVG illustrations into edge‑enhanced PNGs for faster loading, the custom corner detection filter ensures the most prominent corners are retained in the final image.
 */