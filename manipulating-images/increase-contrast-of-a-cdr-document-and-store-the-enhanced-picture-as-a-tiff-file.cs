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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/enhanced.tif";
            string tempPath = "Output/temp.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Step 1: Convert CDR (vector) to TIFF (raster) using vector rasterization options
            using (Image vectorImage = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                if (vectorImage is VectorImage)
                {
                    tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height
                    };
                }
                vectorImage.Save(tempPath, tiffOptions);
            }

            // Step 2: Load the generated TIFF, adjust contrast, and save final result
            using (Image tiffImg = Image.Load(tempPath))
            {
                var tiffImage = (TiffImage)tiffImg;
                tiffImage.AdjustContrast(50f); // Increase contrast (range -100 to 100)
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}