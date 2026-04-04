using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        string[] files = Directory.GetFiles(inputDirectory, "*.svg");
        int[] iconSizes = new int[] { 16, 32, 48, 256 };

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

            foreach (int size in iconSizes)
            {
                string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_{size}.ico");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set rasterization options for the desired icon size
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = new SizeF(size, size);
                    rasterOptions.BackgroundColor = Color.White;

                    // Save rasterized SVG to a memory stream as PNG
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    using (MemoryStream pngStream = new MemoryStream())
                    {
                        svgImage.Save(pngStream, pngOptions);
                        pngStream.Position = 0;

                        using (Image rasterImage = Image.Load(pngStream))
                        {
                            IcoOptions icoOptions = new IcoOptions();

                            using (Aspose.Imaging.FileFormats.Ico.IcoImage icoImage = new Aspose.Imaging.FileFormats.Ico.IcoImage(rasterImage, icoOptions))
                            {
                                icoImage.Save(outputPath);
                            }
                        }
                    }
                }
            }
        }
    }
}