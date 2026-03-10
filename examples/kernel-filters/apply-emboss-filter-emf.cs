using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputEmfPath = "input.emf";
        string tempPngPath = "temp.png";
        string outputEmfPath = "output.emf";

        // Load EMF and rasterize to PNG
        using (Image emfImage = Image.Load(inputEmfPath))
        {
            int width = emfImage.Width;
            int height = emfImage.Height;

            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = width,
                PageHeight = height
            };

            var pngSaveOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
            emfImage.Save(tempPngPath, pngSaveOptions);
        }

        // Apply emboss filter to rasterized PNG
        using (Image rasterImg = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)rasterImg;
            var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
            rasterImage.Filter(rasterImage.Bounds, embossOptions);
            rasterImage.Save(tempPngPath);
        }

        // Draw embossed raster onto new EMF canvas
        using (Image embossedImg = Image.Load(tempPngPath))
        {
            RasterImage embossedRaster = (RasterImage)embossedImg;

            using (Image originalEmf = Image.Load(inputEmfPath))
            {
                int width = originalEmf.Width;
                int height = originalEmf.Height;

                var graphics = EmfRecorderGraphics2D.FromEmfImage((EmfImage)originalEmf);
                graphics.DrawImage(
                    embossedRaster,
                    new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, embossedRaster.Width, embossedRaster.Height),
                    GraphicsUnit.Pixel);

                using (EmfImage resultEmf = graphics.EndRecording())
                {
                    resultEmf.Save(outputEmfPath);
                }
            }
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}