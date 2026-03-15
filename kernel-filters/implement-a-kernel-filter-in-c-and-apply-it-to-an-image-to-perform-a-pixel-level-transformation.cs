using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the image as a RasterImage.
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Define a 3x3 edge‑detection kernel.
            double[,] kernel = new double[3, 3]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the custom convolution filter to the entire image.
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

            // Save the processed image.
            raster.Save(outputPath);
        }
    }
}