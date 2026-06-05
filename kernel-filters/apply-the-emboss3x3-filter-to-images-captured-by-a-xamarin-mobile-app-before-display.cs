using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the image and apply Emboss3x3 filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(outputPath);
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
 * 1. When a Xamarin.Forms app needs to add a stylized embossed effect to user‑taken JPEG photos before showing them in a gallery view, the developer can load the image with Aspose.Imaging, apply the Emboss3x3 convolution filter, and save the processed file for display.
 * 2. When an e‑commerce mobile application wants to highlight product textures by converting uploaded PNG images into embossed previews on the fly, the code demonstrates how to perform the convolution filter in C# and render the result instantly.
 * 3. When a travel‑journal app captures landscape pictures and wants to give them a vintage relief look without using heavy GPU shaders, the Emboss3x3 filter can be applied server‑side or on‑device using the provided raster image processing steps.
 * 4. When a social‑media platform integrates a custom photo‑editing feature that adds a 3‑x‑3 emboss effect to images before sharing, developers can use the Aspose.Imaging ConvolutionFilterOptions to transform the bitmap and store the output as a JPEG.
 * 5. When a medical‑imaging Xamarin app needs to emphasize surface details of scanned tissue images by applying an emboss filter to DICOM‑converted BMP files, this code shows how to load, filter, and save the enhanced image using C#.
 */