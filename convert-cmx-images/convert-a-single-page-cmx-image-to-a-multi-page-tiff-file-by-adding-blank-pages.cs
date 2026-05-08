using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output\\multipage.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                // Rasterize CMX to a raster image in memory (PNG)
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    cmx.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Prepare TIFF options bound to the output file
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        tiffOptions.Source = new FileCreateSource(outputPath, false);
                        tiffOptions.Photometric = TiffPhotometrics.Rgb;
                        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                        {
                            // Write the first frame from the rasterized CMX
                            tiffImage.SavePixels(tiffImage.Bounds, raster.LoadPixels(raster.Bounds));

                            // Add blank pages
                            int blankPages = 2;
                            for (int i = 0; i < blankPages; i++)
                            {
                                var blankFrame = new TiffFrame(tiffOptions, width, height);
                                Graphics graphics = new Graphics(blankFrame);
                                graphics.Clear(Color.White);
                                tiffImage.AddFrame(blankFrame);
                            }

                            // Save the multi‑page TIFF
                            tiffImage.Save();
                        }
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