using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Get the page as an Image
                        using (Image pageImage = (Image)multipageImage.Pages[i])
                        {
                            // Rasterize the SVG page to PNG in memory
                            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                            {
                                PageSize = pageImage.Size,
                                BackgroundColor = Color.White
                            };

                            PngOptions pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = rasterOptions
                            };

                            using (MemoryStream ms = new MemoryStream())
                            {
                                pageImage.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Load the rasterized image
                                using (RasterImage raster = (RasterImage)Image.Load(ms))
                                {
                                    // Apply Sharpen3x3 filter
                                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));

                                    // Save the filtered raster image
                                    string outPath = Path.Combine(outputDir, $"page_{i}.png");
                                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                                    raster.Save(outPath, new PngOptions());
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage SVG.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to enhance the visual clarity of each page in a multi‑page SVG brochure before converting it to high‑resolution PNGs for web publishing.
 * 2. When an e‑learning platform wants to automatically sharpen vector diagrams embedded in SVG slide decks so that the rasterized images appear crisp on mobile devices.
 * 3. When a printing workflow requires applying a Sharpen3x3 filter to every frame of a multi‑page SVG logo collection before exporting them as PNG assets for color‑accurate proofs.
 * 4. When a GIS application processes multi‑layer SVG maps and needs to improve edge definition of each layer before saving the rasterized tiles as PNG files.
 * 5. When a digital asset management system batch‑processes multi‑page SVG illustrations, applying a convolution sharpen filter to each page to enhance detail before storing the resulting PNGs in a searchable repository.
 */