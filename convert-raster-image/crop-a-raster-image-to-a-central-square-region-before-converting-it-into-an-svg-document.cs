using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access cropping
                RasterImage raster = (RasterImage)image;

                // Determine the size of the central square
                int side = Math.Min(raster.Width, raster.Height);
                int left = (raster.Width - side) / 2;
                int top = (raster.Height - side) / 2;

                // Define the cropping rectangle (central square)
                Rectangle area = new Rectangle(left, top, side, side);
                raster.Crop(area);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the cropped image as SVG
                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When generating user profile avatars for a web application, a developer can crop the uploaded raster photo to a centered square and save it as an SVG for scalable display.
 * 2. When creating product thumbnail icons for an e‑commerce site, a developer can extract the central square of each PNG image and convert it to SVG to ensure crisp rendering on high‑resolution devices.
 * 3. When preparing QR code overlays for marketing materials, a developer can crop the scanned image to a central square region and export it as SVG for lossless scaling.
 * 4. When building a mobile game that uses vector assets, a developer can take in‑game screenshots, crop the central square, and convert them to SVG to reduce file size while preserving detail.
 * 5. When automating the generation of logo badges in a CI/CD pipeline, a developer can crop the logo image to its central square and save it as SVG for embedding in documentation and dashboards.
 */