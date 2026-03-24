using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svgz";
        string tempPngPath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVGZ image and rasterize it to a temporary PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Create rasterization options for vector image
            var rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                BackgroundColor = Color.White
            };

            // Set up PNG save options with the rasterization options
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized image to temporary PNG file
            vectorImage.Save(tempPngPath, pngSaveOptions);
        }

        // Load the rasterized PNG, apply edge detection filter, and save the result
        using (Image rasterImageContainer = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)rasterImageContainer;

            // Define a simple Laplacian edge detection kernel
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply convolution filter with the edge detection kernel
            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(edgeKernel));

            // Save the processed image to the final output path
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary file
        try
        {
            File.Delete(tempPngPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}