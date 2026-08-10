// HOW-TO: Create Multipage TIFF From PSD Files Using AddPage in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

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
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create an empty TIFF image (size 1x1, will be replaced by added pages)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 1, 1))
            {
                // Load each PSD image and add it as a new page
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

                // Remove the initially created empty frame
                TiffFrame activeFrame = tiffImage.ActiveFrame;
                if (tiffImage.Frames.Length > 1)
                {
                    tiffImage.ActiveFrame = tiffImage.Frames[1];
                    tiffImage.RemoveFrame(0);
                }
                activeFrame.Dispose();

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
 * 1. When you need to combine several layered Photoshop (PSD) designs into a single multipage TIFF for archival or printing workflows.
 * 2. When an application must generate a TIFF document where each page represents a separate PSD image, such as creating a portfolio or proof sheet.
 * 3. When you want to programmatically assemble multi‑page TIFF files for batch processing in a .NET service using Aspose.Imaging.
 * 4. When converting PSD assets to a format supported by legacy systems that only accept multipage TIFF files.
 * 5. When automating the creation of a multi‑page TIFF report that includes high‑resolution PSD graphics for compliance or documentation purposes.
 */
