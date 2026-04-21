using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for PNG
            PngOptions rasterOptions = new PngOptions();
            rasterOptions.VectorRasterizationOptions = new VectorRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Rasterize the vector image into a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                vectorImage.Save(ms, rasterOptions);
                ms.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(ms))
                {
                    // Apply color overlay using Graphics
                    Graphics graphics = new Graphics(rasterImage);
                    // Example RGBA overlay: 50% transparent red
                    Color overlayColor = Color.FromArgb(128, 255, 0, 0);
                    using (SolidBrush brush = new SolidBrush(overlayColor))
                    {
                        graphics.FillRectangle(brush, rasterImage.Bounds);
                    }

                    // Save the final PNG image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}