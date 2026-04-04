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
        // Hardcoded input PSD file paths
        string inputPath1 = @"c:\temp\image1.psd";
        string inputPath2 = @"c:\temp\image2.psd";
        string inputPath3 = @"c:\temp\image3.psd";

        // Hardcoded output TIFF file path
        string outputPath = @"c:\temp\multipage.tif";

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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure TIFF creation options
        TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
        tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create an initial TIFF image (size will be replaced by added pages)
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 1, 1))
        {
            // Load first PSD and add as a page
            using (Image psd1 = Image.Load(inputPath1))
            {
                tiffImage.AddPage((RasterImage)psd1);
            }

            // Load second PSD and add as a page
            using (Image psd2 = Image.Load(inputPath2))
            {
                tiffImage.AddPage((RasterImage)psd2);
            }

            // Load third PSD and add as a page
            using (Image psd3 = Image.Load(inputPath3))
            {
                tiffImage.AddPage((RasterImage)psd3);
            }

            // Remove the initially created default frame
            TiffFrame activeFrame = tiffImage.ActiveFrame;
            tiffImage.ActiveFrame = tiffImage.Frames[1];
            tiffImage.RemoveFrame(0);
            activeFrame.Dispose();

            // Save the multipage TIFF to the specified output path
            tiffImage.Save();
        }
    }
}