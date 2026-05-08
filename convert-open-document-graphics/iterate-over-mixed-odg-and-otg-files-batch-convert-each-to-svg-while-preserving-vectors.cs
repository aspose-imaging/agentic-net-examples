using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of input files (ODG and OTG)
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.odg",
                @"C:\Images\sample2.otg"
                // Add more file paths as needed
            };

            foreach (var inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image (ODG or OTG)
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG export options
                    SvgOptions svgOptions = new SvgOptions();

                    // Choose rasterization options based on file type
                    VectorRasterizationOptions rasterOptions;
                    string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                    if (ext == ".odg")
                    {
                        var odgRaster = new OdgRasterizationOptions();
                        odgRaster.PageSize = image.Size;
                        rasterOptions = odgRaster;
                    }
                    else // .otg
                    {
                        var otgRaster = new OtgRasterizationOptions();
                        otgRaster.PageSize = image.Size;
                        rasterOptions = otgRaster;
                    }

                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Define output path (same folder, same name with .svg extension)
                    string outputPath = inputPath + ".svg";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                    // Save the image as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}