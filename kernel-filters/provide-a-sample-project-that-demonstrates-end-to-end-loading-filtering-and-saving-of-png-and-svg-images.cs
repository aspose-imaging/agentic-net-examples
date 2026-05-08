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
            try
            {
                // ---------- PNG processing ----------
                // Hard‑coded input and output paths
                string pngInputPath = @"C:\temp\sample.png";
                string pngOutputPath = @"C:\temp\sample.grayscale.png";

                // Verify input file exists
                if (!File.Exists(pngInputPath))
                {
                    Console.Error.WriteLine($"File not found: {pngInputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

                // Load PNG, apply grayscale filter, and save
                using (PngImage pngImage = new PngImage(pngInputPath))
                {
                    pngImage.Grayscale();               // filter
                    pngImage.Save(pngOutputPath);       // save
                }

                // ---------- SVG processing ----------
                // Hard‑coded input and output paths
                string svgInputPath = @"C:\temp\sample.svg";
                string svgOutputPath = @"C:\temp\sample_converted.png";

                // Verify input file exists
                if (!File.Exists(svgInputPath))
                {
                    Console.Error.WriteLine($"File not found: {svgInputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                // Load SVG (vector image) using the generic Image loader
                using (Image svgImage = Image.Load(svgInputPath))
                {
                    // Define PNG save options (e.g., progressive loading)
                    PngOptions pngOptions = new PngOptions
                    {
                        Progressive = true,
                        ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                    };

                    // Save the SVG as a PNG using the defined options
                    svgImage.Save(svgOutputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}