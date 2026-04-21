using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Edge detection kernel (3x3)
        double[,] edgeKernel = new double[,]
        {
            { -1, -1, -1 },
            { -1,  8, -1 },
            { -1, -1, -1 }
        };

        // Load the multipage TIFF
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            int frameIndex = 0;
            foreach (TiffFrame frame in tiffImage.Frames)
            {
                // Set the current frame as active
                tiffImage.ActiveFrame = frame;

                // Apply edge detection filter to the active frame
                tiffImage.Filter(tiffImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel));

                // Save the processed frame as PNG
                string outputPath = Path.Combine(outputDirectory, $"frame_{frameIndex}.png");
                using (PngOptions pngOptions = new PngOptions())
                {
                    frame.Save(outputPath, pngOptions);
                }

                frameIndex++;
            }
        }
    }
}