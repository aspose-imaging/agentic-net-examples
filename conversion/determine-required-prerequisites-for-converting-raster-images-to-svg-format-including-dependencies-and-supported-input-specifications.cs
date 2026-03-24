using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

namespace RasterToSvgPrerequisites
{
    class Program
    {
        static void Main()
        {
            // Hard‑coded input and output file paths (no argument validation)
            string inputPath = @"C:\Images\sample.png";          // supported raster formats: PNG, JPEG, BMP, GIF, TIFF, etc.
            string outputPath = @"C:\Images\sample.svg";

            // Verify that the input file exists; report error and exit if not found
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it unconditionally)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image using Aspose.Imaging.Image.Load
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Prepare vector rasterization options – required for SVG export
                // PageSize is set to the source image size to preserve dimensions
                VectorRasterizationOptions vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = rasterImage.Size
                };

                // Configure SVG save options
                SvgOptions svgSaveOptions = new SvgOptions
                {
                    // Optional: render text as shapes (true = text becomes paths)
                    TextAsShapes = true,
                    // Optional: compress output to SVGZ (false = plain SVG)
                    Compress = false,
                    // Attach the rasterization options defined above
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the image as SVG
                rasterImage.Save(outputPath, svgSaveOptions);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
    }
}