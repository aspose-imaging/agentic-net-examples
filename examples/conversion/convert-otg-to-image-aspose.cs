using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            // Convert an OTG file to PNG
            ConvertOtgToFormat(@"C:\Images\sample.otg", @"C:\Images\sample_converted.png", new PngOptions());

            // Convert the same OTG file to PDF
            ConvertOtgToFormat(@"C:\Images\sample.otg", @"C:\Images\sample_converted.pdf", new PdfOptions());
        }

        /// <summary>
        /// Converts an OTG (OpenDocument Template) file to the specified image format.
        /// </summary>
        /// <param name="inputPath">Full path to the source OTG file.</param>
        /// <param name="outputPath">Full path where the converted file will be saved.</param>
        /// <param name="saveOptions">Aspose.Imaging save options for the desired output format.</param>
        static void ConvertOtgToFormat(string inputPath, string outputPath, ImageOptionsBase saveOptions)
        {
            // Load the OTG image using the unified Image.Load method.
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options specific for OTG files.
                // This ensures vector content is rasterized correctly.
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Preserve the original page size.
                    PageSize = image.Size
                };

                // Attach the rasterization options to the save options.
                saveOptions.VectorRasterizationOptions = otgRasterizationOptions;

                // Save the image in the desired format.
                image.Save(outputPath, saveOptions);
            }
        }
    }
}