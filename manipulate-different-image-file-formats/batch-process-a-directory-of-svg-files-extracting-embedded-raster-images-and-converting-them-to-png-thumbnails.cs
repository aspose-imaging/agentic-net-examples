// HOW-TO: Extract Embedded Images From SVG and Create PNG Thumbnails in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string svgPath in svgFiles)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    continue;
                }

                using (Image image = Image.Load(svgPath))
                {
                    VectorImage vectorImage = (VectorImage)image;
                    var embeddedImages = vectorImage.GetEmbeddedImages();
                    int index = 0;
                    foreach (var embedded in embeddedImages)
                    {
                        using (embedded)
                        {
                            using (Image embeddedImg = embedded.Image)
                            {
                                RasterImage raster = (RasterImage)embeddedImg;

                                int maxDim = 150;
                                int newWidth = raster.Width;
                                int newHeight = raster.Height;

                                if (raster.Width > raster.Height)
                                {
                                    if (raster.Width > maxDim)
                                    {
                                        newWidth = maxDim;
                                        newHeight = (int)((float)raster.Height / raster.Width * maxDim);
                                    }
                                }
                                else
                                {
                                    if (raster.Height > maxDim)
                                    {
                                        newHeight = maxDim;
                                        newWidth = (int)((float)raster.Width / raster.Height * maxDim);
                                    }
                                }

                                if (newWidth != raster.Width || newHeight != raster.Height)
                                {
                                    raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                                }

                                string baseName = Path.GetFileNameWithoutExtension(svgPath);
                                string outFileName = $"{baseName}_thumb_{index}.png";
                                string outPath = Path.Combine(outputDirectory, outFileName);
                                Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                                using (PngOptions pngOptions = new PngOptions())
                                {
                                    pngOptions.Source = new FileCreateSource(outPath, false);
                                    raster.Save(outPath, pngOptions);
                                }
                            }
                        }
                        index++;
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
 * 1. When you need to generate small preview PNGs for all raster images embedded in a collection of SVG icons for a web gallery.
 * 2. When an application must automatically extract photos from SVG diagrams and store them as separate PNG files for further analysis.
 * 3. When a build pipeline has to convert embedded high‑resolution bitmaps inside SVG assets into uniform 150‑pixel thumbnails for mobile apps.
 * 4. When a reporting tool requires extracting and resizing raster graphics from SVG charts to embed them in PDF summaries.
 * 5. When a content‑management system must batch‑process uploaded SVG files, pulling out any embedded images and saving them as lightweight PNG thumbnails for faster loading.
 */
