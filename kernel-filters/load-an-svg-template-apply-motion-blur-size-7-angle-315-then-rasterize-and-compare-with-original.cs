using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputDir = "output";
            string originalRasterPath = Path.Combine(outputDir, "original.png");
            string filteredRasterPath = Path.Combine(outputDir, "filtered.png");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(originalRasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(filteredRasterPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage
                SvgImage svgImage = (SvgImage)image;

                // Set up rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Save original rasterized PNG
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(originalRasterPath, pngOptions);
            }

            // Load the rasterized original PNG
            using (Image img = Image.Load(originalRasterPath))
            {
                RasterImage rasterImage = (RasterImage)img;

                // Apply motion blur (MotionWienerFilter) with size 7, sigma 1.0, angle 315
                var motionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(7, 1.0, 315.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Save the filtered image
                rasterImage.Save(filteredRasterPath);
            }

            // Load both images to compare dimensions
            using (Image originalImg = Image.Load(originalRasterPath))
            using (Image filteredImg = Image.Load(filteredRasterPath))
            {
                if (originalImg.Width == filteredImg.Width && originalImg.Height == filteredImg.Height)
                {
                    Console.WriteLine("Comparison result: Images have the same dimensions.");
                }
                else
                {
                    Console.WriteLine("Comparison result: Images differ in dimensions.");
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
 * 1. When a web application needs to generate a preview PNG of a user‑uploaded SVG logo and then create a blurred version for a loading placeholder, developers can use this code to rasterize the SVG, apply a motion‑blur filter (size 7, angle 315) and compare the two images.
 * 2. When an e‑commerce platform wants to automatically produce high‑resolution product thumbnails from vector artwork and also generate a motion‑blurred background for promotional banners, this snippet shows how to load the SVG, rasterize it to PNG, apply the blur, and verify the visual difference.
 * 3. When a desktop publishing tool must validate that a motion‑blur effect applied to vector graphics matches design specifications, developers can rasterize the original SVG, apply the blur filter, and programmatically compare the resulting PNGs.
 * 4. When a CI/CD pipeline for a branding suite needs to ensure that SVG assets are correctly rendered and that a motion‑blur filter of size 7 at 315° produces the expected raster output, this code provides the steps to load, rasterize, filter, and compare the images.
 * 5. When a mobile app generates animated splash screens by converting SVG icons to PNG frames with a motion‑blur transition, developers can use this example to load the SVG template, rasterize it, apply the blur, and check the blurred frame against the original for quality control.
 */