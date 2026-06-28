using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output_embossed.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, apply the emboss filter, and save the result
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                // Apply the 3x3 emboss kernel to the whole image
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                rasterImage.Save(outputPath);
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
 * 1. When a Xamarin mobile app needs to display user‑captured photos with a stylized 3×3 emboss effect, applying the Aspose.Imaging ConvolutionFilter.Emboss3x3 in C# before rendering the JPEG on screen.
 * 2. When an e‑commerce application wants to generate embossed preview thumbnails (JPEG or PNG) of product images on the fly using Aspose.Imaging’s raster filter to enhance visual appeal.
 * 3. When a social‑media sharing feature must apply a real‑time emboss filter to images taken on iOS or Android devices, saving the processed image as a JPEG for immediate upload.
 * 4. When a document‑scanning solution built with Xamarin requires converting scanned pages to an embossed look for artistic PDF generation, using the Emboss3x3 convolution filter in C#.
 * 5. When a travel‑guide app creates embossed map snapshots (PNG) from raster images to give a tactile feel, applying the Aspose.Imaging emboss filter before caching the result locally.
 */