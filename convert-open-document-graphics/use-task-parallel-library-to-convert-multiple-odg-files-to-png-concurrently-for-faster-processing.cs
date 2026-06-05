using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of ODG files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.odg",
                @"C:\Images\sample2.odg",
                @"C:\Images\sample3.odg"
            };

            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load ODG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set rasterization options based on source image size
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    // Configure PNG save options
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}