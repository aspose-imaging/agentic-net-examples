using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "templates/input.png";
        string outputPath = "output/embossed.png";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply the predefined Emboss3x3 convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer wants to add a 3‑D embossed effect to product photos stored as PNG files before uploading them to an e‑commerce website, they can use this code to load the image, apply the Emboss3x3 convolution filter, and save the result.
 * 2. When generating printable marketing materials, a designer may need to programmatically enhance PNG logos with a subtle emboss effect using C# and Aspose.Imaging to ensure consistent visual style across all assets.
 * 3. When building an automated image‑processing pipeline that converts scanned PNG documents into stylized graphics, the code can be used to apply the predefined Emboss3x3 filter to each page for a tactile appearance.
 * 4. When creating a desktop application that lets users preview artistic filters on their PNG images, developers can employ this snippet to demonstrate the emboss filter in real time by loading the image, filtering it, and saving the preview.
 * 5. When preparing PNG icons for a mobile app and wanting to add depth without manual editing, the code provides a quick C# solution to apply a convolution‑based emboss effect and output the modified PNG for inclusion in the app bundle.
 */