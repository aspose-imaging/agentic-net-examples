using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of ODG input files
        var inputFiles = new List<string>
        {
            @"C:\Images\Input1.odg",
            @"C:\Images\Input2.odg",
            @"C:\Images\Input3.odg"
        };

        // Process each file in parallel
        Parallel.ForEach(inputFiles, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PNG path (same folder, same name with .png extension)
            var outputPath = Path.ChangeExtension(inputPath, ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG image and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();

                // Set rasterization options for vector to raster conversion
                var rasterOptions = new OdgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, pngOptions);
            }
        });
    }
}