using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to soften a high‑resolution scanned TIFF document (e.g., a blueprint or photograph) before publishing it on a website, they can apply a Gaussian blur with radius five and save the result as a PNG for web‑friendly delivery.
 * 2. When preparing archival TIFF images for inclusion in a PDF report, a developer may blur sensitive details using a radius‑5 Gaussian filter and convert the output to PNG to reduce file size while preserving transparency.
 * 3. When building an automated image‑processing pipeline that receives TIFF files from a scanner, a developer can use this code to smooth the images with a Gaussian blur (radius 5) and store them as PNGs for downstream machine‑learning models that require a consistent format.
 * 4. When creating thumbnail previews of large TIFF photographs for a digital asset management system, a developer can apply a radius‑5 Gaussian blur to reduce visual noise and then save the thumbnails as PNGs for fast loading.
 * 5. When a developer must comply with a client’s branding guidelines that require all exported images to have a subtle soft‑focus effect, they can blur the original TIFF using a radius of five and output the final image in PNG format for use in marketing materials.
 */