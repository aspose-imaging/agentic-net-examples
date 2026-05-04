using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of ODG files to convert.
            string[] inputPaths = new string[]
            {
                @"C:\Images\sample1.odg",
                @"C:\Images\sample2.odg",
                @"C:\Images\sample3.odg"
            };

            // Process each file in parallel.
            Parallel.ForEach(inputPaths, inputPath =>
            {
                // Verify the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PNG path (same folder, .png extension).
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the ODG image.
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare rasterization options for ODG → raster image conversion.
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };

                    // Set up PNG save options and attach rasterization options.
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the image as PNG.
                    image.Save(outputPath, pngOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}