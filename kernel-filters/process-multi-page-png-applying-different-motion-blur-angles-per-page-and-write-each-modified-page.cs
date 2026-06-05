using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directory
            string inputPath = "input.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page PNG (APNG)
            using (Image multiImage = Image.Load(inputPath))
            {
                if (multiImage is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Extract the page as a raster image
                        using (RasterImage page = (RasterImage)multipageImage.Pages[i])
                        {
                            // Apply motion blur with a distinct angle per page
                            double angle = i * 30.0; // example: 0°, 30°, 60°, ...
                            var motionBlur = new MotionWienerFilterOptions(10, 1.0, angle);
                            page.Filter(page.Bounds, motionBlur);

                            // Prepare output path for the modified page
                            string outputPath = Path.Combine("output", $"page_{i}.png");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the modified page as PNG
                            var pngOptions = new PngOptions();
                            page.Save(outputPath, pngOptions);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
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
 * 1. When a developer needs to extract each frame from an animated PNG (APNG) and apply a unique motion‑blur angle per frame to create a stylized video preview.
 * 2. When a graphics pipeline must split a multi‑page PNG into separate PNG files, adding different blur angles to simulate camera movement across presentation slides.
 * 3. When an e‑learning platform wants to generate a series of step‑by‑step illustrations from a single APNG, adjusting the motion blur angle on each page to highlight progression.
 * 4. When a game asset pipeline processes sprite sheets stored as multi‑page PNGs and requires individual frames with varying motion blur to produce dynamic motion‑trail effects.
 * 5. When a digital‑marketing tool automates the creation of animated banner ads by extracting APNG pages, applying distinct motion‑blur angles, and saving each modified page as a separate PNG.
 */