using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Cmx.CmxImage cmx = (Aspose.Imaging.FileFormats.Cmx.CmxImage)Image.Load(inputPath))
            {
                int canvasWidth = cmx.Width;
                int canvasHeight = cmx.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Compression = TiffCompressions.Lzw;

                using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    foreach (var page in cmx.Pages)
                    {
                        using (var ms = new MemoryStream())
                        {
                            PngOptions pngOpts = new PngOptions();
                            pngOpts.Source = new StreamSource(ms);
                            page.Save(ms, pngOpts);
                            ms.Position = 0;

                            using (RasterImage rasterPage = (RasterImage)Image.Load(ms))
                            {
                                Rectangle bounds = new Rectangle(0, 0, rasterPage.Width, rasterPage.Height);
                                canvas.SaveArgb32Pixels(bounds, rasterPage.LoadArgb32Pixels(rasterPage.Bounds));
                            }
                        }
                    }

                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}