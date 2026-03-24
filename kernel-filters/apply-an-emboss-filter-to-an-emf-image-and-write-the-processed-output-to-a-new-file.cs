using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Rasterize EMF to PNG in memory
            using (MemoryStream pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };
                emfImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                // Load rasterized image
                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(pngStream))
                {
                    // Apply emboss filter using convolution kernel
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Prepare EMF recorder graphics
                    var frame = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);
                    var deviceSize = new Aspose.Imaging.Size(raster.Width, raster.Height);
                    var deviceSizeMm = new Aspose.Imaging.Size(raster.Width / 100, raster.Height / 100);

                    var graphics = Aspose.Imaging.FileFormats.Emf.Graphics.EmfRecorderGraphics2D.FromEmfImage((Aspose.Imaging.FileFormats.Emf.EmfImage)emfImage);
                    // Draw the filtered raster image onto the EMF canvas
                    graphics.DrawImage(
                        raster,
                        new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height),
                        new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height),
                        Aspose.Imaging.GraphicsUnit.Pixel);

                    // Finalize and save the processed EMF image
                    using (Aspose.Imaging.FileFormats.Emf.EmfImage resultEmf = graphics.EndRecording())
                    {
                        resultEmf.Save(outputPath);
                    }
                }
            }
        }
    }
}