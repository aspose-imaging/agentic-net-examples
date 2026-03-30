using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string rasterPath = "raster.png";
        string outputPath = "filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(rasterPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG and rasterize it to a PNG file
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Set rasterization options (use original SVG size)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = svgImage.Width,
                PageHeight = svgImage.Height,
                BackgroundColor = Color.White
            };

            // Set PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized image
            svgImage.Save(rasterPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterPath))
        {
            // Define a custom 5x5 kernel:
            // All surrounding elements = 1, central element = 5
            double[] kernel = new double[25];
            for (int i = 0; i < kernel.Length; i++)
                kernel[i] = 1.0;
            kernel[12] = 5.0; // center element (row 2, column 2)

            // Create the convolution filter with the custom kernel
            ConvolutionFilter filter = new ConvolutionFilter(kernel, 5, 5);

            // Apply the filter to the raster image
            rasterImage.ApplyFilter(filter);

            // Save the filtered image
            rasterImage.Save(outputPath);
        }
    }
}