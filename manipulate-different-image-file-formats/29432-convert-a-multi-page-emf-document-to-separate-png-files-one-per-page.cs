using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PngOptions options = new PngOptions
                        {
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageSize = image.Size,
                                BackgroundColor = Color.White
                            },
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                        };

                        image.Save(outputPath, options);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageSize = image.Size,
                            BackgroundColor = Color.White
                        }
                    };

                    image.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}