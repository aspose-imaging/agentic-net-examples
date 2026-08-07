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
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a blur box filter (size 5)
                rasterImage.Filter(rasterImage.Bounds,
                    new ConvolutionFilterOptions(ConvolutionFilter.GetBlurBox(5)));

                // Apply an emboss filter (3x3 kernel)
                rasterImage.Filter(rasterImage.Bounds,
                    new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Apply a sharpen filter (kernel size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds,
                    new SharpenFilterOptions(5, 4.0));

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
 * 1. When creating a stylized product catalog where each product photo (JPEG) needs a soft blur, artistic emboss, and crisp sharpening to enhance visual appeal before publishing online.
 * 2. When building a desktop C# application that automatically prepares user‑uploaded JPEG avatars with a subtle blur, embossed texture, and final sharpen to meet a brand’s visual guidelines.
 * 3. When developing a batch‑processing script that applies a complex filter chain (blur box, emboss, sharpen) to a folder of JPEG images for a marketing campaign’s “vintage‑modern” look.
 * 4. When implementing a photo‑editing feature in a .NET web service that lets clients upload JPEGs and returns a version with layered blur, emboss, and sharpen effects using Aspose.Imaging.
 * 5. When optimizing images for an e‑learning platform where JPEG illustrations require a gentle blur to reduce noise, an emboss to highlight edges, and a sharpen step to retain readability after compression.
 */