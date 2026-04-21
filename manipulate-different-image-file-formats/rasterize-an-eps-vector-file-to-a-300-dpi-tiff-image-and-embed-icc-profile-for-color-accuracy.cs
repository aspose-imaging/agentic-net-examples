using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure rasterization options
                var rasterOptions = new EpsRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                // Set up TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as TIFF
                epsImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}