using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Prepare PNG save options
            var pngOptions = new PngOptions();

            // Create a raster canvas with the same dimensions as the EPS image
            using (var canvas = Aspose.Imaging.Image.Create(pngOptions, epsImage.Width, epsImage.Height))
            {
                // Initialize graphics for the canvas
                var graphics = new Aspose.Imaging.Graphics(canvas);

                // Create a pen with round line join style
                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1);
                pen.LineJoin = Aspose.Imaging.LineJoin.Round; // set line join to round

                // Render the EPS image onto the canvas
                graphics.DrawImage(epsImage, new Aspose.Imaging.Rectangle(0, 0, epsImage.Width, epsImage.Height));

                // Save the rasterized image as PNG
                canvas.Save(outputPath, pngOptions);
            }
        }
    }
}