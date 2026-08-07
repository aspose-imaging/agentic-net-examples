using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath1 = @"C:\Images\image1.psd";
        string inputPath2 = @"C:\Images\image2.psd";
        string inputPath3 = @"C:\Images\image3.psd";
        string outputPath = @"C:\Images\multipage.tif";

        try
        {
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

            // Prepare TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
            tiffOptions.Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);
            tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create an empty TIFF image (size will be adjusted by added pages)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 100, 100))
            {
                // Load each PSD image and add it as a page
                using (RasterImage psd1 = (RasterImage)Image.Load(inputPath1))
                {
                    tiffImage.AddPage(psd1);
                }

                using (RasterImage psd2 = (RasterImage)Image.Load(inputPath2))
                {
                    tiffImage.AddPage(psd2);
                }

                using (RasterImage psd3 = (RasterImage)Image.Load(inputPath3))
                {
                    tiffImage.AddPage(psd3);
                }

                // Ensure output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a printing service needs to combine several layered Photoshop designs into a single multipage TIFF for batch printing or archiving.
 * 2. When a digital asset management system must consolidate multiple PSD files into one TIFF document to simplify metadata handling and version control.
 * 3. When a web application generates a downloadable multi‑page product catalog by merging individual PSD mockups into a single TIFF file.
 * 4. When an e‑discovery workflow requires converting a set of PSD evidence images into a single multipage TIFF for court‑compatible submission.
 * 5. When a document scanning solution wants to preserve the original PSD artwork while creating a compact, multi‑page TIFF for storage or transmission.
 */