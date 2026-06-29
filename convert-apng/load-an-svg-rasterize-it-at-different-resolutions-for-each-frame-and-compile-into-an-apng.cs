using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG and output APNG paths
            string inputSvgPath = "input.svg";
            string outputApngPath = "output.apng";

            // Validate input file existence
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

            // Define resolutions for each frame (width x height)
            var resolutions = new List<(int width, int height)>
            {
                (200, 200),
                (400, 400),
                (600, 600)
            };

            // Use the first resolution to define canvas size
            int canvasWidth = resolutions[0].width;
            int canvasHeight = resolutions[0].height;

            // Prepare APNG creation options
            ApngOptions apngCreateOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputApngPath, false),
                DefaultFrameTime = 100, // default frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Load the SVG image once
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                // Create APNG image bound to the output file
                using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, canvasWidth, canvasHeight))
                {
                    // Add a frame for each resolution
                    foreach (var res in resolutions)
                    {
                        // Rasterize SVG to PNG in memory with desired size
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageWidth = res.width,
                                PageHeight = res.height
                            }
                        };

                        using (MemoryStream ms = new MemoryStream())
                        {
                            svgImage.Save(ms, pngOptions);
                            ms.Position = 0;
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                apngImage.AddFrame(raster);
                            }
                        }
                    }

                    // Save the APNG file
                    apngImage.Save();
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
 * 1. When a web developer wants to convert a scalable vector logo (SVG) into an animated PNG that shows the logo at multiple sizes for responsive design, they can use this code to rasterize the SVG at different resolutions and bundle the frames into an APNG.
 * 2. When a mobile app needs to display a high‑resolution icon animation that adapts to device pixel density, this C# snippet can generate an APNG with frames rendered from the same SVG at 1×, 2×, and 3× sizes.
 * 3. When an e‑learning platform wants to create a step‑by‑step illustration where each frame zooms into a diagram, the code can rasterize the original SVG at increasing canvas dimensions and compile the sequence into a single APNG file.
 * 4. When a game developer requires animated UI elements that retain crisp edges on any screen, they can use this example to rasterize a vector asset at several target resolutions and combine the results into an animated PNG for fast loading.
 * 5. When a marketing automation script must generate a compact animated banner from a single SVG source, this Aspose.Imaging for .NET code can produce an APNG with multiple resolution frames, ensuring the banner looks sharp across browsers.
 */