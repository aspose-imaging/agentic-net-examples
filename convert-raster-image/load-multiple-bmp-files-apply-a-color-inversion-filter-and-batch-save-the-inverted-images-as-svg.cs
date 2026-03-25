using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input BMP files
        string[] inputFiles = new[]
        {
            @"C:\Images\sample1.bmp",
            @"C:\Images\sample2.bmp",
            @"C:\Images\sample3.bmp"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Load BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Invert colors pixel by pixel
                for (int y = 0; y < bmpImage.Height; y++)
                {
                    for (int x = 0; x < bmpImage.Width; x++)
                    {
                        // Get current pixel color
                        Aspose.Imaging.Color original = bmpImage.GetPixel(x, y);
                        // Invert RGB channels (preserve alpha)
                        Aspose.Imaging.Color inverted = Aspose.Imaging.Color.FromArgb(
                            original.A,
                            (byte)(255 - original.R),
                            (byte)(255 - original.G),
                            (byte)(255 - original.B));
                        bmpImage.SetPixel(x, y, inverted);
                    }
                }

                // Prepare output SVG path (same folder, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as SVG using default options
                SvgOptions svgOptions = new SvgOptions();
                bmpImage.Save(outputPath, svgOptions);
            }
        }
    }
}