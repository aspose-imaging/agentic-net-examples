using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string tempPath = "temp_extrude.png";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure directories for temporary and output files exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // -----------------------------------------------------------------
        // Step 1: Load the vector image and rasterize it to a high‑resolution PNG
        // -----------------------------------------------------------------
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Configure high‑resolution PNG options (e.g., 300 DPI)
            PngOptions rasterOptions = new PngOptions
            {
                Source = new FileCreateSource(tempPath, false),
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // Save the rasterized version to a temporary file
            vectorImage.Save(tempPath, rasterOptions);
        }

        // -----------------------------------------------------------------
        // Step 2: Load the rasterized image and create an extruded canvas
        // -----------------------------------------------------------------
        using (RasterImage raster = (RasterImage)Image.Load(tempPath))
        {
            int extrusionDepth = 10; // pixels
            int canvasWidth = raster.Width + extrusionDepth;
            int canvasHeight = raster.Height + extrusionDepth;

            // Prepare PNG options for the final output (bound to the output file)
            PngOptions finalOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            using (Image canvas = Image.Create(finalOptions, canvasWidth, canvasHeight))
            {
                // Create a Graphics object (do NOT wrap in a using block)
                Graphics graphics = new Graphics(canvas);

                // Draw extrusion layers (offset copies) to simulate 3‑D effect
                for (int offset = extrusionDepth; offset > 0; offset--)
                {
                    graphics.DrawImage(raster, new Point(offset, offset));
                }

                // Draw the original image on top at the origin
                graphics.DrawImage(raster, new Point(0, 0));

                // Save the final extruded image
                canvas.Save();
            }
        }
    }
}