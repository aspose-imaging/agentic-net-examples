using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.cmx";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmx = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                // Create a PNG canvas with the same dimensions as the CMX image
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Aspose.Imaging.Image png = Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    // Obtain a Graphics object for drawing
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(png);
                    // Clear the canvas
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Example: draw a diagonal line with uniform stroke width
                    Aspose.Imaging.Pen uniformPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                    graphics.DrawLine(uniformPen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width, height));

                    // Save the resulting PNG image
                    png.Save();
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
 * 1. When a CAD system exports engineering schematics as CMX files and the developer must standardize line thickness before converting them to PNG for web preview.
 * 2. When an automated reporting tool needs to generate high‑resolution PNG thumbnails from legacy CMX drawings while ensuring all lines have a uniform stroke width for consistent visual weight.
 * 3. When a document management workflow requires batch processing of CMX vector drawings to PNG images with a fixed pen width to meet corporate branding guidelines.
 * 4. When a GIS application imports CMX map overlays and the developer must normalize line thickness before rasterizing them to PNG for overlay on satellite imagery.
 * 5. When a print‑to‑PDF service converts CMX drawings to PNG assets and needs to enforce a minimum stroke width to avoid faint lines disappearing in the final PDF.
 */