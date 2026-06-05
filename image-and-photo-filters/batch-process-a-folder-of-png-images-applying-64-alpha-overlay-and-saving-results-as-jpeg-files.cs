using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string overlayPath = Path.Combine(inputDirectory, "overlay.png");
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"Overlay file not found: {overlayPath}");
                return;
            }

            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                string[] files = Directory.GetFiles(inputDirectory, "*.png");
                foreach (string inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    if (string.Equals(inputPath, overlayPath, StringComparison.OrdinalIgnoreCase))
                        continue;

                    using (RasterImage image = (RasterImage)Image.Load(inputPath))
                    {
                        image.Blend(new Point(0, 0), overlay, 64);

                        string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            Quality = 90
                        };

                        image.Save(outputPath, jpegOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}