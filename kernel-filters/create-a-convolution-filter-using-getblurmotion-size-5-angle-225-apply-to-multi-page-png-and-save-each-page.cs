using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.IMultipageImage multiPage = image as Aspose.Imaging.IMultipageImage;
                if (multiPage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                for (int i = 0; i < multiPage.PageCount; i++)
                {
                    using (Aspose.Imaging.RasterImage page = (Aspose.Imaging.RasterImage)multiPage.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PngOptions pngOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };

                        page.Save(outputPath, pngOptions);
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