using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output\\resized.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Desired size (example: double the original size)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using nearest‑neighbor interpolation
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Save the resized image as SVG
                var svgOptions = new SvgOptions(); // default options
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
 * 1. When a developer needs to convert legacy BMP icons into scalable SVG graphics for high‑resolution UI designs while preserving pixel‑art style using nearest‑neighbor interpolation.
 * 2. When an e‑commerce platform must generate SVG thumbnails from BMP product photos to ensure fast loading and infinite zoom without losing the original blocky appearance.
 * 3. When a game developer wants to double the size of BMP sprite sheets and export them as SVG assets for vector‑based rendering pipelines in Unity.
 * 4. When a document‑automation system requires batch processing of scanned BMP diagrams, resizing them with nearest‑neighbor resampling and saving as SVG for inclusion in PDF reports.
 * 5. When a GIS application needs to upscale BMP map tiles and convert them to SVG format for responsive web mapping interfaces that adapt to different screen sizes.
 */