using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\temp\image1.psd";
            string inputPath2 = @"C:\temp\image2.psd";
            string inputPath3 = @"C:\temp\image3.psd";
            string outputPath = @"C:\temp\multipage.tif";

            // Verify input files exist
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create an empty TIFF image (initial size is arbitrary)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 100, 100))
            {
                // Load each PSD and add it as a page
                using (RasterImage psd1 = Image.Load(inputPath1) as RasterImage)
                {
                    tiffImage.AddPage(psd1);
                }

                using (RasterImage psd2 = Image.Load(inputPath2) as RasterImage)
                {
                    tiffImage.AddPage(psd2);
                }

                using (RasterImage psd3 = Image.Load(inputPath3) as RasterImage)
                {
                    tiffImage.AddPage(psd3);
                }

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