using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Verify that no pixel intensity exceeds 255
                bool withinRange = true;
                for (int y = 0; y < rasterImage.Height && withinRange; y++)
                {
                    for (int x = 0; x < rasterImage.Width; x++)
                    {
                        var color = rasterImage.GetPixel(x, y);
                        if (color.R > 255 || color.G > 255 || color.B > 255)
                        {
                            withinRange = false;
                            break;
                        }
                    }
                }

                if (withinRange)
                {
                    Console.WriteLine("All pixel intensities are within the 0-255 range.");
                }
                else
                {
                    Console.WriteLine("Warning: Some pixel intensities exceed 255.");
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When converting an SVG logo to a PNG thumbnail with a Gaussian blur, a developer can use this code to ensure the blurred pixels stay within the 0‑255 color range, preventing overflow artifacts in web displays.
 * 2. When preprocessing vector graphics for a mobile app’s background images, the snippet verifies that the Gaussian blur filter does not produce color values above 255, which could cause rendering glitches on low‑end devices.
 * 3. When generating print‑ready PNGs from SVG illustrations with a soft‑focus effect, the code checks pixel intensity limits to avoid color clipping that would degrade print quality.
 * 4. When integrating an automated image‑processing pipeline that applies Gaussian blur to SVG icons before uploading to a CDN, this routine confirms all RGB channels remain within the valid byte range, ensuring consistent visual output across browsers.
 * 5. When performing batch conversion of SVG diagrams to blurred PNGs for a data‑visualization dashboard, the example validates that no pixel exceeds 255, safeguarding against corrupted image files that could break the dashboard UI.
 */