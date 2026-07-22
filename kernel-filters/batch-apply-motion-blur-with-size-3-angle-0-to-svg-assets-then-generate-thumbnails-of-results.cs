using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";
            string thumbDir = Path.Combine(outputDir, "Thumbnails");

            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(thumbDir);

            string[] files = Directory.GetFiles(inputDir, "*.svg");
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string tempPngPath = Path.Combine(outputDir, fileName + "_temp.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                // Rasterize SVG to PNG
                using (Image svgImage = Image.Load(inputPath))
                {
                    var svgOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = svgOptions };
                    svgImage.Save(tempPngPath, pngOptions);
                }

                // Apply motion blur filter
                using (Image rasterImage = Image.Load(tempPngPath))
                {
                    var raster = (RasterImage)rasterImage;
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(3, 1.0, 0.0));

                    string filteredPath = Path.Combine(outputDir, fileName + "_filtered.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));
                    raster.Save(filteredPath);

                    // Generate thumbnail
                    using (Image thumbImg = Image.Load(filteredPath))
                    {
                        thumbImg.Resize(200, 200, ResizeType.NearestNeighbourResample);
                        string thumbPath = Path.Combine(thumbDir, fileName + "_thumb.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(thumbPath));
                        thumbImg.Save(thumbPath);
                    }
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When a web designer needs to create a set of stylized SVG icons with a subtle motion‑blur effect and preview thumbnails for a UI component library, they can use this code to rasterize, blur, and thumbnail the assets in one batch.
 * 2. When an e‑learning platform wants to automatically generate blurred background images from vector illustrations and small preview PNGs for course catalogs, this C# routine processes all SVG files and outputs the filtered PNGs and thumbnails.
 * 3. When a marketing team prepares animated banner assets and requires a quick way to apply a uniform motion blur of size 3 at angle 0 to dozens of SVG logos while also creating low‑resolution thumbnails for A/B testing, the script handles the conversion and filtering automatically.
 * 4. When a mobile app developer needs to pre‑process SVG assets into blurred PNG sprites and corresponding thumbnail files to reduce runtime rendering cost on devices, the batch code performs rasterization, motion‑blur filtering, and thumbnail generation in C#.
 * 5. When a digital publishing workflow must produce print‑ready PNG images with a motion‑blur effect from vector diagrams and also generate web‑friendly thumbnail previews for the editorial CMS, this Aspose.Imaging example streamlines the entire process.
 */