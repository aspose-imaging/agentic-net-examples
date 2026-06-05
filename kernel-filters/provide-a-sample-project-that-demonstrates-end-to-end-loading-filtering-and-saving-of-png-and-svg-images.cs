using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

namespace AsposeImagingSample
{
    class Program
    {
        static void Main()
        {
            // Hard‑coded input and output file paths
            string pngInputPath = @"C:\temp\sample.png";
            string pngOutputPath = @"C:\temp\sample.grayscale.png";

            string svgInputPath = @"C:\temp\sample.svg";
            string svgOutputPath = @"C:\temp\sample_converted.png";

            try
            {
                // ---------- PNG processing ----------
                // Verify input file exists
                if (!File.Exists(pngInputPath))
                {
                    Console.Error.WriteLine($"File not found: {pngInputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

                // Load PNG, convert to grayscale, and save
                using (PngImage pngImage = new PngImage(pngInputPath))
                {
                    pngImage.Grayscale();                     // Apply grayscale filter
                    pngImage.Save(pngOutputPath);             // Save result
                }

                // ---------- SVG processing ----------
                // Verify input file exists
                if (!File.Exists(svgInputPath))
                {
                    Console.Error.WriteLine($"File not found: {svgInputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                // Load SVG (or any supported vector format) as a generic Image
                using (Image svgImage = Image.Load(svgInputPath))
                {
                    // Prepare PNG save options (e.g., enable progressive loading)
                    PngOptions pngOptions = new PngOptions
                    {
                        Progressive = true,
                        // Optional: set resolution, compression, etc.
                        CompressionLevel = 9,
                        FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                    };

                    // Save the rendered SVG as a PNG file
                    svgImage.Save(svgOutputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                // Unified error handling
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate grayscale thumbnails from user‑uploaded PNG photos to reduce file size and improve page‑load performance.
 * 2. When an e‑commerce platform must convert vendor‑supplied SVG logos into PNG images for inclusion in email newsletters and product listings.
 * 3. When a reporting tool automatically normalizes PNG charts to grayscale before embedding them in printable PDF reports.
 * 4. When a mobile app preprocesses PNG icons to grayscale to match a dark‑mode theme without maintaining separate asset files.
 * 5. When a batch‑processing script transforms mixed PNG and SVG design files into standardized PNG images for archival storage and downstream workflows.
 */