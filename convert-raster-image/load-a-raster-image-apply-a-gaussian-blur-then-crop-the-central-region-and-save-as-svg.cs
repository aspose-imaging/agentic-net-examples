// HOW-TO: Apply Gaussian Blur, Crop Center, and Save Raster Image as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering and cropping
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Calculate central crop rectangle (half width and height)
                int cropWidth = raster.Width / 2;
                int cropHeight = raster.Height / 2;
                int cropX = (raster.Width - cropWidth) / 2;
                int cropY = (raster.Height - cropHeight) / 2;
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Crop the image to the central region
                raster.Crop(cropRect);

                // Create an SVG graphics context with the size of the cropped image
                const int dpi = 96;
                var svgGraphics = new SvgGraphics2D(raster.Width, raster.Height, dpi);

                // Draw the processed raster image onto the SVG canvas
                svgGraphics.DrawImage(raster, new Point(0, 0));

                // Finalize SVG recording and save
                using (SvgImage svgImage = svgGraphics.EndRecording())
                {
                    svgImage.Save(outputPath);
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
 * 1. When you need to soften a PNG photo with a Gaussian blur, extract its central area, and embed the result in an SVG for responsive web graphics.
 * 2. When generating thumbnails for a web app that require a blurred background and a centered crop, then exporting them as scalable SVG icons.
 * 3. When preparing print‑ready assets by applying a blur effect, focusing on the middle portion of an image, and saving it in vector format to retain quality at any size.
 * 4. When converting raster screenshots into SVG diagrams while automatically cropping to the most important region and adding a subtle blur for visual emphasis.
 * 5. When building a C# automation script that processes batches of images, applies a Gaussian blur, crops the center, and stores the output as SVG files using Aspose.Imaging.
 */
