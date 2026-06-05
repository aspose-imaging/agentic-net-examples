using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up PNG options with a file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new PNG image
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Draw on the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 300, 300));

                // Apply a 3x3 edge detection convolution filter
                RasterImage raster = (RasterImage)image;
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                var convOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                // Save the image (output path already bound via FileCreateSource)
                image.Save();
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
 * 1. When a developer needs to programmatically create a PNG image with a red rectangle and emphasize its borders using a 3x3 edge detection convolution filter for a technical report, this Aspose.Imaging C# code provides a quick solution.
 * 2. When an application must generate stylized UI icons on the fly, drawing shapes and applying edge detection to give them a crisp outline before saving as PNG, the code demonstrates the required steps.
 * 3. When preprocessing scanned drawings for OCR or computer‑vision pipelines, a developer can use this example to draw reference shapes, apply an edge detection filter, and export the result as a PNG file.
 * 4. When automating the production of printable schematics that need highlighted edges for better visual contrast, the code shows how to create, draw, filter, and save the image in one workflow.
 * 5. When building a C# service that creates diagnostic screenshots with highlighted contours for quality‑control dashboards, this snippet illustrates drawing, applying a convolution filter, and exporting the final PNG.
 */