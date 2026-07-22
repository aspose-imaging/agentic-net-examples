using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Retrieve clipping path resources from the active frame
                var resources = tiffImage.ActiveFrame.PathResources;

                // Convert PathResources to a GraphicsPath
                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter
                    .ToGraphicsPath(resources.ToArray(), tiffImage.ActiveFrame.Size);

                // Prepare SVG options with bound output file
                var svgOptions = new SvgOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create an SVG image canvas with the same dimensions as the TIFF
                using (Image svgImage = Image.Create(svgOptions, tiffImage.Width, tiffImage.Height))
                {
                    // Draw the clipping path onto the SVG canvas
                    var graphics = new Graphics(svgImage);
                    graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                    // Save the SVG (output path already bound via FileCreateSource)
                    svgImage.Save();
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
 * 1. When a developer needs to extract the clipping path from a multi‑page TIFF document and provide it to a designer for vector editing in tools like Adobe Illustrator, they can use this code to convert the path to an SVG file.
 * 2. When an automated publishing pipeline must convert embedded TIFF clipping masks into scalable SVG assets for responsive web layouts, this snippet enables the extraction and conversion in C#.
 * 3. When a GIS or CAD application requires the precise vector outline of a scanned map stored as a TIFF clipping path to be reused in vector‑based analyses, the code can export that outline to SVG.
 * 4. When a digital archiving system wants to preserve the original TIFF clipping region as a separate vector file for future metadata indexing, the example shows how to generate the SVG directly from the TIFF frame.
 * 5. When a batch‑processing tool needs to validate or modify TIFF clipping paths by loading them, drawing them with Aspose.Imaging graphics, and saving them as editable SVGs for quality‑control reviewers, this code provides the necessary steps.
 */