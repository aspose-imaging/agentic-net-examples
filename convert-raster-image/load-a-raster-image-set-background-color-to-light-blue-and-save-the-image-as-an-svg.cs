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
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions();

                // Configure rasterization options for SVG conversion
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Set the desired background color (light blue)
                    BackgroundColor = Aspose.Imaging.Color.LightBlue,
                    // Use the original image size as the page size
                    PageSize = image.Size
                };

                // Attach rasterization options to the save options
                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as SVG
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert a PNG logo to a scalable SVG for responsive web design while applying a light‑blue background to match the site’s color scheme.
 * 2. When an application must generate vector graphics from user‑uploaded raster images for printing, ensuring the output SVG uses the original image dimensions and a light‑blue canvas.
 * 3. When automating the preparation of icons for a mobile app, converting raster PNG assets to SVG format with a consistent light‑blue background for visual uniformity.
 * 4. When a reporting tool requires embedding images as SVG to reduce file size and maintain quality, and the developer wants to set a light‑blue background to meet branding guidelines.
 * 5. When a batch‑processing script processes scanned documents, converting each raster page to SVG while applying a light‑blue background to improve readability on dark‑mode interfaces.
 */