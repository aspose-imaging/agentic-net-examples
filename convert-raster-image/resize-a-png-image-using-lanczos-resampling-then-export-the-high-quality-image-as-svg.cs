// HOW-TO: Resize PNG with Lanczos Resampling and Export as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize using Lanczos resampling (high‑quality)
                // Example: double the size; adjust as needed
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Set the page size to match the resized image dimensions
                    PageSize = new Size(image.Width, image.Height),

                    // Optional: improve quality settings
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the resized image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to enlarge a raster PNG for high‑resolution web graphics while preserving detail, you can resize it with Lanczos resampling and save the result as an SVG for scalable display.
 * 2. When generating printable assets from PNG logos, resizing them with a high‑quality filter and exporting to SVG ensures crisp output at any print size.
 * 3. When building a C# application that converts user‑uploaded PNG icons into scalable SVG icons for UI themes, this code provides the necessary resizing and format conversion.
 * 4. When preparing images for responsive mobile apps, you can double the PNG dimensions with Lanczos resampling and embed the result in an SVG to maintain sharpness across screen densities.
 * 5. When automating batch processing of PNG screenshots that must be embedded in vector‑based documentation, this routine resizes each image and outputs SVG files compatible with PDF or HTML reports.
 */
