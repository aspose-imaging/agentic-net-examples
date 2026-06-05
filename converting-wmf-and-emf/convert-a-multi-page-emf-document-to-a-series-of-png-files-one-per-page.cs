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
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    string outputPath = Path.Combine("output", "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var options = new PngOptions();

                    if (image is VectorImage)
                    {
                        var vectorOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                        options.VectorRasterizationOptions = vectorOptions;
                    }

                    image.Save(outputPath, options);
                }
                else
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        string outputPath = Path.Combine("output", $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var options = new PngOptions
                        {
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                        };

                        if (image is VectorImage)
                        {
                            var vectorOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            options.VectorRasterizationOptions = vectorOptions;
                        }

                        image.Save(outputPath, options);
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