using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output/output.tiff";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Retrieve original dimensions
                int originalWidth = djvu.Width;
                int originalHeight = djvu.Height;

                // Apply proportional scaling (double the width, height adjusts automatically)
                djvu.ResizeWidthProportionally(originalWidth * 2, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                // Save the result as TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                djvu.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}