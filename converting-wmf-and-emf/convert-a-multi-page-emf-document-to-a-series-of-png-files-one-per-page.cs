using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input EMF file path
            string inputPath = "input.emf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Try to treat the image as a multipage vector image
                IMultipageImage multipage = image as IMultipageImage;

                if (multipage == null)
                {
                    // Single‑page EMF: export to one PNG
                    string outputPath = "output_page_1.png";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                    PngOptions pngOptions = new PngOptions
                    {
                        // Configure rasterization of the vector page
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageSize = image.Size,
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };

                    image.Save(outputPath, pngOptions);
                }
                else
                {
                    // Multi‑page EMF: export each page to a separate PNG
                    int pageCount = multipage.PageCount;

                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = $"output_page_{i + 1}.png";
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageSize = image.Size,
                                BackgroundColor = Color.White,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            },
                            // Export only the current page
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                        };

                        image.Save(outputPath, pngOptions);
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