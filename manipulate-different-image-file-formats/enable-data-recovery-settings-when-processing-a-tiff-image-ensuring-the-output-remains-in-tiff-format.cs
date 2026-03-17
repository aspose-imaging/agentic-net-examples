using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Configure load options to enable data recovery for corrupted TIFF files
            LoadOptions loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            // Load the TIFF image with the specified recovery settings
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Set up TIFF save options (default format)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the recovered image back to TIFF format
                image.Save(outputPath, tiffOptions);
            }
        }
    }
}