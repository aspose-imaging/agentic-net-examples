using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";
        string outputPath = Path.Combine(outputDirectory, "combined.apng");

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

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");
        if (svgFiles.Length == 0)
        {
            Console.WriteLine("No SVG files found in the input directory.");
            return;
        }

        Random rand = new Random();

        string firstPath = svgFiles[0];
        if (!File.Exists(firstPath))
        {
            Console.Error.WriteLine($"File not found: {firstPath}");
            return;
        }

        using (Aspose.Imaging.Image firstSvg = Aspose.Imaging.Image.Load(firstPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = firstSvg.Width,
                PageHeight = firstSvg.Height,
                BackgroundColor = Aspose.Imaging.Color.White
            };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

            using (MemoryStream ms = new MemoryStream())
            {
                firstSvg.Save(ms, pngOptions);
                ms.Position = 0;
                using (Aspose.Imaging.RasterImage firstRaster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                {
                    var createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apngImage = (ApngImage)Aspose.Imaging.Image.Create(createOptions, firstRaster.Width, firstRaster.Height))
                    {
                        apngImage.RemoveAllFrames();

                        int firstDelay = rand.Next(50, 301);
                        apngImage.AddFrame(firstRaster);
                        var firstFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                        firstFrame.FrameTime = firstDelay;

                        for (int i = 1; i < svgFiles.Length; i++)
                        {
                            string path = svgFiles[i];
                            if (!File.Exists(path))
                            {
                                Console.Error.WriteLine($"File not found: {path}");
                                return;
                            }

                            using (Aspose.Imaging.Image svg = Aspose.Imaging.Image.Load(path))
                            {
                                var ro = new SvgRasterizationOptions
                                {
                                    PageWidth = svg.Width,
                                    PageHeight = svg.Height,
                                    BackgroundColor = Aspose.Imaging.Color.White
                                };
                                var po = new PngOptions { VectorRasterizationOptions = ro };

                                using (MemoryStream ms2 = new MemoryStream())
                                {
                                    svg.Save(ms2, po);
                                    ms2.Position = 0;
                                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms2))
                                    {
                                        int delay = rand.Next(50, 301);
                                        apngImage.AddFrame(raster);
                                        var frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                                        frame.FrameTime = delay;
                                    }
                                }
                            }
                        }

                        apngImage.Save();
                    }
                }
            }
        }
    }
}