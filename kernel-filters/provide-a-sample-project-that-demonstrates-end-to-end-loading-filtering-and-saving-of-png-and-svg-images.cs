using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace AsposeImagingSample
{
    class Program
    {
        static void Main()
        {
            // Wrap the whole process to catch any unexpected errors.
            try
            {
                // Hard‑coded input and output file paths.
                string pngInputPath = @"C:\temp\sample.png";
                string pngOutputPath = @"C:\temp\sample.grayscale.png";

                string svgInputPath = @"C:\temp\sample.svg";
                string svgOutputPath = @"C:\temp\sample_from_svg.png";

                // ---------- PNG processing ----------
                // Verify the PNG source file exists.
                if (!File.Exists(pngInputPath))
                {
                    Console.Error.WriteLine($"File not found: {pngInputPath}");
                    return;
                }

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

                // Load the PNG, convert to grayscale, and save.
                using (PngImage pngImage = new PngImage(pngInputPath))
                {
                    pngImage.Grayscale();                     // Apply grayscale filter.
                    pngImage.Save(pngOutputPath);             // Save the processed image.
                }

                // ---------- SVG processing ----------
                // Verify the SVG source file exists.
                if (!File.Exists(svgInputPath))
                {
                    Console.Error.WriteLine($"File not found: {svgInputPath}");
                    return;
                }

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                // Load the SVG (vector) image.
                using (Image svgImage = Image.Load(svgInputPath))
                {
                    // Prepare PNG save options (e.g., enable progressive loading).
                    PngOptions pngOptions = new PngOptions
                    {
                        Progressive = true,
                        // Optional: set compression level, filter type, etc.
                        CompressionLevel = 9,
                        FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                    };

                    // Rasterize the SVG and save as PNG.
                    svgImage.Save(svgOutputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                // Report any runtime exception without crashing.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}