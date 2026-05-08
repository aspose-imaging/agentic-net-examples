using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.pdf";
            string outputDirectory = "output";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the PDF document
            using (Aspose.Imaging.Image pdfImage = Aspose.Imaging.Image.Load(inputPath))
            {
                if (pdfImage is Aspose.Imaging.IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;

                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var vectorOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Aspose.Imaging.Color.White,
                            SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                            PageWidth = pdfImage.Width,
                            PageHeight = pdfImage.Height
                        };

                        var pngOptions = new PngOptions
                        {
                            ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                            VectorRasterizationOptions = vectorOptions,
                            MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(i, i + 1))
                        };

                        pdfImage.Save(outputPath, pngOptions);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDirectory, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        PageWidth = pdfImage.Width,
                        PageHeight = pdfImage.Height
                    };

                    var pngOptions = new PngOptions
                    {
                        ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = vectorOptions
                    };

                    pdfImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}