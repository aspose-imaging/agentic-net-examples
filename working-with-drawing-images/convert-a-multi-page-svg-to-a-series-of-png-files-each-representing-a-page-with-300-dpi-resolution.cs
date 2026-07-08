using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/multipage.svg";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the SVG (vector) image
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to treat the image as a multipage vector image
                IMultipageImage multipageImage = image as IMultipageImage;

                if (multipageImage != null && multipageImage.PageCount > 1)
                {
                    // Process each page separately
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure PNG export options
                        using (PngOptions pngOptions = new PngOptions())
                        {
                            pngOptions.Source = new FileCreateSource(outputPath, false);
                            pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                            pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = image.Width,
                                PageHeight = image.Height
                            };
                            // Export only the current page
                            pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                            // Save the page as PNG
                            image.Save(outputPath, pngOptions);
                        }
                    }
                }
                else
                {
                    // Single-page SVG handling
                    string outputPath = Path.Combine(outputDirectory, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.Source = new FileCreateSource(outputPath, false);
                        pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate high‑resolution PNG assets for each page of a multi‑page SVG brochure using Aspose.Imaging for .NET at 300 DPI for a web storefront.
 * 2. When a developer must convert a multi‑page SVG diagram into printable 300 DPI PNG slices with Aspose.Imaging for .NET to embed in a PDF report.
 * 3. When a developer wants to transform vector‑based slide decks saved as multi‑page SVG files into separate PNG slides for a presentation system that only accepts raster images, using Aspose.Imaging for .NET.
 * 4. When a developer creates thumbnail previews of each page of a multi‑page SVG map at 300 DPI with Aspose.Imaging for .NET for a GIS application that caches raster tiles.
 * 5. When a developer exports each page of a multi‑page SVG invoice template to PNG files at 300 DPI with Aspose.Imaging for .NET for archival in a document‑management system that stores raster images.
 */