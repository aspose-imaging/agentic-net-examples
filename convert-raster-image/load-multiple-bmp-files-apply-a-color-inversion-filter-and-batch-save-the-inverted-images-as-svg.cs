using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded list of BMP files to process
        string[] inputFiles = new[]
        {
            @"C:\Images\Input1.bmp",
            @"C:\Images\Input2.bmp",
            @"C:\Images\Input3.bmp"
        };

        // Output directory (hard‑coded)
        string outputDir = @"C:\Images\Output";

        // Ensure the output directory exists (rule 3)
        Directory.CreateDirectory(outputDir);

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists (rule 2)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load BMP image using Aspose.Imaging (lifecycle rule)
            using (BmpImage bmp = new BmpImage(inputPath))
            {
                // Invert colors pixel by pixel
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var original = bmp.GetPixel(x, y);
                        var inverted = Color.FromArgb(
                            original.A,
                            255 - original.R,
                            255 - original.G,
                            255 - original.B);
                        bmp.SetPixel(x, y, inverted);
                    }
                }

                // Prepare output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure the directory for the output file exists (rule 3)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up SVG saving options
                var svgOptions = new SvgOptions
                {
                    // Rasterization options are required for converting raster to SVG
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = bmp.Size
                    }
                };

                // Save as SVG (lifecycle rule)
                bmp.Save(outputPath, svgOptions);
            }
        }
    }
}