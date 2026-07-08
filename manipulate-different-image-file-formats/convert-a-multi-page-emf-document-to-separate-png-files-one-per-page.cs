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
            string inputPath = "input.emf";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions pngOptions = new PngOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    if (image is VectorImage)
                    {
                        var vectorOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                        pngOptions.VectorRasterizationOptions = vectorOptions;
                    }

                    image.Save(outputPath, pngOptions);
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
 * 1. When a .NET application must extract each page of a multi‑page EMF report and save them as individual PNG images for web preview or thumbnail generation.
 * 2. When an automated document processing pipeline needs to rasterize vector‑based EMF diagrams into high‑resolution PNG files for inclusion in PDF reports or email attachments.
 * 3. When a Windows desktop tool converts legacy multi‑page EMF drawings into separate PNG assets to be used in a mobile app that only supports raster image formats.
 * 4. When a batch job processes a folder of EMF files, splitting each page into PNG files so that a content management system can index and display each page independently.
 * 5. When a developer integrates Aspose.Imaging in a C# service to transform multi‑page EMF charts into PNG images with consistent page size for printing or further image analysis.
 */