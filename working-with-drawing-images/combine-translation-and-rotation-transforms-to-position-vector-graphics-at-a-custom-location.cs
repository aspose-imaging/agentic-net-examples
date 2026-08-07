using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input\\vector.svg";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a blank PNG canvas
            using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), 800, 600))
            {
                // Initialize Graphics for the canvas
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Load the vector graphic (SVG) as a raster image
                using (RasterImage vectorRaster = (RasterImage)Image.Load(inputPath))
                {
                    // Build a combined transform: rotate 45° then translate (200,150)
                    Matrix transform = new Matrix();
                    transform.Rotate(45f);               // Rotation around the origin
                    transform.Translate(200f, 150f);     // Translation after rotation

                    // Apply the transform to the graphics context
                    graphics.Transform = transform;

                    // Draw the rasterized vector graphic at the origin (transform will position it)
                    graphics.DrawImage(vectorRaster, 0, 0);
                }

                // Save the final image to the specified file
                canvas.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to overlay a rotated SVG company logo onto a product photo at a specific offset, they can use this code to rotate the logo 45° and translate it to the desired coordinates before saving as a PNG.
 * 2. When generating printable marketing flyers, a developer can position a vector illustration at an exact spot on a blank canvas, applying rotation and translation to fit the layout requirements.
 * 3. When creating dynamic UI thumbnails that show icons rotated to indicate status, the code lets the developer rotate the SVG icon and move it to the correct location on a raster background.
 * 4. When building a map‑based web service that places a rotated directional arrow (SVG) on a map image at a given latitude/longitude offset, this transform logic positions the arrow accurately.
 * 5. When automating the production of custom certificates, a developer can rotate and place a vector seal onto the certificate canvas at a precise location before exporting the final PNG.
 */