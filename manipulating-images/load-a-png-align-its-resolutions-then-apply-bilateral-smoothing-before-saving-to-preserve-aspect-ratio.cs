using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to PngImage for PNG‑specific members
                PngImage pngImage = (PngImage)image;

                // Align horizontal and vertical resolutions (make them equal)
                double hRes = pngImage.HorizontalResolution;
                double vRes = pngImage.VerticalResolution;
                if (hRes != vRes)
                {
                    // Set both resolutions to the horizontal value (or any desired value)
                    pngImage.SetResolution(hRes, hRes);
                }

                // Apply bilateral smoothing filter to the entire image
                RasterImage rasterImage = (RasterImage)pngImage;
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                pngImage.Save(outputPath);
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
 * 1. When a web application must standardize the DPI of uploaded PNG icons before displaying them on high‑resolution screens, a developer can use this code to align horizontal and vertical resolutions and smooth the image without distorting its aspect ratio.
 * 2. When an e‑commerce platform needs to preprocess product photos stored as PNG files to ensure consistent print quality, the code can equalize the image’s resolution and apply bilateral smoothing to reduce noise while keeping edges sharp.
 * 3. When a desktop publishing tool imports user‑provided PNG graphics and must preserve their original proportions while removing compression artifacts, this snippet aligns the resolutions and runs a bilateral smoothing filter before saving.
 * 4. When a scientific imaging workflow requires converting scanned PNG microscopy images to a uniform DPI for accurate measurements, the developer can employ this code to set matching resolutions and denoise the image without altering its aspect ratio.
 * 5. When a mobile game engine loads PNG textures and wants to guarantee that the texture’s horizontal and vertical DPI are identical and that the texture is smoothed to avoid visual jitter, this example provides the necessary C# steps using Aspose.Imaging.
 */