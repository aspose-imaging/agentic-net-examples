using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input BMP files
            string[] inputFiles = {
                @"C:\Images\sample1.bmp",
                @"C:\Images\sample2.bmp"
            };

            // Hard‑coded output “bucket” folder for SVG files
            string outputBucket = @"C:\CloudBucket\svgs";

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputBucket, fileNameWithoutExt + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP and convert to SVG
                using (Image image = Image.Load(inputPath))
                {
                    var vectorOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };

                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}