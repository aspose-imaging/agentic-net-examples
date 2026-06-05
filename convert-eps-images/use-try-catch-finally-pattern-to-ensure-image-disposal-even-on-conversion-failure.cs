using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/sample.tif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Image image = null;
        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the source image
            image = Image.Load(inputPath);

            // Prepare TIFF save options
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // Ensure the image is disposed even if an error occurs
            if (image != null)
            {
                image.Dispose();
            }
        }
    }
}