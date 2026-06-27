using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD file paths
            string inputPath1 = @"C:\temp\image1.psd";
            string inputPath2 = @"C:\temp\image2.psd";
            string inputPath3 = @"C:\temp\image3.psd";

            // Verify each input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Hardcoded output TIFF path
            string outputPath = @"C:\temp\multipage.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TIFF options for a new file
            TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
            tiffOptions.Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);
            tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Load PSD images
            using (RasterImage psd1 = (RasterImage)Image.Load(inputPath1))
            using (RasterImage psd2 = (RasterImage)Image.Load(inputPath2))
            using (RasterImage psd3 = (RasterImage)Image.Load(inputPath3))
            // Create the TIFF image (initial size will be replaced by first added page)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, psd1.Width, psd1.Height))
            {
                // Add each PSD as a new page
                tiffImage.AddPage(psd1);
                tiffImage.AddPage(psd2);
                tiffImage.AddPage(psd3);

                // Save the multipage TIFF
                tiffImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to use the AddPage method to merge several PSD images into a single multipage TIFF for archival or printing workflows.
 * 2. When an application must generate a multi‑page TIFF by adding PSD pages with AddPage before saving to a printer that only accepts TIFF files.
 * 3. When a web service converts client‑uploaded PSD files into one multipage TIFF using AddPage for easy preview in browsers that support TIFF.
 * 4. When a batch‑processing tool consolidates PSD artwork from different product variants into a single TIFF file by adding each PSD as a page with AddPage.
 * 5. When a digital asset management system stores related PSD files as a single multipage TIFF, using AddPage to reduce storage overhead and simplify metadata handling.
 */