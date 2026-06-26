using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for low quality (no smoothing)
                VectorRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                // Set up BMP save options with the rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized BMP image
                image.Save(outputPath, bmpOptions);
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
 * 1. When a web service needs to generate low‑resolution BMP thumbnails from user‑uploaded SVG icons quickly, developers can use this code to rasterize the vectors with low quality for faster response times.
 * 2. When a desktop application processes thousands of SVG diagrams into BMP files for legacy reporting tools and must minimize CPU usage, setting the vector rasterization quality to low speeds up the conversion.
 * 3. When an automated build pipeline creates BMP assets from SVG logos for a mobile app that only requires small preview images, this low‑quality rasterization reduces conversion time and build duration.
 * 4. When a server‑side batch job converts SVG floor plans to BMP maps on a low‑powered VM, using low smoothing mode ensures the conversion completes within limited resources.
 * 5. When a data‑migration script moves vector graphics stored as SVG into a BMP‑based archive and the visual fidelity is not critical, applying low rasterization quality accelerates the migration process.
 */