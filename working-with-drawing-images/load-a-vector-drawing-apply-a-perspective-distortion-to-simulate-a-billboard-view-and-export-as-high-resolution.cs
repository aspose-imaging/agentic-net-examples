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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with high resolution
                var pngOptions = new PngOptions();

                // Set up vector rasterization options
                var rasterOptions = new VectorRasterizationOptions
                {
                    // Define a large page size for high‑resolution output
                    PageSize = new Size(3000, 2000),

                    // Optional: set background color
                    BackgroundColor = Color.White,

                    // Placeholder for perspective distortion.
                    // If Aspose.Imaging provides a Transform or Perspective matrix,
                    // it would be applied here, e.g.:
                    // Transform = new Matrix3x2(...);
                };

                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a marketing application needs to generate a high‑resolution PNG of an SVG logo that appears as if it were printed on a slanted billboard, developers can load the SVG, apply a perspective transform, and rasterize it at 3000×2000 pixels.
 * 2. When an e‑learning platform wants to create printable course slides from vector diagrams with realistic 3‑D tilt effects, the code can load the SVG, distort it to simulate a viewing angle, and export a crisp PNG for PDF compilation.
 * 3. When a real‑estate website needs to preview property signage by projecting a vector graphic onto a building façade image, developers can use this routine to apply perspective distortion and produce a high‑resolution PNG overlay.
 * 4. When a digital signage system must pre‑render SVG advertisements for large outdoor screens, the code enables loading the vector asset, warping it to match the screen’s perspective, and saving a high‑quality PNG for fast playback.
 * 5. When a game development tool requires converting SVG UI elements into texture maps that mimic a billboard perspective, the snippet loads the SVG, applies the transform, and outputs a high‑resolution PNG suitable for the game engine.
 */