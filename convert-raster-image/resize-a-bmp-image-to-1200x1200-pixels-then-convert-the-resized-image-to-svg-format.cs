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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Resize the image to 1200x1200 pixels
                image.Resize(1200, 1200);

                // Set up SVG save options with rasterization settings
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

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
 * 1. When a developer needs to generate a scalable vector version of a legacy BMP logo for responsive web design, they can resize it to 1200 × 1200 and convert it to SVG using Aspose.Imaging for .NET.
 * 2. When an application must prepare high‑resolution thumbnails from BMP scans and store them as lightweight SVG files for fast loading in browsers, this code provides the required resize‑and‑convert workflow.
 * 3. When a document‑generation system has to embed BMP diagrams into PDF reports as vector graphics, resizing them to a uniform 1200 × 1200 size and converting to SVG ensures consistent scaling and small file size.
 * 4. When a batch‑processing tool needs to standardize user‑uploaded BMP images to a fixed square dimension and then transform them into SVG for later editing in vector‑editing software, the shown C# routine accomplishes that.
 * 5. When a legacy Windows desktop app must modernize its UI assets by turning BMP icons into scalable SVG icons while enforcing a 1200‑pixel square canvas, this Aspose.Imaging code handles the resizing and rasterization automatically.
 */