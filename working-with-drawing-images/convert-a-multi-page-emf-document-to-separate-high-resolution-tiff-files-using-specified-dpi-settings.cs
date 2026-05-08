using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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
                // Attempt to treat the image as a multipage vector image
                IMultipageImage multipage = image as IMultipageImage;

                if (multipage != null && multipage.PageCount > 0)
                {
                    // Process each page separately
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Output TIFF file for the current page
                        string outputPath = $"output_page{i + 1}.tif";

                        // Ensure output directory exists (guard against null)
                        string outputDir = Path.GetDirectoryName(outputPath);
                        Directory.CreateDirectory(outputDir ?? ".");

                        // Configure TIFF save options
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300); // High DPI
                        tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                        // If the source is a vector image, set rasterization options
                        if (image is VectorImage)
                        {
                            VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            tiffOptions.VectorRasterizationOptions = vectorOptions;
                        }

                        // Save the current page as a separate TIFF file
                        image.Save(outputPath, tiffOptions);
                    }
                }
                else
                {
                    // Single-page EMF handling
                    string outputPath = "output.tif";

                    // Ensure output directory exists (guard against null)
                    string outputDir = Path.GetDirectoryName(outputPath);
                    Directory.CreateDirectory(outputDir ?? ".");

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300); // High DPI

                    if (image is VectorImage)
                    {
                        VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                        tiffOptions.VectorRasterizationOptions = vectorOptions;
                    }

                    image.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}