using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "Output\\framed.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            // Prepare PNG options with rasterization settings matching EPS size
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = eps.Width,
                    PageHeight = eps.Height
                }
            };

            // Export EPS to PNG
            eps.Save(outputPath, pngOptions);
        }

        // Load the generated PNG to draw a border
        using (var png = (RasterImage)Image.Load(outputPath))
        {
            // Create Graphics object for drawing
            var graphics = new Graphics(png);

            // Define border thickness
            int borderThickness = 10;

            // Draw rectangle border around the image
            var pen = new Pen(Color.Black, borderThickness);
            // Adjust rectangle to stay within image bounds
            var rect = new Rectangle(borderThickness / 2, borderThickness / 2, png.Width - borderThickness, png.Height - borderThickness);
            graphics.DrawRectangle(pen, rect);

            // Save changes back to the same file
            png.Save();
        }
    }
}