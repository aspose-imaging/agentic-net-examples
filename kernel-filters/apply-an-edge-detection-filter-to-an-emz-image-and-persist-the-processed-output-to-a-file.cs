using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emz";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMZ (vector) image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Rasterize the vector image to a temporary PNG file
            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_emz_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            vectorImage.Save(tempPngPath, new PngOptions());

            // Load the rasterized PNG as a RasterImage
            using (Image rasterImg = Image.Load(tempPngPath))
            {
                // NOTE: Edge detection filter is not available in the allowed API set.
                // If needed, implement custom convolution here using ConvolutionFilterOptions,
                // but the required namespaces are not permitted by the current rules.
                // Therefore, we simply save the rasterized image without additional processing.

                rasterImg.Save(outputPath, new PngOptions());
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { /* ignore cleanup errors */ }
            }
        }
    }
}