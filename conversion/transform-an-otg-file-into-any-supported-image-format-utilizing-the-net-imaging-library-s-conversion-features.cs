using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class OtgConverter
{
    // Converts an OTG file to the format defined by the provided save options.
    public static void ConvertOtgTo(string inputPath, string outputPath, ImageOptionsBase saveOptions)
    {
        // Load the OTG image using Aspose.Imaging's load method.
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for vector content.
            var otgRasterizationOptions = new OtgRasterizationOptions
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

    static void Main()
    {
        string dir = @"c:\aspose.imaging\";
        string inputFile = Path.Combine(dir, "sample.otg");

        // Convert OTG to PNG.
        var pngOptions = new PngOptions();
        ConvertOtgTo(inputFile, Path.Combine(dir, "sample.png"), pngOptions);

        // Convert OTG to PDF.
        var pdfOptions = new PdfOptions();
        ConvertOtgTo(inputFile, Path.Combine(dir, "sample.pdf"), pdfOptions);
    }
}