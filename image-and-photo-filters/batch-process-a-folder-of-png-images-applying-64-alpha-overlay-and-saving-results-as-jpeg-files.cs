using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image loadedImage = Aspose.Imaging.Image.Load(inputPath))
                using (Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)loadedImage)
                {
                    var overlayOptions = new PngOptions
                    {
                        Source = new FileCreateSource(Path.GetTempFileName(), false)
                    };

                    using (Aspose.Imaging.Image overlayImage = Aspose.Imaging.Image.Create(overlayOptions, background.Width, background.Height))
                    using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)overlayImage)
                    {
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(overlay);
                        graphics.Clear(Aspose.Imaging.Color.Black);

                        background.Blend(new Aspose.Imaging.Point(0, 0), overlay, 64);
                    }

                    var jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        Quality = 90
                    };
                    background.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}